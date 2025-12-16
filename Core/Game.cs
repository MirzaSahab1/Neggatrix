using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neggatrix.Core
{
    public class Game
    {
        private List<GameObject> Objects = new List<GameObject>();

        public void AddObject(GameObject obj)
        {
            Objects.Add(obj);
        }
    }
}
