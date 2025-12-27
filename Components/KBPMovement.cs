using Neggatrix.Common;
using Neggatrix.Components;
using Neggatrix.Core;
using Neggatrix.Interfaces;
using Neggatrix.Presets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Neggatrix.Components
{
    public class KBPMovement : IComponent, IMovement
    {
        public GameObject Owner { get; set; }

        public float MoveForce { get; set; }
        public float JumpForce { get; set; }

        public KBPMovement() 
        {
            Owner = null!;
            MoveForce = 50f;
            JumpForce = 1000f;
        }

        public void Start() { }
        public void Update(float deltaTime) { }
        public void Move() 
        {
            var transform = Owner.GetComponent<Transform>();
            var physics = Owner.GetComponent<PhysicsBody>();
            var camera = Owner.GetComponent<Camera>();

            if (Input.IsPressed(Keys.W) )
            {
                physics.AddForce(new PointF(0, -JumpForce));

            }
            if (Input.IsDown(Keys.A))
            {
                physics.AddForce(new PointF(-MoveForce, 0));
            }
            if (Input.IsDown(Keys.D))
            {
                physics.AddForce(new PointF(MoveForce, 0));
            }
        }
        public void Destroy() { }
    }
}
