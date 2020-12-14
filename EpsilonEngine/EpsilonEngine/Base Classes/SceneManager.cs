using System;
namespace EpsilonEngine
{
    public abstract class SceneManager
    {
        public readonly GameInterface gameInterface = null;
        public readonly Game game = null;
        public readonly Scene scene = null;
        public SceneManager(Scene scene)
        {
            if (scene is null)
            {
                throw new NullReferenceException();
            }
            this.scene = scene;
            if (scene.game is null)
            {
                throw new NullReferenceException();
            }
            game = scene.game;
            if (scene.gameInterface is null)
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