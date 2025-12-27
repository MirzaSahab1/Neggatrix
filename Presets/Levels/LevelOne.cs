using Neggatrix.Components;
using Neggatrix.Core;
using Neggatrix.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Neggatrix.Presets.Levels
{
    public class LevelOne : ILevel
    {
        public void Build(Game game)
        {
            Block Floor = new Block(new PointF(4000, 0), Color.Black, new SizeF(10000, 50));

            // Wall
            Block StartWall = new Block(new PointF(-1000, -225), Color.Black, new SizeF(50, 500));

            Block Plt1 = new Block(new PointF(100, -200), Color.Black, new SizeF(200, 50));

            // Adding GameObjects
            game.AddObject(Floor);
            game.AddObject(StartWall);
            game.AddObject(Plt1);
            // --- The Stairway (Progressive height) ---
            game.AddObject(new Block(new PointF(400, -350), Color.Black, new SizeF(150, 50)));
            game.AddObject(new Block(new PointF(700, -500), Color.Black, new SizeF(150, 50)));
            game.AddObject(new Block(new PointF(1000, -650), Color.Black, new SizeF(150, 50)));

            //game.AddObject(new Enemy(new PointF(600, -300), new PatrolMovement()));

            // --- The High Peak (A wide rest area) ---
            game.AddObject(new Block(new PointF(1500, -800), Color.Black, new SizeF(400, 50)));

            // --- The Long Jump (Testing physics and speed) ---
            game.AddObject(new Block(new PointF(2300, -800), Color.Black, new SizeF(100, 40)));

            // --- The Vertical Drop (Leads back to the main floor area) ---
            game.AddObject(new Block(new PointF(2800, -600), Color.Black, new SizeF(50, 50)));
            game.AddObject(new Block(new PointF(3100, -400), Color.Black, new SizeF(50, 50)));
            game.AddObject(new Block(new PointF(3400, -200), Color.Black, new SizeF(50, 50)));

            game.AddObject(new Block(new PointF(4000, -50), Color.Black, new SizeF(50, 50)));
            // --- The Tunnel Entrance (Large blocks creating a roof) ---
            game.AddObject(new Block(new PointF(4500, -150), Color.Black, new SizeF(800, 320))); // A thick wall/ceiling
                                                                                                 // Cluster 1: The Ascent

            game.AddObject(new Block(new PointF(4600, -520), Color.Black, new SizeF(150, 50)));

            // Cluster 2: The High Canopy
            game.AddObject(new Block(new PointF(5000, -620), Color.Black, new SizeF(400, 50)));
            game.AddObject(new Block(new PointF(5500, -670), Color.Black, new SizeF(400, 50)));

            // Cluster 3: The Jagged Descent
            game.AddObject(new Block(new PointF(6200, -500), Color.Black, new SizeF(100, 100)));
            game.AddObject(new Block(new PointF(6500, -300), Color.Black, new SizeF(100, 100)));




            // Steps leading up the Wall
            game.AddObject(new Block(new PointF(8100, -200), Color.Black, new SizeF(100, 20)));
            game.AddObject(new Block(new PointF(8250, -420), Color.Black, new SizeF(100, 20)));
            game.AddObject(new Block(new PointF(8100, -640), Color.Black, new SizeF(100, 20)));
            game.AddObject(new Block(new PointF(8250, -850), Color.Black, new SizeF(100, 20)));
            // The Massive Wall (Must climb to -1200 to pass)
            game.AddObject(new Block(new PointF(8500, -500), Color.Black, new SizeF(200, 1000)));
            Block exit = new Block(new PointF(8500, -1100), Color.Black, new SizeF(180, 180));
            exit.Name = "LevelExit";
            exit.collider.IsTrigger = true;
            exit.renderer.BGColor = Color.FromArgb(50, 0, 255, 0);
            game.AddObject(exit);
        }
    }
}
