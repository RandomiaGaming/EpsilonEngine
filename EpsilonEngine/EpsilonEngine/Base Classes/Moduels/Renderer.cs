using System;
namespace EpsilonEngine
{
    public abstract class SceneRenderer
    {
        public readonly Scene scene;
        public SceneRenderer(Scene scene)
        {
            if(scene == null)
            {
                throw new NullReferenceException();
            }
            this.scene = scene;
        }
        public virtual Texture Render()
        {
            throw new NotSupportedException();
        }
        public virtual void Update()
        {

        }
        public virtual void Initialize()
        {

        }
    }
}
