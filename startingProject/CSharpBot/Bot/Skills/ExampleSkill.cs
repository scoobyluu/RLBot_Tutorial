using Bot.Utilities.Processed.Packet;
using RLBotDotNet;

namespace Bot.Skills
{
    internal class EmptySkill : ISkill
    {
        public bool IsFinished => false;

        public void Finish()
        {
        }

        public void Init()
        {
        }

        public void Interrupt()
        {
        }

        public Controller Tick(Packet packet)
        {
            return new Controller();
        }
    }
}
