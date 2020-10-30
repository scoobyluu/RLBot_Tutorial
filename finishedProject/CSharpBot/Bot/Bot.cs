using Bot.Utilities.Processed.BallPrediction;
using Bot.Utilities.Processed.FieldInfo;
using Bot.Utilities.Processed.Packet;
using RLBotDotNet;

namespace Bot
{
    // We want to our bot to derive from Bot, and then implement its abstract methods.
    class Bot : RLBotDotNet.Bot
    {
        private readonly SkillManager _skillManager;
        private readonly DecisionMaker _decisionMaker;

        // We want the constructor for our Bot to extend from RLBotDotNet.Bot, but we don't want to add anything to it.
        // You might want to add logging initialisation or other types of setup up here before the bot starts.
        public Bot(string botName, int botTeam, int botIndex) : base(botName, botTeam, botIndex)
        {
            _skillManager = new SkillManager();
            _decisionMaker = new DecisionMaker(_skillManager);
        }

        public override Controller GetOutput(rlbot.flat.GameTickPacket gameTickPacket)
        {
            // We process the gameTickPacket and convert it to our own internal data structure.
            Packet packet = new Packet(gameTickPacket, this, Renderer);

            _decisionMaker.Tick(packet);

            return _skillManager.Tick(packet);
        }
        
        // Hide the old methods that return Flatbuffers objects and use our own methods that
        // use processed versions of those objects instead.
        internal new FieldInfo GetFieldInfo() => new FieldInfo(base.GetFieldInfo());
        internal new BallPrediction GetBallPrediction() => new BallPrediction(base.GetBallPrediction());
    }
}