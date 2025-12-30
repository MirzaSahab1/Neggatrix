using Neggatrix.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neggatrix.Components;

namespace Neggatrix.Presets
{
    public class ScorePoint : GameObject
    {
        public Transform transform;
        public PolygonRenderer renderer;
        public BoxCollider collider;

        public int Score { get; private set; }

        public ScorePoint(PointF position, Color color, int score)
        {
            Name = "ScorePoint";
            Score = score;

            transform = AddComponent<Transform>();
            transform.Position = position;

            renderer = AddComponent<PolygonRenderer>();
            renderer.FillColor = color;
            renderer.Vertices = new PointF[]
            {
                new PointF(0, -20),
                new PointF(12, 0),
                new PointF(0, 20),
                new PointF(-12, 0)
            };
            collider = AddComponent<BoxCollider>();
            collider.Size = renderer.Size;
            collider.IsTrigger = true;
        }

    }
}
