using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neggatrix.Core;
using Neggatrix.Components;

namespace Neggatrix.Presets
{
    public class Block : GameObject
    {
        public Transform transform;
        public Renderer renderer;
        public BoxCollider collider;

        public Block(PointF position, Color color, SizeF size)
        {
            transform = AddComponent<Transform>();
            transform.Position = position;

            renderer = AddComponent<Renderer>();
            renderer.BGColor = color;
            renderer.Size = size;

            collider = AddComponent<BoxCollider>();
            collider.Size = size;
        }
    }
}
