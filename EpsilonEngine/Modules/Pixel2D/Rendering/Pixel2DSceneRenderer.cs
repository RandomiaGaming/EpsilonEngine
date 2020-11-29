namespace EpsilonEngine.Modules.Pixel2D
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

            foreach (GameObject g in scene.GetGameObjects())
            {
                foreach (Pixel2DGraphic pg2d in g.GetComponents<Pixel2DGraphic>())
                {
                    if (pg2d.graphic != null)
                    {
                        TextureHelper.Blitz(pg2d.graphic, frame, new Vector2Int(g.GetComponent<Pixel2DTransform>().position.x + pg2d.offset.x - cameraPosition.x, g.GetComponent<Pixel2DTransform>().position.y + pg2d.offset.y - cameraPosition.y));
                    }
                }
            }

            return frame;
        }
    }
}
