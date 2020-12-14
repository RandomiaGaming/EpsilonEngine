using System;
using System.Collections.Generic;
namespace EpsilonEngine
{
    public abstract class GameInterface
    {
        public Game game { get; protected set; } = null;
        public GameInterface()
        {

        }
        public abstract List<KeyboardState> GetKeyboardStates();
        public abstract KeyboardState GetPrimaryKeyboardState();
        public abstract List<MouseState> GetMouseStates();
        public abstract MouseState GetPrimaryMouseState();
        public Vector2Int viewPortRect { get { return GetViewPortRect(); } private set { } }
        public abstract Vector2Int GetViewPortRect();
        public abstract void Draw(Texture frame);
        public abstract void Run(Game game);
    }
}
