using EpsilonEngine.Modules.Physics.Pixel2D;
namespace EpsilonEngine.Modules.Renderers.Pixel2D
{
    public class PixelRenderer2D : Renderer
    {
        public Vector2Int cameraPosition = Vector2Int.Zero;
        public PixelRenderer2D(Game game) : base(game)
        {

        }

        public override Texture Render()
        {
            Texture frame = new Texture(256, 144, new Color(255, 255, 150));

            foreach (GameObject g in game.gameObjects)
            {
                foreach (PixelGraphic2D pg2d in g.GetComponentsOfType(typeof(PixelGraphic2D)))
                {
                    frame.Blitz(pg2d.graphic, g.position.x + pg2d.offset.x - cameraPosition.x, g.position.y + pg2d.offset.y - cameraPosition.y);
                }
            }

            if (game.inputDriver.GetCapsLockState())
            {
                foreach (GameObject g in game.gameObjects)
                {
                    foreach (Collider pc2d in g.GetComponentsOfType(typeof(Collider)))
                    {
                        frame.FillBlitz(new Color(0, 250, 255, 150), g.position.x + pc2d.offset.x - cameraPosition.x - pc2d.shape.min.x, g.position.y + pc2d.offset.y - cameraPosition.y - pc2d.shape.min.y, pc2d.shape.max.x - pc2d.shape.min.x, pc2d.shape.max.y - pc2d.shape.min.y);
                    }
                }
            }
            
            return frame;
        }
    }
}
