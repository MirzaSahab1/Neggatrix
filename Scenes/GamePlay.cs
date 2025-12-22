using Neggatrix.Common;
using Neggatrix.Components;
using Neggatrix.Core;
using Neggatrix.Presets;
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
        private AudioManager audioManager;
        private double accumulator = 0;
        private readonly float targetDeltaTime = 1f / 60f;

        private Game? game;
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
        PhysicsBody? physics;
        Player player;
        public void Start()
        {
            audioManager = new AudioManager();
            audioManager.MusicVolume = 0.01f;
            //audioManager.PlayMusic("D:\\Neggatrix\\Neggatrix\\Assets\\Audio\\BackgroundMusic.mp3");


            // Game
            game = new Game();

            player = new Player();
            physics = player.GetComponent<PhysicsBody>();
            game.AddObject(player);

            // Floor
            GameObject floor = new GameObject();
            var floorTransform = floor.AddComponent<Transform>();
            floorTransform.Position = new PointF(0, Height);


            var floorRenderer = floor.AddComponent<Renderer>();
            floorRenderer.BGColor = Color.Green;
            floorRenderer.Size = new SizeF(2000, 50);

            var floorCollider = floor.AddComponent<BoxCollider>();
            floorCollider.Size = floorRenderer.Size;

            game.AddObject(floor);

            // Wall
            GameObject wall = new GameObject();
            var wallTransform = wall.AddComponent<Transform>();
            wallTransform.Position = new PointF(Width, Height);
            var wallRenderer = wall.AddComponent<Renderer>();
            wallRenderer.BGColor = Color.Blue;
            wallRenderer.Size = new SizeF(200, 200);
            var wallCollider = wall.AddComponent<BoxCollider>();
            wallCollider.Size = wallRenderer.Size;
            var audioPlayer = wall.AddComponent<AudioPlayer>();
            audioPlayer.filePath = "D:\\Neggatrix\\Neggatrix\\Assets\\Audio\\BackgroundMusic.mp3";
            game.AddObject(wall);
        }
        private void GameLoop(object? sender, EventArgs? e)
        {
            while (Utils.IsAppIdle())
            {
                double currentTime = stopwatch.Elapsed.TotalSeconds;
                double elapsedTime = currentTime - lastTime;
                lastTime = currentTime;

                accumulator += elapsedTime;

                while (accumulator >= targetDeltaTime)
                {
                    if (physics != null)
                    {
                        if (Input.IsPressed(Keys.W))
                        {
                            physics.AddForce(new PointF(0, -1000));
                            audioManager.SfxVolume = 1f;
                            audioManager.PlaySound("D:\\Neggatrix\\Neggatrix\\Assets\\Audio\\Jump.mp3");
                        }
                        if (Input.IsDown(Keys.A))
                        {
                            physics.AddForce(new PointF(-100, 0));
                        }
                        if (Input.IsDown(Keys.D))
                        {
                            physics.AddForce(new PointF(100, 0));
                        }
                        if (Input.IsPressed(Keys.E))
                        {
                            var camera = player.GetComponent<Camera>();
                            if (camera != null)
                            {

                                camera.ShakeIntensity = 10f;
                            }
                        }
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
