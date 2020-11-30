using System;
using System.Collections.Generic;
namespace EpsilonEngine
{
    public abstract class GameInterfaceBase
    {
        public GameBase game { get; protected set; } = null;
        public GameInterfaceBase()
        {

        }
        public GameInterfaceBase(GameBase game)
        {
            if (game is null)
            {
                throw new NullReferenceException();
            }
            this.game = game;
        }
        public abstract List<KeyboardState> GetKeyboardStates();
        public abstract KeyboardState GetPrimaryKeyboardState();
        public abstract List<MouseState> GetMouseStates();
        public abstract MouseState GetPrimaryMouseState();
        public Vector2Int viewPortRect { get { return GetViewPortRect(); } private set { } }
        public abstract Vector2Int GetViewPortRect();
        public abstract void Draw(Texture frame);
        public abstract void Run(GameBase game);
        public abstract void Run();
    }
}
