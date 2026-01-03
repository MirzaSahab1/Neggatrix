using Neggatrix.Common;
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
    public class LevelFour : ILevel
    {
        public void Build(Game game)
        {
            Color shadow = Color.Black;
            Color structureColor = Color.FromArgb(128, 10, 10, 10); // Very dark gray for background structures
            Random rng = new Random(777);

            // --- THE VOID (No Floor) ---
            // We are NOT adding a main floor block here. 
            // If the player falls, they die. We only provide floating "islands".

            // --- THE STARTING PEDESTAL ---
            game.AddObject(new Block(new PointF(-200, -200), shadow, new SizeF(600, 50)));
            game.AddObject(new Block(new PointF(-50, -400), shadow, new SizeF(200, 50)));

            // --- SECTION 1: THE HELIX PATH (X: 500 - 5000) ---
            // Two paths crossing each other vertically like a DNA strand.
            for (int x = 500; x < 5000; x += 400)
            {
                float sineVal = (float)Math.Sin(x * 0.001);
                float y1 = -400 + (sineVal * 300); // Path A
                float y2 = -400 - (sineVal * 300); // Path B

                // Snap to 50-unit grid
                y1 = (float)(Math.Round(y1 / 50.0) * 50);
                y2 = (float)(Math.Round(y2 / 50.0) * 50);

                game.AddObject(new Block(new PointF(x, y1), shadow, new SizeF(100, 50)));
                game.AddObject(new Block(new PointF(x, y2), shadow, new SizeF(100, 50)));
                game.AddObject(new ScorePoint(new PointF(x, y2-50), Color.White, 10));

                // Artistic "Connectors" (Visual Only - no colliders)
                var beam = new Block(new PointF(x + 40, (Utils.Distance(new PointF(0, y1), new PointF(0, y2)) / Math.Max(y1, y2)) - 375), structureColor, new SizeF(20, Math.Abs(y1 - y2)));
                var col = beam.GetComponent<BoxCollider>();
                if (col != null) beam.RemoveComponent(col);
                game.AddObject(beam);
            }

            // --- SECTION 2: THE SHADOW RIBS (X: 5500 - 10000) ---
            // Massive vertical pillars that curve over the top
            for (int x = 5500; x < 10000; x += 800)
            {
                // The "Rib" (Visual backdrop)
                var rib = new Block(new PointF(x, -1500), structureColor, new SizeF(100, 2000));
                var col = rib.GetComponent<BoxCollider>();
                if (col != null) rib.RemoveComponent(col);
                game.AddObject(rib);

                // The challenging jumps attached to the ribs
                game.AddObject(new Block(new PointF(x - 50, -300), shadow, new SizeF(200, 50)));
                game.AddObject(new Block(new PointF(x + 150, -500), shadow, new SizeF(50, 50))); // Precision landing
                game.AddObject(new ScorePoint(new PointF(x + 150, -550), Color.White, 10));
            }
            game.AddObject(new Block(new PointF(10100, -650), shadow, new SizeF(50, 50)));
            // --- SECTION 3: THE BROKEN CATHEDRAL (X: 10500 - 14000) ---
            // Floating "chandeliers" and thin vertical towers
            for (int x = 10500; x < 14000; x += 600)
            {
                // Tower base
                game.AddObject(new Block(new PointF(x, -100), shadow, new SizeF(50, 400)));

                // High floating chandelier platforms
                game.AddObject(new Block(new PointF(x - 100, -850), shadow, new SizeF(250, 50)));

                // Tiny debris jumps between towers
                game.AddObject(new Block(new PointF(x + 300, -450), shadow, new SizeF(50, 50)));
                game.AddObject(new ScorePoint(new PointF(x + 300, -500), Color.White, 10));
            }

            // --- THE FINAL ABYSS JUMP ---
            game.AddObject(new Block(new PointF(14500, -500), shadow, new SizeF(500, 50)));

            // Final Exit Pillar (Multiple of 50 height)
            game.AddObject(new Block(new PointF(14900, -1000), shadow, new SizeF(100, 2000)));
            
            game.AddObject(new Block(new PointF(14500, -640), Color.Black, new SizeF(100, 20)));
            game.AddObject(new Block(new PointF(14650, -850), Color.Black, new SizeF(100, 20)));
            game.AddObject(new Block(new PointF(14500, -1060), Color.Black, new SizeF(100, 20)));
            game.AddObject(new Block(new PointF(14650, -1270), Color.Black, new SizeF(100, 20)));
            game.AddObject(new Block(new PointF(14500, -1510), Color.Black, new SizeF(100, 20)));
            game.AddObject(new Block(new PointF(14650, -1750), Color.Black, new SizeF(100, 20)));
            game.AddObject(new Block(new PointF(14500, -1990), Color.Black, new SizeF(100, 20)));
            game.AddObject(new Block(new PointF(14650, -2220), Color.Black, new SizeF(100, 20)));
            Block exit = new Block(new PointF(14900, -2000), Color.Black, new SizeF(180, 180));
            exit.Name = "LevelExit";
            exit.collider.IsTrigger = true;
            exit.renderer.Sprite = Properties.Resources.Gateway;
            exit.renderer.BGColor = Color.FromArgb(50, 0, 255, 0);
            game.AddObject(exit);
        }
    }
}
