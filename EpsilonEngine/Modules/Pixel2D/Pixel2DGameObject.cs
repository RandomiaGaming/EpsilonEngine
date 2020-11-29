using System;

namespace EpsilonEngine.Modules.Pixel2D
{
    public class Pixel2DGameObject : GameObject
    {
        public Vector2Int position = Vector2Int.Zero;
        public Texture texture = null;

        public readonly Pixel2DScene pixel2DScene = null;
        public Pixel2DGameObject(Pixel2DScene pixel2DScene) : base(pixel2DScene)
        {
            if(pixel2DScene is null)
            {
                throw new NullReferenceException();
            }
            this.pixel2DScene = pixel2DScene;
        }
        public Pixel2DGameObject(Pixel2DScene pixel2DScene, Vector2Int position) : base(pixel2DScene)
        {
            if (pixel2DScene is null)
            {
                throw new NullReferenceException();
            }
            this.pixel2DScene = pixel2DScene;
            this.position = position;
        }
        public Pixel2DGameObject(Pixel2DScene pixel2DScene, Texture texture) : base(pixel2DScene)
        {
            if (pixel2DScene is null)
            {
                throw new NullReferenceException();
            }
            this.pixel2DScene = pixel2DScene;
            this.texture = texture;
        }
        public Pixel2DGameObject(Pixel2DScene pixel2DScene, Vector2Int position, Texture texture) : base(pixel2DScene)
        {
            if (pixel2DScene is null)
            {
                throw new NullReferenceException();
            }
            this.pixel2DScene = pixel2DScene;
            this.position = position;
            this.texture = texture;
        }
    }
}
