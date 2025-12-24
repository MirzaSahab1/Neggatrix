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
    public class LevelFive : ILevel
    {
        public void Build(Game game)
        {
            Color shadow = Color.Black;
            Color veinColor = Color.FromArgb(5, 5, 5); // Almost pure black, just for texture
            Random rng = new Random(123);

            // --- THE "VEINS" (Background Clutter) ---
            // Creating massive, sweeping arcs that cross the entire 15,000 units
            for (int x = 0; x < 15000; x += 100)
            {
                float arc = (float)Math.Sin(x * 0.0005) * 800;
                // Visual only "Tendrils"
                var tendril = new Block(new PointF(x, -600 + arc), veinColor, new SizeF(20, 400));
                tendril.RemoveComponent(tendril.GetComponent<BoxCollider>());
                game.AddObject(tendril);
            }

            // --- SECTION 1: THE SHATTERED RIBCAGE (X: 0 - 5000) ---
            // Massive vertical "bones" that curve toward the player
            for (int x = 500; x < 5000; x += 600)
            {
                // Bottom Rib
                game.AddObject(new Block(new PointF(x, -200), shadow, new SizeF(100, 400)));
                // Top Rib (Hanging)
                game.AddObject(new Block(new PointF(x + 100, -1500), shadow, new SizeF(100, 800)));

                // The actual jump: a tiny "shard" broken off the rib
                game.AddObject(new Block(new PointF(x + 250, -450), shadow, new SizeF(50, 50)));
            }

            // --- SECTION 2: THE INK RAIN (X: 5500 - 9000) ---
            // Hundreds of tiny, thin vertical blocks to simulate frozen rain
            for (int i = 0; i < 300; i++)
            {
                float x = 5500 + rng.Next(0, 3500);
                float y = -rng.Next(0, 1500);
                y = (float)(Math.Round(y / 50.0) * 50);

                var rain = new Block(new PointF(x, y), shadow, new SizeF(10, rng.Next(50, 200)));

                // Only make some collidable to make it a "leap of faith" section
                if (rng.NextDouble() > 0.7)
                {
                    // Collidable path
                }
                else
                {
                    rain.RemoveComponent(rain.GetComponent<BoxCollider>());
                    rain.GetComponent<Renderer>().BGColor = veinColor;
                }
                game.AddObject(rain);
            }

            // --- SECTION 3: THE HEART OF THE VOID (X: 10000 - 13000) ---
            // A massive, solid block structure with holes carved out in a "Voronoi" pattern
            for (int x = 10000; x < 13000; x += 200)
            {
                for (int y = -1000; y < 0; y += 200)
                {
                    // Only place block if it fits a "noise" pattern
                    if ((Math.Sin(x * 0.01) + Math.Cos(y * 0.01)) > 0.5)
                    {
                        game.AddObject(new Block(new PointF(x, y), shadow, new SizeF(150, 150)));
                    }
                }
            }

            // --- SECTION 4: THE COLLAPSING MONOLITH (X: 13500 - 15000) ---
            // One giant block that has "shattered" into tiny pieces
            for (int i = 0; i < 150; i++)
            {
                float x = 13500 + rng.Next(0, 1500);
                float y = -rng.Next(200, 1000);
                y = (float)(Math.Round(y / 50.0) * 50);

                game.AddObject(new Block(new PointF(x, y), shadow, new SizeF(50, 50)));
            }

            // The End: A massive vertical abyss
            game.AddObject(new Block(new PointF(14950, -2000), shadow, new SizeF(50, 3000)));
        }
    }
}
