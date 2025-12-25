using Neggatrix.Core;
using Neggatrix.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neggatrix.Components
{
    public class PolygonCollider : IComponent
    {
        public GameObject Owner { get; set; } = null!;
        public PointF[] Vertices { get; set; } = new PointF[0]; 
        public bool IsPointInside(PointF worldPoint)
        {
            var transform = Owner.GetComponent<Transform>();
            if (transform == null) return false;

            PointF localPoint = RotatePoint(worldPoint, transform.Position, -transform.Rotation);

            bool isInside = false;
            int j = Vertices.Length - 1;
            for (int i = 0; i < Vertices.Length; i++)
            {
                if (Vertices[i].Y < localPoint.Y && Vertices[j].Y >= localPoint.Y ||
                    Vertices[j].Y < localPoint.Y && Vertices[i].Y >= localPoint.Y)
                {
                    if (Vertices[i].X + (localPoint.Y - Vertices[i].Y) / (Vertices[j].Y - Vertices[i].Y) * (Vertices[j].X - Vertices[i].X) < localPoint.X)
                    {
                        isInside = !isInside;
                    }
                }
                j = i;
            }
            return isInside;
        }

        private PointF RotatePoint(PointF p, PointF pivot, float angleDegrees)
        {
            double angle = angleDegrees * (Math.PI / 180.0);
            float sin = (float)Math.Sin(angle);
            float cos = (float)Math.Cos(angle);


            float x = p.X - pivot.X;
            float y = p.Y - pivot.Y;

            float xnew = x * cos - y * sin;
            float ynew = x * sin + y * cos;

            return new PointF(xnew, ynew);
        }

        public void Start() { }
        public void Update(float deltaTime) { }
        public void Destroy() { }
    }
}
