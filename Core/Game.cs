using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neggatrix.Core
{
    public class Game
    {
        public List<GameObject> Objects = new List<GameObject>();

        public void AddObject(GameObject obj)
        {
            obj.Scene = this;
            Objects.Add(obj);
        }
        public void Update(float deltaTime)
        {
            foreach (var go in Objects)
            {
                go.Update(deltaTime);
            }
        }
        public void Render(Graphics g)
        {
            foreach (var go in Objects)
            {
                go.Render(g);
            }
        }
    }
}
