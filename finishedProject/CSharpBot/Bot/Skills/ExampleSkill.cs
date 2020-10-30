using Bot.Utilities.Processed.Packet;
using RLBotDotNet;
using RLBotDotNet.Renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Bot.Skills
{
    internal class TestSkill : ISkill
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
            // Get the data required to drive to the ball.
            Vector3 ballLocation = packet.Ball.Physics.Location;
            Vector3 carLocation = packet.Players[packet.PlayerIndex].Physics.Location;
            Orientation carRotation = packet.Players[packet.PlayerIndex].Physics.Rotation;

            // Find where the ball is relative to us.
            Vector3 ballRelativeLocation = Orientation.RelativeLocation(carLocation, ballLocation, carRotation);

            // Decide which way to steer in order to get to the ball.
            // If the ball is to our left, we steer left. Otherwise we steer right.
            float steer;
            if (ballRelativeLocation.Y > 0)
                steer = 1;
            else
                steer = -1;

            //Examples of rendering in the game
            packet.Renderer.DrawString3D("Ball", Colors.Black, ballLocation, 3, 3);
            packet.Renderer.DrawString3D(steer > 0 ? "Right" : "Left", Colors.Aqua, carLocation, 3, 3);
            packet.Renderer.DrawLine3D(Colors.Red, carLocation, ballLocation);

            // This controller will contain all the inputs that we want the bot to perform.
            return new Controller
            {
                // Set the throttle to 1 so the bot can move.
                Throttle = 1,
                Steer = steer
            };
        }
    }
}
