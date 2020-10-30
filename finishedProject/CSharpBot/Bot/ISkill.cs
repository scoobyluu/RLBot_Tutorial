using Bot.Utilities.Processed.Packet;
using RLBotDotNet;

namespace Bot
{
    internal interface ISkill
    {
        bool IsFinished { get; }

        void Init();
        Controller Tick(Packet packet);
        void Interrupt();
        void Finish();
    }
}
