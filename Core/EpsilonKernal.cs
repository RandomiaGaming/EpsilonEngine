using System.Collections.Generic;
using System;
namespace EpsilonEngine.Internal
{
    public static class EpsilonKernal
    {
        public static Point veiwPortSize = Point.Create(256, 144);
        public static int pixelsPerUnit = 16;

        public static Point cameraPosition = Point.Create(0, 0);
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
            Texture renderTexture = Texture.Create(Color.Create(255, 255, 255), veiwPortSize.x, veiwPortSize.y);
            for (int i = 0; i < loadedGameObjects.Length; i++)
            {
                if (loadedGameObjects[i].screenSpaceGraphic)
                {
                    Point target = loadedGameObjects[i].position;
                    renderTexture.Blitz(loadedGameObjects[i].graphic, target.x, target.y);
                }
                else
                {
                    Point target = loadedGameObjects[i].position - cameraPosition;
                    renderTexture.Blitz(loadedGameObjects[i].graphic, target.x, target.y);
                }
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
            for (int i = 0; i < loadedGameObjects.Length; i++)
            {
                loadedGameObjects[i].Initialize();
            }
        }
    }
}