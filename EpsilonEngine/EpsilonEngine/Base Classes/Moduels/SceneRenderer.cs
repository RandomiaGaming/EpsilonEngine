using System;
namespace EpsilonEngine
{
    public abstract class SceneRenderer
    {
        public readonly GameInterface gameInterface = null;
        public readonly Game game = null;
        public readonly Scene scene = null;
        public SceneRenderer(Scene scene)
        {
            if(scene is null)
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
        public abstract Texture Render();
        public virtual void Update()
        {

        }
        public virtual void Initialize()
        {

        }
    }
}
