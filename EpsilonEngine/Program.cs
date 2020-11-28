using System;
using EpsilonEngine.Drivers.MonoGame;
using EpsilonEngine.Modules.Physics.Pixel2D;
using EpsilonEngine.Modules.Renderers.Pixel2D;
using System.Collections.Generic;
using EpsilonEngine.Modules.AssetCodecs.PNG;
namespace EpsilonEngine.Projects.TestProject
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            GameInterface gameInterface = new MonoGameInterface();

            Game game = new Game(gameInterface);

            gameInterface.game = game;
            gameInterface.inputDriver = new MonoGameInputDriver(gameInterface);
            gameInterface.graphicsDriver = new MonoGameGraphicsDriver(gameInterface);

            game.gameInterface = gameInterface;
            game.assetManager = new AssetManager(game);
            game.assetManager.RegisterCodec(new PNGAssetCodec(game.assetManager));
            game.assetManager.LoadAssets();
            game.renderer = new Pixel2DGameRenderer(game);

            Scene scene = new Scene(game);

            scene.renderer = new Pixel2DSceneRenderer(scene);

            for (int i = 0; i < 16; i++)
            {
                GameObject ground = new GameObject(scene)
                {
                    name = $"Ground ({i}, 0)",
                    position = new Vector2Int(i * 16, 0),
                    components = new List<Component>()
                };

                PixelGraphic2D groundGraphic = new PixelGraphic2D(ground)
                {
                    graphic = ((PNGAsset)game.assetManager.GetAsset("Ground.png")).data
                };

                Collider groundCollider = new Collider(ground)
                {
                    offset = Vector2Int.Zero,
                    sideCollision = SideInfo.True,
                    collisions = new List<Collision>(),
                    overlaps = new List<Overlap>(),
                    shape = new RectangleInt(Vector2Int.Zero, new Vector2Int(16, 16))
                };

                ground.components.Add(groundGraphic);
                ground.components.Add(groundCollider);
                ground.components.Add(groundGraphic);

                scene.gameObjects.Add(ground);
            }

            GameObject player = new GameObject(scene)
            {
                name = "Player",
                position = new Vector2Int(128, 72),
                components = new List<Component>()
            };

            PixelGraphic2D playerGraphic = new PixelGraphic2D(player);

            Collider playerCollider = new Collider(player)
            {
                offset = new Vector2Int(4, 0),
                sideCollision = SideInfo.True,
                collisions = new List<Collision>(),
                overlaps = new List<Overlap>(),
                shape = new RectangleInt(Vector2Int.Zero, new Vector2Int(8, 24))
            };

            Rigidbody playerRigidbody = new Rigidbody(player);

            Player playerComponent = new Player(player);

            player.components.Add(playerCollider);
            player.components.Add(playerRigidbody);
            player.components.Add(playerComponent);
            player.components.Add(playerGraphic);

            scene.gameObjects.Add(player);

            game.scenes.Add(scene);

            gameInterface.Run();
        }
    }
}