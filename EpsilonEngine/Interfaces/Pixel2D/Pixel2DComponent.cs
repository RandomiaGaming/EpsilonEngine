using System;

namespace EpsilonEngine.Modules.Pixel2D
{
    public class Pixel2DComponent : ComponentBase
    {
        public readonly Pixel2DScene pixel2DScene = null;
        public readonly Pixel2DGameObject pixel2DGameObject = null;
        public Pixel2DComponent(Pixel2DGameObject pixel2DGameObject) : base(pixel2DGameObject)
        {
            if (pixel2DGameObject is null)
            {
                throw new NullReferenceException();
            }
            this.pixel2DGameObject = pixel2DGameObject;
            if(pixel2DGameObject.pixel2DScene is null)
            {
                throw new NullReferenceException();
            }
            pixel2DScene = pixel2DGameObject.pixel2DScene;
        }
    }
}
