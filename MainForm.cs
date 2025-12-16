using System;
using System.Windows.Forms;
using Neggatrix.Core;
using Neggatrix.Components;
using System.ComponentModel;

namespace Neggatrix
{
    public partial class MainForm : Form
    {
        private Game game;

        public MainForm()
        {
            InitializeComponent();
            DoubleBuffered = true; 
            Start();
        }

        public void Start()
        {
            game = new Game(); 
            GameObject square = new GameObject();

            var transform = square.AddComponent<Transform>();
            transform.Position = new PointF(150, 100);
            transform.Rotation = 50;

            var renderer = square.AddComponent<Renderer>();
            renderer.BGColor = Color.Red;
            renderer.Size = new SizeF(60, 50);

            game.AddObject(square);
        }

        public void gameTimer_Tick(object sender, EventArgs e)
        {
            float deltaTime = 0.016f;

            game.Update(deltaTime);

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            game.Render(e.Graphics);
        }
    }
}
