using System.Collections.Generic;

namespace EpsilonEngine
{
    public abstract class InputDriver
    {
        public InputDriver(GameInterface game)
        {

        }
        public abstract bool GetNumLockState();
        public abstract bool GetCapsLockState();
        public abstract List<KeyCode> GetPressedKeys();
        public abstract bool IsKeyPressed(KeyCode targetKeyCode);
        public virtual void Initialize()
        {

        }
        public virtual void Update()
        {

        }
    }
}