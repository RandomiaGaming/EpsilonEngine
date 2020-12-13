using System;
using System.Collections.Generic;

namespace EpsilonEngine.Modules.Pixel2D
{
    public class Pixel2DScene : SceneBase
    {
        public Vector2Int cameraPosition = Vector2Int.Zero;

        private List<Pixel2DGameObject> gameObjects = new List<Pixel2DGameObject>();
        private List<int> gameObjectsToDestroy = new List<int>();
        private List<Pixel2DGameObject> gameObjectsToInstantiate = new List<Pixel2DGameObject>();

        private List<Pixel2DSceneManager> sceneManagers = new List<Pixel2DSceneManager>();
        private List<int> sceneManagersToRemove = new List<int>();
        private List<Pixel2DSceneManager> sceneManagersToAdd = new List<Pixel2DSceneManager>();
        public Pixel2DScene(GameBase game) : base(game)
        {

        }
        public override Texture Render()
        {
            Texture frame = new Texture(256, 144, new Color(255, 255, 155, 255));

            foreach (Pixel2DGameObject pixel2DGameObject in gameObjects)
            {
                if (pixel2DGameObject.texture is not null)
                {
                    TextureHelper.Blitz(pixel2DGameObject.texture, frame, new Vector2Int(pixel2DGameObject.position.x - cameraPosition.x, pixel2DGameObject.position.y - cameraPosition.y));
                }
            }

            return frame;
        }
        public override void Update()
        {
            foreach(Pixel2DSceneManager sceneManager in sceneManagers)
            {
                sceneManager.Update();
            }

            foreach (Pixel2DGameObject pixel2DGameObject in gameObjects)
            {
                pixel2DGameObject.Update();
            }
        }
        public override void Cleanup()
        {
            if (sceneManagersToRemove is null)
            {
                sceneManagersToRemove = new List<int>();
            }
            sceneManagersToRemove.Sort();
            foreach (int sceneManagerID in sceneManagersToRemove)
            {
                sceneManagers.RemoveAt(sceneManagerID);
            }
            sceneManagersToRemove = new List<int>();

            foreach (Pixel2DSceneManager sceneManagerToLoad in sceneManagersToAdd)
            {
                sceneManagers.Add(sceneManagerToLoad);
            }
            foreach (Pixel2DSceneManager sceneManagerToLoad in sceneManagersToAdd)
            {
                sceneManagerToLoad.Initialize();
            }
            sceneManagersToAdd = new List<Pixel2DSceneManager>();

            foreach (Pixel2DSceneManager sceneManager in sceneManagers)
            {
                sceneManager.Cleanup();
            }

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

            foreach (Pixel2DGameObject gameObjectToLoad in gameObjectsToInstantiate)
            {
                gameObjects.Add(gameObjectToLoad);
            }
            foreach (Pixel2DGameObject gameObjectToLoad in gameObjectsToInstantiate)
            {
                gameObjectToLoad.Initialize();
            }
            gameObjectsToInstantiate = new List<Pixel2DGameObject>();

            foreach (Pixel2DGameObject gameObject in gameObjects)
            {
                gameObject.Cleanup();
            }
        }

