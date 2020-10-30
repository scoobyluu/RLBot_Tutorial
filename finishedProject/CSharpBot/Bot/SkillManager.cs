using Bot.Skills;
using Bot.Utilities.Processed.Packet;
using RLBotDotNet;

namespace Bot
{
    internal class SkillManager
    {
        private ISkill _currentSkill;

        public SkillManager()
        {
            _currentSkill = new EmptySkill();
        }

        public void SetSkill(ISkill skill)
        {
            _currentSkill.Interrupt();
            _currentSkill.Finish();

            _currentSkill = skill;
            _currentSkill.Init();
        }

        public Controller Tick(Packet packet)
        {
            if (_currentSkill.IsFinished)
            {
                // TODO
            }

            return _currentSkill.Tick(packet);
        }
    }
}
