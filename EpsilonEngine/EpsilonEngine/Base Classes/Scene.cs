using System;
using System.Collections.Generic;
namespace EpsilonEngine
{
    public class Scene
    {
        public Vector2Int cameraPosition = Vector2Int.Zero;
        public Vector2Int viewPortRect = new Vector2Int(256, 144);

        protected List<GameObject> gameObjects = new List<GameObject>();
        protected List<int> gameObjectsToDestroy = new List<int>();
        protected List<GameObject> gameObjectsToInstantiate = new List<GameObject>();

        protected List<SceneManager> sceneManagers = new List<SceneManager>();
        protected List<int> sceneManagersToRemove = new List<int>();
        protected List<SceneManager> sceneManagersToAdd = new List<SceneManager>();

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
                throw new ArgumentException();
            }
            gameInterface = game.gameInterface;
        }
        public virtual void Initialize()
        {

        }
        public virtual Texture Render()
        {
            Texture frame = new Texture(256, 144, new Color(255, 255, 155, 255));

            foreach (GameObject pixel2DGameObject in gameObjects)
            {
                if (pixel2DGameObject.texture is not null)
                {
                    TextureHelper.Blitz(pixel2DGameObject.texture, frame, new Vector2Int(pixel2DGameObject.position.x - cameraPosition.x, pixel2DGameObject.position.y - cameraPosition.y));
                }
            }

            return frame;
        }
        public virtual void Update()
        {
            foreach(SceneManager sceneManager in sceneManagers)
            {
                sceneManager.Update();
            }

            foreach (GameObject pixel2DGameObject in gameObjects)
            {
                pixel2DGameObject.Update();
            }
        }
        public virtual void Cleanup()
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

            foreach (SceneManager sceneManagerToLoad in sceneManagersToAdd)
            {
                sceneManagers.Add(sceneManagerToLoad);
            }
            foreach (SceneManager sceneManagerToLoad in sceneManagersToAdd)
            {
                sceneManagerToLoad.Initialize();
            }
            sceneManagersToAdd = new List<SceneManager>();

            foreach (SceneManager sceneManager in sceneManagers)
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

            foreach (GameObject gameObjectToLoad in gameObjectsToInstantiate)
            {
                gameObjects.Add(gameObjectToLoad);
            }
            foreach (GameObject gameObjectToLoad in gameObjectsToInstantiate)
            {
                gameObjectToLoad.Initialize();
            }
            gameObjectsToInstantiate = new List<GameObject>();

            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Cleanup();
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
            if (newGameObject is null)
            {
                throw new NullReferenceException();
            }
            gameObjectsToInstantiate.Add(newGameObject);
        }
        #endregion
        #region Scene Manager Management Methods
        public virtual SceneManager GetSceneManager(int index)
        {
            if (sceneManagers is null)
            {
                sceneManagers = new List<SceneManager>();
                return null;
            }
            if (index < 0 || index >= sceneManagers.Count)
            {
                throw new ArgumentException();
            }
            return sceneManagers[index];
        }
        public virtual SceneManager GetSceneManager(Type targetType)
        {
            if (sceneManagers is null)
            {
                sceneManagers = new List<SceneManager>();
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
        public virtual T GetSceneManager<T>() where T : SceneManager
        {
            if (sceneManagers is null)
            {
                sceneManagers = new List<SceneManager>();
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
        public virtual List<SceneManager> GetSceneManagers()
        {
            return new List<SceneManager>(sceneManagers);
        }
        public virtual List<SceneManager> GetSceneManagers(Type targetType)
        {
            if (sceneManagers is null)
            {
                sceneManagers = new List<SceneManager>();
                return null;
            }
            if (targetType is null)
            {
                throw new NullReferenceException();
            }
            List<SceneManager> output = new List<SceneManager>();
            for (int i = 0; i < sceneManagers.Count; i++)
            {
                if (sceneManagers[i].GetType().IsAssignableFrom(targetType))
                {
                    output.Add(sceneManagers[i]);
                }
            }
            return output;
        }
        public virtual List<T> GetSceneManagers<T>() where T : SceneManager
        {
            if (sceneManagers is null)
            {
                sceneManagers = new List<SceneManager>();
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
        public virtual int GetSceneManagerCount()
        {
            if (sceneManagers is null)
            {
                sceneManagers = new List<SceneManager>();
                return 0;
            }
            return sceneManagers.Count;
        }
        public virtual void RemoveSceneManager(int index)
        {
            if (sceneManagers is null)
            {
                sceneManagers = new List<SceneManager>();
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
        public virtual void RemoveSceneManager(SceneManager targetSceneManager)
        {
            if (sceneManagers is null)
            {
                sceneManagers = new List<SceneManager>();
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
        public virtual void RemoveSceneManagers(Type targetType)
        {
            if (sceneManagers is null)
            {
                sceneManagers = new List<SceneManager>();
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
        public virtual void RemoveSceneManagers<T>() where T : SceneManager
        {
            if (sceneManagers is null)
            {
                sceneManagers = new List<SceneManager>();
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
        public virtual void AddSceneManager(SceneManager newSceneManager)
        {
            if (sceneManagersToAdd is null)
            {
                sceneManagersToAdd = new List<SceneManager>();
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
