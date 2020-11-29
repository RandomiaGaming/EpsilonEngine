using System;
using EpsilonEngine.Modules.MonoGame;
using EpsilonEngine.Modules.Pixel2D;
using System.Collections.Generic;
using EpsilonEngine.Modules.PNGCodec;
using EpsilonEngine;
using DontMelt;

public static class Program
{
    [STAThread]
    public static void Main()
    {
        GameInterface gameInterface = new MonoGameInterface();
        gameInterface.inputDriver = new MonoGameInputDriver(gameInterface);
        gameInterface.graphicsDriver = new MonoGameGraphicsDriver(gameInterface);

        Game game = new Game(gameInterface);

        game.assetManager = new AssetManager(game);
        game.assetManager.RegisterCodec(new PNGAssetCodec(game.assetManager));
        game.assetManager.LoadAssets();
        game.renderer = new Pixel2DGameRenderer(game);

        Scene scene = new Scene(game);

        scene.renderer = new Pixel2DSceneRenderer(scene);

        for (int i = 0; i < 16; i++)
        {
            GameObject ground = new GameObject(scene);

            Pixel2DGraphic groundGraphic = new Pixel2DGraphic(ground)
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

            ground.AddComponent(new Pixel2DTransform(ground, new Vector2Int(i * 16, 0)));
            ground.AddComponent(groundGraphic);
            ground.AddComponent(groundCollider);
            ground.AddComponent(groundGraphic);

            scene.InstantiateGameObject(ground);
        }

        GameObject player = new GameObject(scene);

        Pixel2DGraphic playerGraphic = new Pixel2DGraphic(player);

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

        player.AddComponent(new Pixel2DTransform(player, new Vector2Int(128, 72)));
        player.AddComponent(playerCollider);
        player.AddComponent(playerRigidbody);
        player.AddComponent(playerComponent);
        player.AddComponent(playerGraphic);

        scene.InstantiateGameObject(player);

        game.LoadScene(scene);

        gameInterface.Run(game);
    }
}