        #region GameObject Management Methods
        public Pixel2DGameObject GetGameObject(int index)
        {
            if (gameObjects is null)
            {
                gameObjects = new List<Pixel2DGameObject>();
                return null;
            }
            if (index < 0 || index >= gameObjects.Count)
            {
                throw new ArgumentException();
            }
            return gameObjects[index];
        }
        public List<Pixel2DGameObject> GetGameObjects()
        {
            return new List<Pixel2DGameObject>(gameObjects);
        }
        public int GetGameObjectCount()
        {
            if (gameObjects is null)
            {
                gameObjects = new List<Pixel2DGameObject>();
                return 0;
            }
            return gameObjects.Count;
        }
        public void DestroyGameObject(int index)
        {
            if (gameObjects is null)
            {
                gameObjects = new List<Pixel2DGameObject>();
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
        public void DestroyGameObject(Pixel2DGameObject target)
        {
            if (gameObjects is null)
            {
                gameObjects = new List<Pixel2DGameObject>();
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
        public void InstantiateGameObject(Pixel2DGameObject newGameObject)
        {
            if (gameObjectsToInstantiate is null)
            {
                gameObjectsToInstantiate = new List<Pixel2DGameObject>();
            }
            if (newGameObject is null)
            {
                throw new NullReferenceException();
            }
            gameObjectsToInstantiate.Add(newGameObject);
        }
        #endregion

        #region Scene Manager Management Methods
        public Pixel2DSceneManager GetSceneManager(int index)
        {
            if (sceneManagers is null)
            {
                sceneManagers = new List<Pixel2DSceneManager>();
                return null;
            }
            if (index < 0 || index >= sceneManagers.Count)
            {
                throw new ArgumentException();
            }
            return sceneManagers[index];
        }
        public Pixel2DSceneManager GetSceneManager(Type targetType)
        {
            if (sceneManagers is null)
            {
                sceneManagers = new List<Pixel2DSceneManager>();
                return null;
            }
            if (targetType is null)
            {
                throw new NullReferenceException();
            }
            for (int i = 0; i < sceneManagers.Count; i++)
            {
                if (sceneManagers[i].GetType().IsAssignableFrom(targetType))
                {
                    return sceneManagers[i];
                }
            }
            return null;
        }
        public T GetSceneManager<T>() where T : Pixel2DSceneManager
        {
            if (sceneManagers is null)
            {
                sceneManagers = new List<Pixel2DSceneManager>();
                return null;
            }
            for (int i = 0; i < sceneManagers.Count; i++)
            {
                if (sceneManagers[i].GetType().IsAssignableFrom(typeof(T)))
                {
                    return (T)sceneManagers[i];
                }
            }
            return null;
        }
        public List<Pixel2DSceneManager> GetSceneManagers()
        {
            return new List<Pixel2DSceneManager>(sceneManagers);
        }
        public List<Pixel2DSceneManager> GetSceneManagers(Type targetType)
        {
            if (sceneManagers is null)
            {
                sceneManagers = new List<Pixel2DSceneManager>();
                return null;
            }
            if (targetType is null)
            {
                throw new NullReferenceException();
            }
            List<Pixel2DSceneManager> output = new List<Pixel2DSceneManager>();
            for (int i = 0; i < sceneManagers.Count; i++)
            {
                if (sceneManagers[i].GetType().IsAssignableFrom(targetType))
                {
                    output.Add(sceneManagers[i]);
                }
            }
            return output;
        }
        public List<T> GetSceneManagers<T>() where T : Pixel2DSceneManager
        {
            if (sceneManagers is null)
            {
                sceneManagers = new List<Pixel2DSceneManager>();
                return null;
            }
            List<T> output = new List<T>();
            for (int i = 0; i < sceneManagers.Count; i++)
            {
                if (sceneManagers[i].GetType().IsAssignableFrom(typeof(T)))
                {
                    output.Add((T)sceneManagers[i]);
                }
            }
            return output;
        }
        public int GetSceneManagerCount()
        {
            if (sceneManagers is null)
            {
                sceneManagers = new List<Pixel2DSceneManager>();
                return 0;
            }
            return sceneManagers.Count;
        }
        public void RemoveSceneManager(int index)
        {
            if (sceneManagers is null)
            {
                sceneManagers = new List<Pixel2DSceneManager>();
                return;
            }
            if (index < 0 || index >= sceneManagers.Count)
            {
                throw new ArgumentException();
            }
            if (sceneManagersToRemove is null)
            {
                sceneManagersToRemove = new List<int>();
            }
            sceneManagersToRemove.Add(index);
        }
        public void RemoveSceneManager(Pixel2DSceneManager targetSceneManager)
        {
            if (sceneManagers is null)
            {
                sceneManagers = new List<Pixel2DSceneManager>();
                return;
            }
            if (targetSceneManager is null)
            {
                throw new NullReferenceException();
            }
            if (sceneManagersToRemove is null)
            {
                sceneManagersToRemove = new List<int>();
            }
            for (int i = 0; i < sceneManagers.Count; i++)
            {
                if (sceneManagers[i] == targetSceneManager)
                {
                    sceneManagersToRemove.Add(i);
                }
            }
        }
        public void RemoveSceneManagers(Type targetType)
        {
            if (sceneManagers is null)
            {
                sceneManagers = new List<Pixel2DSceneManager>();
                return;
            }
            if (targetType is null)
            {
                throw new NullReferenceException();
            }
            if (sceneManagersToRemove is null)
            {
                sceneManagersToRemove = new List<int>();
            }
            for (int i = 0; i < sceneManagers.Count; i++)
            {
                if (sceneManagers[i].GetType().IsAssignableFrom(targetType))
                {
                    sceneManagersToRemove.Add(i);
                }
            }
        }
        public void RemoveSceneManagers<T>() where T : Pixel2DSceneManager
        {
            if (sceneManagers is null)
            {
                sceneManagers = new List<Pixel2DSceneManager>();
                return;
            }
            if (sceneManagersToRemove is null)
            {
                sceneManagersToRemove = new List<int>();
            }
            for (int i = 0; i < sceneManagers.Count; i++)
            {
                if (sceneManagers[i].GetType().IsAssignableFrom(typeof(T)))
                {
                    sceneManagersToRemove.Add(i);
                }
            }
        }
        public void AddSceneManager(Pixel2DSceneManager newSceneManager)
        {
            if (sceneManagersToAdd is null)
            {
                sceneManagersToAdd = new List<Pixel2DSceneManager>();
            }
            if (newSceneManager is null)
            {
                throw new NullReferenceException();
            }
            sceneManagersToAdd.Add(newSceneManager);
        }
        #endregion
    }
}
