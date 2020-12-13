using System;
using EpsilonEngine.Interfaces.MonoGame;
using EpsilonEngine.Modules.Pixel2D;
using System.Collections.Generic;
using EpsilonEngine.Modules.PNGCodec;
using EpsilonEngine;

namespace DontMelt
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            AssetHelper.LoadCodecs();
            AssetHelper.LoadAssets();

            GameInterfaceBase gameInterface = new MonoGameInterface();

            DefaultGame game = new DefaultGame(gameInterface);

            Pixel2DScene mainScene = new Pixel2DScene(game);

            for (int i = 0; i < 16; i++)
            {
                Pixel2DGameObject ground = new Pixel2DGameObject(mainScene);
                ground.texture = ((PNGAsset)AssetHelper.GetAsset("Ground.png")).data;
                ground.position = new Vector2Int(i * 16, 0);

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

            Pixel2DGameObject player = new Pixel2DGameObject(mainScene)
            {
                position = new Vector2Int(128, 72)
            };

            Pixel2DCollider playerCollider = new Pixel2DCollider(player)
            {
                offset = new Vector2Int(0, 0),
                sideCollision = SideInfo.True,
                collisions = new List<Pixel2DCollision>(),
                overlaps = new List<Pixel2DOverlap>(),
                shape = new RectangleInt(new Vector2Int(2, 2), new Vector2Int(14, 14))
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
}