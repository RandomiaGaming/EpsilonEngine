using System.Collections.Generic;
using System;
using System.Reflection;
using DontMelt;
namespace EpsilonEngine
{
    public static class EpsilonKernal
    {
        public static Point veiwPortSize = new Point(256, 144);
        public static int pixelsPerUnit = 16;
        public static Point cameraPosition = Point.Zero;

        public static GameObject[] loadedGameObjects = new GameObject[0];

        public static OutputPacket Update(UpdatePacket packet)
        {
            Console.WriteLine($"{packet.deltaTime.Ticks / 1000}k TPF");

            for (int i = 0; i < loadedGameObjects.Length; i++)
            {
                loadedGameObjects[i].Update(packet);
            }

            return OutputPacket.Create(Render(packet), false);
        }
        private static Texture Render(UpdatePacket packet)
        {
            Texture renderTexture = Texture.Create(veiwPortSize.x, veiwPortSize.y, new Color(150, 150, 150));
            for (int i = 0; i < loadedGameObjects.Length; i++)
            {
                renderTexture.Blitz(loadedGameObjects[i].graphic, loadedGameObjects[i].position.x - cameraPosition.x, loadedGameObjects[i].position.y - cameraPosition.y);
            }
            return renderTexture;
        }
        public static void DestroyGameObject(int index)
        {
            List<GameObject> temp = new List<GameObject>(loadedGameObjects);
            temp.RemoveAt(index);
            loadedGameObjects = temp.ToArray();
        }
        public static void InstantiateGameObject(GameObject newGameObject)
        {
            List<GameObject> temp = new List<GameObject>(loadedGameObjects);
            temp.Add(newGameObject);
            loadedGameObjects = temp.ToArray();
        }
        public static void Initialize(InitializationPacket packet)
        {
            LevelInstantiateor.InstantiateLevel();
            for (int i = 0; i < loadedGameObjects.Length; i++)
            {
                loadedGameObjects[i].Initialize(InitializationPacket.Create());
            }
        }
    }
}