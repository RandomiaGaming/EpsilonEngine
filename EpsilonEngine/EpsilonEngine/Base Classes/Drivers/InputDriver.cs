using System;
using System.Collections.Generic;

namespace EpsilonEngine
{
    public abstract class InputDriver : GameManager
    {
        public InputDriver(Game game) : base(game)
        {

        }
        public abstract bool GetNumLockState();
        public abstract bool GetCapsLockState();
        public abstract List<KeyCode> GetPressedKeys();
        public abstract bool IsKeyPressed(KeyCode targetKeyCode);
    }
}