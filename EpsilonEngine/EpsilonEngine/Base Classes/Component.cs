using System;
namespace EpsilonEngine
{
    public abstract class Component
    {
        public readonly GameInterface gameInterface = null;
        public readonly Game game = null;
        public readonly Scene scene = null;
        public readonly GameObject gameObject = null;
        public Component(GameObject gameObject)
        {
            if (gameObject is null)
            {
                throw new NullReferenceException();
            }
            this.gameObject = gameObject;
            if (gameObject.scene is null)
            {
                throw new NullReferenceException();
            }
            scene = gameObject.scene;
            if (gameObject.game is null)
            {
                throw new NullReferenceException();
            }
            game = gameObject.game;
            if (gameObject.gameInterface is null)
            {
                throw new NullReferenceException();
            }
            gameInterface = gameObject.gameInterface;
        }
        public virtual void Initialize()
        {

        }
        public virtual void Update()
        {

        }
    }
}