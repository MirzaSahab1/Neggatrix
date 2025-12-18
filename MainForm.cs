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
            game = new Game();
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

            game.AddObject(square);

            GameObject floor = new GameObject();
            var floorTransform = floor.AddComponent<Transform>();
            floorTransform.Position = new PointF(300, 800);
            floorTransform.Rotation = 0;

            var floorRenderer = floor.AddComponent<Renderer>();
            floorRenderer.BGColor = Color.Green;
            floorRenderer.Size = new SizeF(400, 50);

            var floorCollider = floor.AddComponent<BoxCollider>();
            floorCollider.Size = floorRenderer.Size;

            game.AddObject(floor);
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
                    if (Input.IsPressed(Keys.Space))
                    {
                        transform.Position = new PointF(150, 100);
                        physics.Velocity = new PointF(0, 0);
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
