using System;
namespace EpsilonEngine
{
    public abstract class ComponentBase
    {
        public readonly GameInterfaceBase gameInterface = null;
        public readonly GameBase game = null;
        public readonly SceneBase scene = null;
        public readonly GameObjectBase gameObject = null;
        public ComponentBase(GameObjectBase gameObject)
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
        public virtual void Cleanup()
        {

        }
    }
}