namespace EpsilonEngine.Modules.Renderers.Pixel2D
{
    public class Pixel2DSceneRenderer : SceneRenderer
    {
        public Vector2Int cameraPosition = Vector2Int.Zero;
        public Pixel2DSceneRenderer(Scene scene) : base(scene)
        {

        }
        public override Texture Render()
        {
            Texture frame = new Texture(256, 144, new Color(255, 255, 155, 255));

            foreach (GameObject g in scene.gameObjects)
            {
                foreach (PixelGraphic2D pg2d in g.GetComponentsOfType(typeof(PixelGraphic2D)))
                {
                    frame.Blitz(pg2d.graphic, g.position.x + pg2d.offset.x - cameraPosition.x, g.position.y + pg2d.offset.y - cameraPosition.y);
                }
            }
            
            return frame;
        }
    }
}
