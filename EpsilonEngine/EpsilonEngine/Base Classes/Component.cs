using System;

namespace EpsilonEngine
{
    public abstract class Component
    {
        public readonly GameObject gameObject;
        public readonly Game game;

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
        }

        public virtual void Initialize()
        {

        }
        public virtual void Update()
        {

        }
    }
}