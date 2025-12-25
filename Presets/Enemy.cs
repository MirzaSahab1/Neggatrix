using Neggatrix.Components;
using Neggatrix.Core;
using Neggatrix.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neggatrix.Presets
{
    public class Enemy : GameObject
    {
        public Transform transform;
        public PolygonRenderer renderer;
        public PolygonCollider collider;
        public IMovement movement;

        public Enemy(PointF position, Color color, SizeF size, IMovement movement)
        {
            transform = AddComponent<Transform>();
            transform.Position = position;

            renderer = AddComponent<PolygonRenderer>();
            renderer.FillColor = Color.FromArgb(50, 255, 0, 0);
            renderer.Vertices = new PointF[]
            {
                new PointF(-10, 0),    // Top Left (Lens)
                new PointF(10, 0),     // Top Right (Lens)
                new PointF(150, 400),  // Bottom Right (Wide end)
                new PointF(-150, 400)
            };

            collider = AddComponent<PolygonCollider>();
            collider.Vertices = renderer.Vertices;

            this.movement = movement;
        }
    }
}
