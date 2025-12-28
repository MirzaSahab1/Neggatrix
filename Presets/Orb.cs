using Neggatrix.Core;
using Neggatrix.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neggatrix.Presets
{
    public class Orb : GameObject
    {
        public Transform transform;
        public Renderer renderer;
        public BoxCollider collider;

        public Orb(PointF position, Color color, SizeF size)
        {
            transform = AddComponent<Transform>();
            transform.Position = position;

            renderer = AddComponent<Renderer>();
            if (color == Color.Red) { renderer.Sprite = Properties.Resources.redOrb; Name = "RedOrb"; }
            else if (color == Color.Green) { renderer.Sprite = Properties.Resources.greenOrb; Name = "GreenOrb"; }
            else if (color == Color.Blue) { renderer.Sprite = Properties.Resources.blueOrb; Name = "BlueOrb"; }
            else { renderer.BGColor = color; Name = "Orb"; }
            renderer.Size = size;

            collider = AddComponent<BoxCollider>();
            collider.Size = size;
            collider.IsTrigger = true;
        }
    }
}
