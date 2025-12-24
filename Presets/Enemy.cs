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
        public Renderer renderer;
        public BoxCollider collider;
        public IMovement movement;

        public Enemy(PointF position, Color color, SizeF size, IMovement movement)
        {
            transform = AddComponent<Transform>();
            transform.Position = position;

            renderer = AddComponent<Renderer>();
            renderer.BGColor = color;
            renderer.Size = size;

            collider = AddComponent<BoxCollider>();
            collider.Size = size;

            this.movement = movement;
        }
    }
}
