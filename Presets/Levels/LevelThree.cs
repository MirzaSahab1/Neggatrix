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
    public class LevelThree : ILevel
    {
        public void Build(Game game)
        {
            Color shadow = Color.Black;
            Color junkColor = Color.FromArgb(15, 15, 15); // Slightly lighter for visual clutter

            // --- THE BROKEN FLOOR (With Holes) ---
            // Instead of one block, we create segments. If there is a gap in X, it's a hole.
            game.AddObject(new Block(new PointF(0, 0), shadow, new SizeF(3000, 50)));
            // Hole at 3000-3300
            game.AddObject(new Block(new PointF(3300, 0), shadow, new SizeF(4000, 50)));
            // Hole at 7300-7700
            game.AddObject(new Block(new PointF(7700, 0), shadow, new SizeF(2000, 50)));
            // Hole at 9700-10200
            game.AddObject(new Block(new PointF(10200, 0), shadow, new SizeF(4800, 50)));

            // --- THE "CROWDED" CLUTTER (Visual Only) ---
            // These blocks won't have BoxColliders (assuming your Block constructor 
            // allows you to toggle colliders, or you just make a "VisualBlock" class)
            Random rng = new Random(42);
            for (int i = 0; i < 100; i++)
            {
                float x = rng.Next(0, 15000);
                float y = rng.Next(-1000, 0);
                var junk = new Block(new PointF(x, (float)(Math.Round(y / 50.0) * 50)), junkColor, new SizeF(rng.Next(20, 100), rng.Next(20, 100)));

                // If you can remove the collider, do it here so they are purely visual
                var col = junk.GetComponent<BoxCollider>();
                if (col != null) junk.RemoveComponent(col);

                game.AddObject(junk);
            }

            // --- THE ACTUAL PLATFORMS (Multiples of 50) ---
            for (int x = 500; x < 14500; x += 350)
            {
                // Vertical variation
                float yBase = -200 - (rng.Next(0, 4) * 150);

                // The Main Path
                game.AddObject(new Block(new PointF(x, yBase), shadow, new SizeF(250, 50)));

                // "Cluttered" debris attached to platforms
                game.AddObject(new Block(new PointF(x + 50, yBase - 50), shadow, new SizeF(50, 50)));
                game.AddObject(new Block(new PointF(x + 150, yBase + 50), shadow, new SizeF(50, 100)));
            }

            // --- THE ROTATED VISUALS (Faking it) ---
            // Since we aren't doing rotated collisions, we can use very thin 
            // vertical/horizontal bars to simulate "girders" leaning against platforms.
            for (int x = 1000; x < 14000; x += 1200)
            {
                // Long thin vertical beams
                game.AddObject(new Block(new PointF(x, -1500), shadow, new SizeF(20, 1500)));

                // Crossed beams (simulating a 'X' shape)
                game.AddObject(new Block(new PointF(x - 100, -400), shadow, new SizeF(200, 10)));
                game.AddObject(new Block(new PointF(x - 100, -450), shadow, new SizeF(200, 10)));
            }

            // --- CEILING (Cluttered) ---
            game.AddObject(new Block(new PointF(7500, -1200), shadow, new SizeF(15000, 100)));
            for (int x = 0; x < 15000; x += 600)
            {
                // Stalactites hanging down
                game.AddObject(new Block(new PointF(x, -1100), shadow, new SizeF(50, 250)));
            }
        }
    }
}
