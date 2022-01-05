using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonEngine
{
    public abstract class Renderable
    {
        private Microsoft.Xna.Framework.Graphics.Texture2D _source;
        protected Microsoft.Xna.Framework.Graphics.Texture2D source
        {
            get
            {
                return _source;
            }
            set
            {
                if (value is null)
                {
                    throw new Exception("source cannot be null.");
                }
                if(value.GraphicsDevice != game.)
                _source = value;
            }
        }
        public Game game
        {
            get
            {
                if (!destroyed)
                {
                    throw new Exception("GameManager has been destroyed.");
                }
                return _game;
            }
        }
        private Game _game = null;
        private Renderable()
        {
            source = null;
        }
        protected Renderable(Microsoft.Xna.Framework.Graphics.Texture2D source)
        {
            _source = source;
        }
    }
}
