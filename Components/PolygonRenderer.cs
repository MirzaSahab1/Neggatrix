using Neggatrix.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neggatrix.Interfaces;

namespace Neggatrix.Components
{
    public class PolygonRenderer : IComponent, IRenderable
    {
        public GameObject Owner { get; set; }

        public Color FillColor { get; set; }
        public Color OutlineColor { get; set; } 
        public float OutlineThickness { get; set; } 
        public PointF[] Vertices { get; set; } 

        public SizeF Size { get; private set; }
        
        public PolygonRenderer()
        {
            Owner = null!;
            FillColor = Color.Black;
            OutlineColor = Color.Transparent;
            OutlineThickness = 1f;
            Vertices = new PointF[0];
        }
        public void Start()
        {
            CalculateBounds();
        }

        public void CalculateBounds()
        {
            if (Vertices.Length == 0) return;

            float minX = Vertices.Min(v => v.X);
            float maxX = Vertices.Max(v => v.X);
            float minY = Vertices.Min(v => v.Y);
            float maxY = Vertices.Max(v => v.Y);

            Size = new SizeF(maxX - minX, maxY - minY);
        }

        public void Render(Graphics g)
        {
            if (Vertices == null || Vertices.Length < 3) return;

            var transform = Owner.GetComponent<Transform>();
            if (transform == null) return;

            var state = g.Save();

            g.TranslateTransform(transform.Position.X, transform.Position.Y);

            if (transform.Rotation != 0)
            {
                g.RotateTransform(transform.Rotation);
            }

            using (Brush brush = new SolidBrush(FillColor))
            {
                g.FillPolygon(brush, Vertices);
            }

            if (OutlineColor != Color.Transparent)
            {
                using (Pen pen = new Pen(OutlineColor, OutlineThickness))
                {
                    g.DrawPolygon(pen, Vertices);
                }
            }
            g.Restore(state);
        }

        public void Update(float deltaTime) { }
        public void Destroy() { }
    }
}
