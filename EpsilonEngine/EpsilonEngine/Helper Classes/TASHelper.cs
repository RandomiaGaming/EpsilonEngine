using EpsilonEngine;
using System.Collections.Generic;

namespace Epsilon
{
    public class TASHelper : Updatable
    {
        List<List<KeyCode>> TASData = new List<List<KeyCode>>();
        private int currentIndex = 0;
        public TASHelper(Game game) : base(game)
        {

        }
        public override void Initialize()
        {
            TASData = new List<List<KeyCode>>();
        }

        public override void Tick()
        {
            if (game.inputDriver.GetCapsLockState())
            {
                TASData.Add(game.inputDriver.GetPressedKeys());
            }
            else
            {
                if (TASData.Count > 0)
                {
                    if (currentIndex >= TASData.Count)
                    {
                        currentIndex = 0;
                    }
                    currentIndex++;
                }
            }
        }
    }
}
