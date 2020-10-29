using Bot.Skills;
using Bot.Utilities.Processed.Packet;

namespace Bot
{
    internal class DecisionMaker
    {
        private readonly SkillManager _skillManager;

        public DecisionMaker(SkillManager skillManager)
        {
            _skillManager = skillManager;

            // TODO: Test a skill here.
            _skillManager.SetSkill(new TestSkill());
        }

        internal void Tick(Packet packet)
        {
            // TODO: Custom decision-making logic will go here.

            _skillManager.Tick(packet);
        }
    }
}
