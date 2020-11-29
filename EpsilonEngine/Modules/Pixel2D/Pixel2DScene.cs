using System;
using System.Collections.Generic;

namespace EpsilonEngine.Modules.Pixel2D
{
    public class Pixel2DScene : Scene
    {
        public Pixel2DScene(Game game) : base(game)
        {

        }
        public override void DestroyGameObject(GameObject target)
        {
            base.DestroyGameObject(target);
        }
        public override void InstantiateGameObject(GameObject newGameObject)
        {
            if(newGameObject is not null && !newGameObject.GetType().IsAssignableFrom(typeof(Pixel2DGameObject)))
            {
                throw new ArgumentException();
            }
            base.InstantiateGameObject(newGameObject);
        }
        public virtual Pixel2DGameObject GetPixel2DGameObject(int index)
        {
            if (gameObjects is null)
            {
                gameObjects = new List<GameObject>();
                return null;
            }
            if (index < 0 || index >= gameObjects.Count)
            {
                throw new ArgumentException();
            }
            return (Pixel2DGameObject)gameObjects[index];
        }
        public virtual List<Pixel2DGameObject> GetPixel2DGameObjects()
        {
            List<Pixel2DGameObject> output = new List<Pixel2DGameObject>();
            for (int i = 0; i < gameObjects.Count; i++)
            {
                output.Add((Pixel2DGameObject)gameObjects[i]);
            }
            return output;
        }
    }
}
