using System;

namespace EpsilonEngine
{
    public abstract class Component : Updatable
    {
        public readonly GameObject gameObject;
        public readonly Game game;
        public readonly Machine machine;

        public Component(GameObject gameObject)
        {
            if (gameObject is null)
            {
                throw new NullReferenceException();
            }
            this.gameObject = gameObject;
            if (gameObject.game is null)
            {
                throw new NullReferenceException();
            }
            game = gameObject.game;
            if (game.machine is null)
            {
                throw new NullReferenceException();
            }
            machine = game.machine;
        }
    }
}