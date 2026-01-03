using Neggatrix.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neggatrix.Presets;

namespace Neggatrix.Core
{
    public class LevelManager
    {
        private Game _game;
        public ILevel? currentLevel;
        public LevelManager(Game game)
        {
            _game = game;
        }

        public void LoadLevel(ILevel level)
        {
            currentLevel = level;
            _game.Objects.RemoveAll(obj => !(obj is Player));

            level.Build(_game);
        }
    }
}
