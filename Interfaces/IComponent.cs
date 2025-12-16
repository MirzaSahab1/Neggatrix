using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neggatrix.Core;

namespace Neggatrix.Interfaces
{
    public interface IComponent
    {
        GameObject Owner { get; set; }

        void Start();

        void Update();

        void Destroy();
    }
}
