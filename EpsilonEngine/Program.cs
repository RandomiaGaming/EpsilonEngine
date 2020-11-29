using System;
using EpsilonEngine.Modules.MonoGame;
using EpsilonEngine.Modules.Pixel2D;
using System.Collections.Generic;
using EpsilonEngine.Modules.PNGCodec;
using EpsilonEngine;
using EpsilonEngine.Projects.DontMelt;

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
        game.renderer = new FlattenGameRenderer(game);

        Pixel2DScene mainScene = new Pixel2DScene(game);

        mainScene.renderer = new Pixel2DSceneRenderer(mainScene);

        for (int i = 0; i < 16; i++)
        {
            Pixel2DGameObject ground = new Pixel2DGameObject(mainScene, new Vector2Int(i * 16, 0), ((PNGAsset)game.assetManager.GetAsset("Ground.png")).data);

            Pixel2DCollider groundCollider = new Pixel2DCollider(ground)
            {
                offset = Vector2Int.Zero,
                sideCollision = SideInfo.True,
                collisions = new List<Pixel2DCollision>(),
                overlaps = new List<Pixel2DOverlap>(),
                shape = new RectangleInt(Vector2Int.Zero, new Vector2Int(16, 16))
            };

            ground.AddComponent(groundCollider);
            mainScene.InstantiateGameObject(ground);
        }

        Pixel2DGameObject player = new Pixel2DGameObject(mainScene, new Vector2Int(128, 72), ((PNGAsset)game.assetManager.GetAsset("Ground.png")).data);

        Pixel2DCollider playerCollider = new Pixel2DCollider(player)
        {
            offset = new Vector2Int(4, 0),
            sideCollision = SideInfo.True,
            collisions = new List<Pixel2DCollision>(),
            overlaps = new List<Pixel2DOverlap>(),
            shape = new RectangleInt(Vector2Int.Zero, new Vector2Int(8, 24))
        };

        Pixel2DRigidbody playerRigidbody = new Pixel2DRigidbody(player);

        Player playerComponent = new Player(player);

        player.AddComponent(playerCollider);
        player.AddComponent(playerRigidbody);
        player.AddComponent(playerComponent);

        mainScene.InstantiateGameObject(player);

        game.LoadScene(mainScene);

        gameInterface.Run(game);
    }
}