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
    public partial class Level1 : UserControl
    {
        // Variables Related to Games Time
        private double accumulator = 0;
        private readonly float targetDeltaTime = 1f / 60f;
        private Stopwatch stopwatch;
        public double lastTime = 0.0f;

        public Level1()
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
        Player? player;
        Enemy? enemy;
        public void Start() // Runs Once At the Start
        {
            // Game
            game = new Game();
            game.Audio.MusicVolume = 0.01f; 

            // Player
            player = new Player(new PointF(0, -200), Color.Black, new SizeF(50, 50));

            enemy = new Enemy(new PointF(300, -300), new PatrolMovement());

            game.Level.LoadLevel(new LevelOne());

            game.AddObject(player);
            game.AddObject(enemy);
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
                    player.movement.Move();
                    foreach (var hitObject in player.physicsBody.ActiveCollisions)
                    {
                        if (hitObject.Name == "LevelExit")
                        {
                            player.transform.Position = new PointF(0, -200);
                            player.camera.Start();
                            game.Level.LoadLevel(new LevelTwo());
                            
                        }
                    }
                    if (Input.IsDown(Keys.W) && player.physicsBody.IsGrounded)
                    {
                        player.animator.AddTrack("Transform", "Rotation", 0f, 360f, 1f, true, () => !player.physicsBody.IsGrounded);
                    }

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
