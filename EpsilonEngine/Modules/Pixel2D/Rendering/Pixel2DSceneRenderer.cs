using System;
namespace EpsilonEngine.Modules.Pixel2D
{
    public class Pixel2DSceneRenderer : SceneRenderer
    {
        public Vector2Int cameraPosition = Vector2Int.Zero;
        public readonly Pixel2DScene pixel2DScene = null;
        public Pixel2DSceneRenderer(Pixel2DScene pixel2DScene) : base(pixel2DScene)
        {
            if (pixel2DScene is null)
            {
                throw new NullReferenceException();
            }
            this.pixel2DScene = pixel2DScene;
        }
        public override Texture Render()
        {
            Texture frame = new Texture(256, 144, new Color(255, 255, 155, 255));

            foreach (Pixel2DGameObject pixel2DGameObject in pixel2DScene.GetPixel2DGameObjects())
            {
                if (pixel2DGameObject.texture is not null)
                {
                    TextureHelper.Blitz(pixel2DGameObject.texture, frame, new Vector2Int(pixel2DGameObject.position.x - cameraPosition.x, pixel2DGameObject.position.y - cameraPosition.y));
                }
            }

            return frame;
        }
    }
}
