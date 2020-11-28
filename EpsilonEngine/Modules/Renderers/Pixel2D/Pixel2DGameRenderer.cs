using System.Collections.Generic;

namespace EpsilonEngine.Modules.Renderers.Pixel2D
{
    public class Pixel2DGameRenderer : GameRenderer
    {
        public Pixel2DGameRenderer(Game game) : base(game)
        {

        }
        public override Texture Render()
        {
            int width = 0;
            int height = 0;
            List<Texture> sceneRenders = new List<Texture>();
            foreach (Scene scene in game.scenes)
            {
                Texture sceneRender = scene.renderer.Render();
                if (sceneRender.width > width)
                {
                    width = sceneRender.width;
                }
                if (sceneRender.height > height)
                {
                    height = sceneRender.height;
                }
                sceneRenders.Add(sceneRender);
            }
            Texture output = new Texture(width, height);
            foreach (Texture sceneRender in sceneRenders)
            {
                output.Blitz(sceneRender, 0, 0);
            }
            return output;
        }
    }
}
