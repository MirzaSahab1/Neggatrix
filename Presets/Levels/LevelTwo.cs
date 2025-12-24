using Neggatrix.Components;
using Neggatrix.Core;
using Neggatrix.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neggatrix.Presets.Levels
{
    public class LevelTwo : ILevel
    {
        public void Build(Game game)
        {
            Color shadow = Color.Black;

            // --- The Foundation ---
            // Floor is at Y=0, Height is 50
            game.AddObject(new Block(new PointF(7500, 0), shadow, new SizeF(15000, 50)));

            // --- Section 1: The Jagged Entrance (0 - 3000) ---
            // Staggered stairs and low ceilings
            game.AddObject(new Block(new PointF(400, -150), shadow, new SizeF(200, 50)));
            game.AddObject(new Block(new PointF(800, -300), shadow, new SizeF(200, 50)));
            game.AddObject(new Block(new PointF(1200, -450), shadow, new SizeF(200, 50)));

            // A "Crusher" ceiling (static)
            game.AddObject(new Block(new PointF(1000, -800), shadow, new SizeF(1000, 100)));

            // --- Section 2: The Vertical Shaft (3000 - 6000) ---
            // More crowded, requiring zig-zag jumping
            for (int i = 0; i < 6; i++)
            {
                float xPos = 3200 + (i * 400);
                float yPos = -200 - (i * 150); // Multiples of 50
                game.AddObject(new Block(new PointF(xPos, yPos), shadow, new SizeF(150, 50)));

                // Add a "Floating Spike" (non-collidable block or just an obstacle)
                game.AddObject(new Block(new PointF(xPos + 200, yPos - 100), shadow, new SizeF(50, 50)));
            }

            // --- Section 3: The Moving Void (6000 - 9000) ---
            // Crowded moving platforms. Ensure game.AddObject happens BEFORE AddComponent.
            Block m1 = new Block(new PointF(6500, -500), shadow, new SizeF(200, 50));
            game.AddObject(m1);

            Block m2 = new Block(new PointF(8000, -800), shadow, new SizeF(200, 50));
            game.AddObject(m2);

            // --- Section 4: The Shadow Cage (9000 - 13000) ---
            // Narrow corridors made of large blocks
            game.AddObject(new Block(new PointF(10000, -200), shadow, new SizeF(1000, 50))); // Floor
            game.AddObject(new Block(new PointF(10000, -500), shadow, new SizeF(1000, 50))); // Ceiling

            // Pillars inside the cage
            game.AddObject(new Block(new PointF(10300, -350), shadow, new SizeF(50, 150)));
            game.AddObject(new Block(new PointF(10700, -450), shadow, new SizeF(50, 150)));

            // --- Section 5: The Final Leap (13000 - 15000) ---
            game.AddObject(new Block(new PointF(13500, -600), shadow, new SizeF(300, 50)));
            game.AddObject(new Block(new PointF(14200, -400), shadow, new SizeF(200, 50)));

            // The Exit Pillar
            game.AddObject(new Block(new PointF(14800, -1000), shadow, new SizeF(200, 2000)));
        }
    }
}
