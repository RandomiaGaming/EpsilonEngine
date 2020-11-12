using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
namespace EpsilonEngine.Modules.Drivers.MonoGame
{
    public class MonoGameInputDriver : InputDriver
    {
        private bool capsLockState;
        private bool numLockState;
        private List<KeyCode> pressedKeys = new List<KeyCode>();
        public MonoGameInputDriver(Game game) : base(game)
        {

        }
        public override bool GetCapsLockState()
        {
            return capsLockState;
        }

        public override bool GetNumLockState()
        {
            return numLockState;
        }
        public override void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            pressedKeys = new List<KeyCode>();
            foreach (Keys key in keyboardState.GetPressedKeys())
            {
                switch (key)
                {
                    case Keys.A:
                        pressedKeys.Add(KeyCode.A);
                        break;
                    case Keys.D:
                        pressedKeys.Add(KeyCode.D);
                        break;
                    case Keys.Space:
                        pressedKeys.Add(KeyCode.Space);
                        break;
                }
            }
            capsLockState = keyboardState.CapsLock;
            numLockState = keyboardState.NumLock;
        }
        public override List<KeyCode> GetPressedKeys()
        {
            return pressedKeys;
        }
        public override bool IsKeyPressed(KeyCode targetKeyCode)
        {
            for (int i = 0; i < pressedKeys.Count; i++)
            {
                if (pressedKeys[i] == targetKeyCode)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
