using Neggatrix.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neggatrix.Core
{
    public class LevelManager
    {
        private Game _game;

        public LevelManager(Game game)
        {
            _game = game;
        }

        public void LoadLevel(ILevel level)
        {
            _game.Objects.Clear();

            level.Build(_game);
        }
    }
}
