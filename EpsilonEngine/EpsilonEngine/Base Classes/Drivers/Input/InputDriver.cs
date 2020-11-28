using System.Collections.Generic;
using System;
namespace EpsilonEngine
{
    public abstract class InputDriver
    {
        public readonly GameInterface gameInterface = null;
        public InputDriver(GameInterface gameInterface)
        {
            if(gameInterface is null)
            {
                throw new NullReferenceException();
            }
            this.gameInterface = gameInterface;
        }
        public abstract List<KeyboardState> GetKeyboardStates();
        public abstract KeyboardState GetPrimaryKeyboardState();
        public abstract List<MouseState> GetMouseStates();
        public abstract MouseState GetPrimaryMouseState();
        public virtual void Initialize()
        {

        }
        public virtual void Update()
        {

        }
    }
}