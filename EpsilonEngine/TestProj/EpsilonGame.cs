using EpsilonEngine.Modules.Renderers.Pixel2D;
using EpsilonEngine.Modules.Drivers.MonoGame;
using EpsilonEngine.Modules.Physics.Pixel2D;
using EpsilonEngine.Modules.AssetCodecs.PNG;
using System.Collections.Generic;
namespace EpsilonEngine.Projects.TestProj
{
    public class EpsilonGame : Game
    {
        public EpsilonGame()
        {
            assetManager = new AssetManager(this);
            assetManager.codecs.Add(new PNGAssetCodec());
            assetManager.Initialize();
            assetManager.LoadAssets();

            inputDriver = new MonoGameInputDriver(this);
            graphicsDriver = new MonoGameGraphicsDriver(this);
            renderer = new PixelRenderer2D(this);

            for (int i = 0; i < 16; i++)
            {
                GameObject ground = new GameObject(this)
                {
                    name = $"Ground ({i}, 0)",
                    position = new Vector2Int(i * 16, 0),
                    components = new List<Component>()
                };

                PixelGraphic2D groundGraphic = new PixelGraphic2D(ground)
                {
                    graphic = ((TextureAsset)assetManager.GetAsset("ground")).data
                };

                Collider groundCollider = new Collider(ground)
                {
                    offset = Vector2Int.Zero,
                    sideCollision = SideInfo.True,
                    collisions = new List<Collision>(),
                    overlaps = new List<Overlap>(),
                    shape = new Rectangle(Vector2Int.Zero, new Vector2Int(16, 16))
                };

                ground.components.Add(groundGraphic);
                ground.components.Add(groundCollider);
                ground.components.Add(groundGraphic);

                gameObjects.Add(ground);
            }

            GameObject player = new GameObject(this)
            {
                name = $"Player)",
                position = new Vector2Int(128, 72),
                components = new List<Component>()
            };

            PixelGraphic2D playerGraphic = new PixelGraphic2D(player)
            {
                graphic = ((TextureAsset)assetManager.GetAsset("player")).data,
            };

            Collider playerCollider = new Collider(player)
            {
                offset = new Vector2Int(4, 0),
                sideCollision = SideInfo.True,
                collisions = new List<Collision>(),
                overlaps = new List<Overlap>(),
                shape = new Rectangle(Vector2Int.Zero, new Vector2Int(8, 24))
            };

            Rigidbody playerRigidbody = new Rigidbody(player);

            Player playerComponent = new Player(player);

            player.components.Add(playerCollider);
            player.components.Add(playerRigidbody);
            player.components.Add(playerComponent);
            player.components.Add(playerGraphic);

            gameObjects.Add(player);
        }
    }
}
