using System;
using EpsilonEngine.Interfaces.MonoGame;
using System.Collections.Generic;
using EpsilonEngine;

namespace DontMelt
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            GameInterface gameInterface = new MonoGameInterface();

            Game game = new Game(gameInterface);

            game.Initialize();

            Scene mainScene = new Scene(game);

            for (int i = 0; i < 16; i++)
            {
                GameObject ground = new GameObject(mainScene);
                ground.texture = ((TextureAsset)game.assetManager.GetAssetByName("Ground")).data;
                ground.position = new Vector2Int(i * 16, 0);

                Collider groundCollider = new Collider(ground)
                {
                    offset = Vector2Int.Zero,
                    sideCollision = SideInfo.True,
                    collisions = new List<Collision>(),
                    overlaps = new List<Overlap>(),
                    shape = new RectangleInt(Vector2Int.Zero, new Vector2Int(16, 16))
                };

                ground.AddComponent(groundCollider);
                mainScene.InstantiateGameObject(ground);
            }

            GameObject player = new GameObject(mainScene)
            {
                position = new Vector2Int(128, 72)
            };

            Collider playerCollider = new Collider(player)
            {
                offset = new Vector2Int(0, 0),
                sideCollision = SideInfo.True,
                collisions = new List<Collision>(),
                overlaps = new List<Overlap>(),
                shape = new RectangleInt(new Vector2Int(2, 2), new Vector2Int(14, 14))
            };

            Rigidbody playerRigidbody = new Rigidbody(player);

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