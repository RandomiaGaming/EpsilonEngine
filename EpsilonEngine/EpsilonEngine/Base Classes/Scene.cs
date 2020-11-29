using System;
using System.Collections.Generic;
namespace EpsilonEngine
{
    public class Scene
    {
        public SceneRenderer renderer;

        protected List<GameObject> gameObjects = new List<GameObject>();
        protected List<int> gameObjectsToDestroy = new List<int>();
        protected List<GameObject> gameObjectsToInstantiate = new List<GameObject>();

        public readonly GameInterface gameInterface = null;
        public readonly Game game = null;
        public Scene(Game game)
        {
            if (game is null)
            {
                throw new NullReferenceException();
            }
            this.game = game;
            if (game.gameInterface is null)
            {
                throw new NullReferenceException();
            }
            gameInterface = game.gameInterface;
        }

        public virtual void Initialize()
        {

        }
        public virtual void Update()
        {
            foreach (GameObject go in gameObjects)
            {
                go.Update();
            }
        }

        public virtual void CullGameObjects()
        {
            if (gameObjectsToDestroy is null)
            {
                gameObjectsToDestroy = new List<int>();
            }
            gameObjectsToDestroy.Sort();
            foreach (int gameObjectID in gameObjectsToDestroy)
            {
                gameObjects.RemoveAt(gameObjectID);
            }
            gameObjectsToDestroy = new List<int>();

            foreach (GameObject gameObjectToLoad in gameObjectsToInstantiate)
            {
                gameObjects.Add(gameObjectToLoad);
            }
            foreach (GameObject gameObjectToLoad in gameObjectsToInstantiate)
            {
                gameObjectToLoad.Initialize();
            }
            gameObjectsToInstantiate = new List<GameObject>();

            foreach(GameObject gameObject in gameObjects)
            {
                gameObject.CullComponents();
            }
        }

        #region GameObject Management Methods
        public virtual GameObject GetGameObject(int index)
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
            return gameObjects[index];
        }
        public virtual List<GameObject> GetGameObjects()
        {
            return new List<GameObject>(gameObjects);
        }
        public virtual int GetGameObjectCount()
        {
            if (gameObjects is null)
            {
                gameObjects = new List<GameObject>();
                return 0;
            }
            return gameObjects.Count;
        }
        public virtual void DestroyGameObject(int index)
        {
            if (gameObjects is null)
            {
                gameObjects = new List<GameObject>();
                return;
            }
            if (index < 0 || index >= gameObjects.Count)
            {
                throw new ArgumentException();
            }
            if (gameObjectsToDestroy is null)
            {
                gameObjectsToDestroy = new List<int>();
            }
            gameObjectsToDestroy.Add(index);
        }
        public virtual void DestroyGameObject(GameObject target)
        {
            if (gameObjects is null)
            {
                gameObjects = new List<GameObject>();
                return;
            }
            if (target is null)
            {
                throw new NullReferenceException();
            }
            if (gameObjectsToDestroy is null)
            {
                gameObjectsToDestroy = new List<int>();
            }
            for (int i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i] == target)
                {
                    gameObjectsToDestroy.Add(i);
                }
            }
        }
        public virtual void InstantiateGameObject(GameObject newGameObject)
        {
            if (gameObjectsToInstantiate is null)
            {
                gameObjectsToInstantiate = new List<GameObject>();
            }
            if(newGameObject is null)
            {
                throw new NullReferenceException();
            }
            gameObjectsToInstantiate.Add(newGameObject);
        }
        #endregion
    }
}
