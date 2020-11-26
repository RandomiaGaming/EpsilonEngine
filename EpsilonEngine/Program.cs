using System;
using EpsilonEngine.Drivers.MonoGame;
using EpsilonEngine;
using EpsilonEngine.Modules.Physics.Pixel2D;
using EpsilonEngine.Projects.TestProj;
using EpsilonEngine.Modules.Renderers.Pixel2D;
using System.Collections.Generic;
using EpsilonEngine.Modules.AssetCodecs.PNG;

public static class Program
{
    [STAThread]
    public static void Main()
    {
        GameInterface gInterface = new GameInterface();

        Game game = new Game(gInterface);

        gInterface.game = game;

        gInterface.inputDriver = new MonoGameInputDriver(gInterface);
        gInterface.graphicsDriver = new MonoGameGraphicsDriver(gInterface);

        game.gInterface = gInterface;
        game.assetManager = new AssetManager(game);
        game.assetManager.codecs.Add(new PNGAssetCodec());
        game.assetManager.Initialize();
        game.assetManager.LoadAssets();

        Scene scene = new Scene(game);

        scene.renderer = new PixelRenderer2D(scene);

        for (int i = 0; i < 16; i++)
        {
            GameObject ground = new GameObject(game)
            {
                name = $"Ground ({i}, 0)",
                position = new Vector2Int(i * 16, 0),
                components = new List<Component>()
            };

            PixelGraphic2D groundGraphic = new PixelGraphic2D(ground)
            {
                graphic = ((TextureAsset)game.assetManager.GetAsset("ground")).data
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

            scene.gameObjects.Add(ground);
        }

        GameObject player = new GameObject(game)
        {
            name = $"Player)",
            position = new Vector2Int(128, 72),
            components = new List<Component>()
        };

        PixelGraphic2D playerGraphic = new PixelGraphic2D(player)
        {
            graphic = ((TextureAsset)game.assetManager.GetAsset("player")).data,
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

        scene.gameObjects.Add(player);

        game.scenes.Add(scene);

        game.Initialize();
    }
}