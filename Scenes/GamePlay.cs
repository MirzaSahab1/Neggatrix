using Neggatrix.Common;
using Neggatrix.Components;
using Neggatrix.Core;
using Neggatrix.Presets;
using Neggatrix.Presets.Levels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neggatrix.Scenes
{
    public partial class GamePlay : UserControl
    {
        // Variables Related to Games Time
        private double accumulator = 0;
        private readonly float targetDeltaTime = 1f / 60f;
        private Stopwatch stopwatch;
        public double lastTime = 0.0f;

        public GamePlay()
        {
            InitializeComponent();
            this.Width = Utils.gameWindowWidth;
            this.Height = Utils.gameWindowHeight;
            DoubleBuffered = true;
           
            stopwatch = new Stopwatch();
            Application.Idle += GameLoop;
            stopwatch.Start();
            Start();
        }

        // Variables Related to the Game
        private Game? game;
        public void Start() // Runs Once At the Start
        {
            // Game
            game = new Game(this);
            string startLevel = "1"; 
            if (FileUtils.GetField("data.txt", 5) == "0") { startLevel = FileUtils.GetField("data.txt", 1); }
            else
            {
                startLevel = FileUtils.GetField("data.txt", 5);
                FileUtils.SaveField("data.txt", 5, "0");
            }
            game.Start(startLevel);
        }
        private void GameLoop(object? sender, EventArgs? e)
        {
            while (Utils.IsAppIdle())
            {
                double currentTime = stopwatch.Elapsed.TotalSeconds;
                double elapsedTime = currentTime - lastTime;
                lastTime = currentTime;

                accumulator += elapsedTime;

                while (accumulator >= targetDeltaTime) // Runs Every Frame
                {
                    if (game != null) game.Update(targetDeltaTime);
                    accumulator -= targetDeltaTime;

                    Invalidate();
                    Input.EndFrame();
                }
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (game != null) game.Render(e.Graphics, ClientSize.Width, ClientSize.Height);
        }
    }
}
