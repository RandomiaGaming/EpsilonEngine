using System;

namespace EpsilonEngine.Modules.Pixel2D
{
    public class Pixel2DSceneManager : SceneManagerBase
    {
        public readonly Pixel2DScene pixel2DScene = null;
        public Pixel2DSceneManager(Pixel2DScene pixel2DScene) : base(pixel2DScene)
        {
            if (pixel2DScene is null)
            {
                throw new NullReferenceException();
            }
            this.pixel2DScene = pixel2DScene;
        }
    }
}
