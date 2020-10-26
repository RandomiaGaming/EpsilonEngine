using System;
using System.Collections.Generic;
namespace EpsilonEngine
{
    public class GameObjectUpdatePacket
    {
        public Scene parent = null;
        public TimeSpan deltaTime = new TimeSpan(0);
        public TimeSpan elapsedTime = new TimeSpan(0);
        public List<Key> pressedKeys = new List<Key>();
        public bool numLock = true;
        public bool capsLock = false;
        public bool scrollLock = false;
        public Point mousePosition = Point.Zero;
        public List<MouseButton> pressedButtons = new List<MouseButton>();
        public int scrollWheelDelta = 0;
        public Point viewPortSize = new Point(0, 0);
    }
}