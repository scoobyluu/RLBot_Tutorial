using System;
using Bot.Utilities.Processed.Packet;
using Keras.Models;
using Python.Runtime;

namespace Bot
{
    internal class DecisionMaker
    {
        private readonly SkillManager _skillManager;

        private readonly BaseModel _model;

        private int _currentSkillId;

        public DecisionMaker(SkillManager skillManager)
        {
            _skillManager = skillManager;

            try
            {
                _model = BaseModel.LoadModel("");
            }
            catch (PythonException e)
            {
                Console.Error.WriteLine(e.Message);
            }

            // TODO: Test your custom skill here.
            SetSkill(0);
        }

        internal void Tick(Packet packet)
        {
            if (_model != null)
            {
                var state = packet.Serialize();
                var prediction = _model.Predict(state);
                var probabilities = prediction[0];
                var maxIndex = probabilities.argmax().GetData<int>()[0];

                if (maxIndex != _currentSkillId)
                {
                    SetSkill(maxIndex);
                }
            }

            _skillManager.Tick(packet);
        }

        private void SetSkill(int id)
        {
            _currentSkillId = id;

            var skill = SkillFactory.CreateSkill(id);

            _skillManager.SetSkill(skill);
        }
    }
}

