using System;
using System.Windows.Forms;
using Neggatrix.Core;
using Neggatrix.Components;
using System.ComponentModel;
using System.Diagnostics;
using Topshelf.Runtime;
using System.ServiceProcess;
using System.Runtime.InteropServices;
using Neggatrix.Common;
using EZInput;

namespace Neggatrix
{
    public partial class MainForm : Form
    {
        private double accumulator = 0;
        private readonly float targetDeltaTime = 1f / 60f;

        private Game game;
        private Stopwatch stopwatch;
        public double lastTime = 0.0f;

        public MainForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            KeyPreview = true;
            stopwatch = new Stopwatch();
            Application.Idle += GameLoop;
            stopwatch.Start();
            Start();
        }
        Transform transform;
        PhysicsBody physics;
        public void Start()
        {
            // Game
            game = new Game();

            // Player
            GameObject square = new GameObject();

            transform = square.AddComponent<Transform>();
            transform.Position = new PointF(150, 100);
            transform.Rotation = 0;

            var renderer = square.AddComponent<Renderer>();
            renderer.BGColor = Color.Red;
            renderer.Size = new SizeF(50, 50);

            var collider = square.AddComponent<BoxCollider>();
            collider.Size = renderer.Size;

            physics = square.AddComponent<PhysicsBody>();
            physics.Friction = 0.8f;

            game.AddObject(square);

            // Floor
            GameObject floor = new GameObject();
            var floorTransform = floor.AddComponent<Transform>();
            floorTransform.Position = new PointF(0, Height);
            

            var floorRenderer = floor.AddComponent<Renderer>();
            floorRenderer.BGColor = Color.Green;
            floorRenderer.Size = new SizeF(2000, 50);

            var floorCollider = floor.AddComponent<BoxCollider>();
            floorCollider.Size = floorRenderer.Size;
            floorCollider.IsTrigger = false;

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
                    if (Input.IsPressed(Keys.W))
                    {
                        physics.AddForce(new PointF(0, -1000));
                    }
                    if (Input.IsDown(Keys.A))
                    {
                        physics.AddForce(new PointF(-100, 0));
                    }
                    if (Input.IsDown(Keys.D))
                    {
                        physics.AddForce(new PointF(100, 0));
                    }




                    game.Update(targetDeltaTime);
                    accumulator -= targetDeltaTime;

                    Invalidate();
                    Input.EndFrame();
                }
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            game.Render(e.Graphics);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            Input.KeyDown(e.KeyCode);
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            Input.KeyUp(e.KeyCode);
        }
    }
}
