using System;
namespace EpsilonEngine
{
    public abstract class GameObjectBase
    {
        public readonly GameInterfaceBase gameInterface = null;
        public readonly GameBase game = null;
        public readonly SceneBase scene = null;
        public GameObjectBase(SceneBase scene)
        {
            if (scene is null)
            {
                throw new NullReferenceException();
            }
            this.scene = scene;
            if(scene.game is null)
            {
                throw new NullReferenceException();
            }
            game = scene.game;
            if(scene.gameInterface is null)
            {
                throw new NullReferenceException();
            }
            gameInterface = scene.gameInterface;
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