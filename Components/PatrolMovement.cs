using Neggatrix.Core;
using Neggatrix.Interfaces;
using Neggatrix.Presets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neggatrix.Components
{
    public class PatrolMovement : IMovement, IComponent
    {
        public GameObject Owner {  get; set; }

        public void Move()
        {

        }

        public void Start() { }
        public void Update(float deltaTime) 
        {
            var collider = Owner.GetComponent<PolygonCollider>();
            Player? player = Owner.Scene?.Objects
            .OfType<Player>()
            .FirstOrDefault();

            if (player != null && collider != null)
            {
                var playerPos = player.GetComponent<Transform>().Position;

                if (collider.IsPointInside(playerPos))
                {
                    
                    player.renderer.FillColor = Color.Red;
                }
            }
        }
        public void Destroy() { }
    }
}
