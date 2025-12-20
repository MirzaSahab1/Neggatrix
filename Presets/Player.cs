using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Neggatrix.Core;
using Neggatrix.Components;

namespace Neggatrix.Presets
{
    public class Player : GameObject
    {
        public float Health { get; set; }
        public Player()
        {
            Health = 100.0f;
            var transform = AddComponent<Transform>();
            transform.Position = new PointF(150f, 100f);

            var renderer = AddComponent<Renderer>();
            renderer.BGColor = Color.Red;
            renderer.Size = new SizeF(50f, 50f);

            var boxCollider = AddComponent<BoxCollider>();
            boxCollider.Size = renderer.Size;

            var physicsBody = AddComponent<PhysicsBody>();

            var camera = AddComponent<Camera>();
        }

        public void TakeDamage(float amount)
        {
            Health -= amount;
            if (Health < 0) Health = 0;
        }
        public void PowerUp(float amount)
        {
            Health += amount;
            if (Health > 100) Health = 100;
        }
    }
}
