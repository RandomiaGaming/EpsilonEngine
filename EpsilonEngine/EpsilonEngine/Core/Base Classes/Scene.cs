using System;
using System.Collections.Generic;
namespace EpsilonEngine
{
    public class Scene
    {
        #region Variables
        private ushort _viewportWidth = 1920;
        private ushort _viewportHeight = 1080;
        private Point _viewportOffset = new Point(-960, -540);
        private Point _cameraPosition = new Point(0, 0);
        private Microsoft.Xna.Framework.Graphics.RenderTarget2D renderTarget = null;

        private List<GameObject> _gameObjects = new List<GameObject>();
        private List<SceneManager> _sceneManagers = new List<SceneManager>();
        private Game _game = null;
        public string _name = "Unnamed Scene";
        private bool _destroyed = false;
        #endregion
        #region Properties
        public GameInterface GameInterface
        {
            get
            {
                if (_destroyed)
                {
                    throw new Exception("Scene has been destroyed.");
                }
                return _game.GameInterface;
            }
        }
        public Game Game
        {
            get
            {
                if (_destroyed)
                {
                    throw new Exception("Scene has been destroyed.");
                }

                return _game;
            }
        }
        public string Name
        {
            get
            {
                if (_destroyed)
                {
                    throw new Exception("Scene has been destroyed.");
                }
                return _name;
            }
            set
            {
                if (_destroyed)
                {
                    throw new Exception("Scene has been destroyed.");
                }
                _name = value;
            }
        }
        public bool Destroyed
        {
            get
            {
                return _destroyed;
            }
        }
        #endregion
        #region Constructors
        public Scene(Game game)
        {
            if (game is null)
            {
                throw new Exception("game cannot be null.");
            }

            _game = game;

            _game.AddScene(this);
        }
        #endregion
        #region Overrides
        public override string ToString()
        {
            if (_destroyed)
            {
                throw new Exception("Scene has been destroyed.");
            }
            return $"EpsilonEngine.Scene({_name})";
        }
        #endregion
        #region Methods
        #region Basic Methods
        public void Initialize()
        {
            if (_destroyed)
            {
                throw new Exception("Scene has been destroyed.");
            }
            initialize();
        }
        public void Destroy()
        {
            if (_destroyed)
            {
                return;
            }

            onDestroy();

            foreach (SceneManager sceneManager in _sceneManagers)
            {
                sceneManager.Destroy();
            }

            foreach (GameObject gameObject in _gameObjects)
            {
                gameObject.Destroy();
            }

            _destroyed = true;
        }
        public void Update()
        {
            if (_destroyed)
            {
                throw new Exception("Scene has been destroyed.");
            }

            prepare();
            foreach (SceneManager sceneManager in _sceneManagers)
            {
                sceneManager.Prepare();
            }
            foreach (Scene scene in _gameObjects)
            {
                scene.Prepare();
            }

            update();
            foreach (SceneManager sceneManager in _sceneManagers)
            {
                sceneManager.Update();
            }
            foreach (GameObject gameObject in _gameObjects)
            {
                scene.Update();
            }

            cleanup();
            foreach (SceneManager sceneManager in _sceneManagers)
            {
                sceneManager.Cleanup();
            }
            foreach (Scene scene in _gameObjects)
            {
                scene.Cleanup();
            }
        }
        public void Render()
        {
            if (_destroyed)
            {
                throw new Exception("Scene has been destroyed.");
            }

            render();
            foreach (SceneManager sceneManager in sceneManagers)
            {
                sceneManager.Render();
            }
            foreach (GameObject gameObject in _gameObjects)
            {
                gameObject.Render();
            }
        }
        #endregion
        #region SceneManager Methods
        public SceneManager GetSceneManager(int index)
        {
            if (_destroyed)
            {
                throw new Exception("Scene has been destroyed.");
            }

            if (index < 0 || index >= _sceneManagers.Count)
            {
                throw new Exception("index was out of range.");
            }

            return _sceneManagers[index];
        }
        public SceneManager GetSceneManager(Type type)
        {
            if (_destroyed)
            {
                throw new Exception("Scene has been destroyed.");
            }

            if (type is null)
            {
                throw new Exception("type cannot be null.");
            }

            if (!type.IsAssignableFrom(typeof(SceneManager)))
            {
                throw new Exception("type must be equal to SceneManager or be assignable from SceneManager.");
            }

            foreach (SceneManager sceneManager in _sceneManagers)
            {
                if (sceneManager.GetType().IsAssignableFrom(type))
                {
                    return sceneManager;
                }
            }

            return null;
        }
        public T GetSceneManager<T>() where T : SceneManager
        {
            if (_destroyed)
            {
                throw new Exception("Scene has been destroyed.");
            }

            foreach (SceneManager sceneManager in _sceneManagers)
            {
                if (sceneManager.GetType().IsAssignableFrom(typeof(T)))
                {
                    return (T)sceneManager;
                }
            }

            return null;
        }
        public List<SceneManager> GetSceneManagers()
        {
            if (_destroyed)
            {
                throw new Exception("Scene has been destroyed.");
            }

            return new List<SceneManager>(_sceneManagers);
        }
        public List<SceneManager> GetSceneManagers(Type type)
        {
            if (_destroyed)
            {
                throw new Exception("Scene has been destroyed.");
            }

            if (type is null)
            {
                throw new Exception("type cannot be null.");
            }

            if (!type.IsAssignableFrom(typeof(SceneManager)))
            {
                throw new Exception("type must be equal to SceneManager or be assignable from SceneManager.");
            }

            List<SceneManager> output = new List<SceneManager>();

            foreach (SceneManager sceneManager in _sceneManagers)
            {
                if (sceneManager.GetType().IsAssignableFrom(type))
                {
                    output.Add(sceneManager);
                }
            }

            return output;
        }
        public List<T> GetSceneManagers<T>() where T : SceneManager
        {
            if (_destroyed)
            {
                throw new Exception("Scene has been destroyed.");
            }

            List<T> output = new List<T>();

            foreach (SceneManager sceneManager in _sceneManagers)
            {
                if (sceneManager.GetType().IsAssignableFrom(typeof(T)))
                {
                    output.Add((T)sceneManager);
                }
            }

            return output;
        }
        public int GetSceneManagerCount()
        {
            if (_destroyed)
            {
                throw new Exception("Scene has been destroyed.");
            }

            return _sceneManagers.Count;
        }
        #region Internal Methods
        internal void RemoveSceneManager(SceneManager sceneManager)
        {
            if (_destroyed)
            {
                throw new Exception("Scene has been destroyed.");
            }

            if (sceneManager is null)
            {
                throw new Exception("SceneManager was null.");
            }

            if (sceneManager.Scene != this)
            {
                throw new Exception("SceneManager belongs on a different Scene.");
            }

            for (int i = 0; i < _sceneManagers.Count; i++)
            {
                if (_sceneManagers[i] == sceneManager)
                {
                    _sceneManagers.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("SceneManager not found.");
        }
        internal void AddSceneManager(SceneManager sceneManager)
        {
            if (_destroyed)
            {
                throw new Exception("Scene has been destroyed.");
            }

            if (sceneManager is null)
            {
                throw new Exception("SceneManager was null.");
            }

            if (sceneManager.Scene != this)
            {
                throw new Exception("SceneManager belongs to a different Scene.");
            }

            foreach (SceneManager _sceneManager in _sceneManagers)
            {
                if (_sceneManager == sceneManager)
                {
                    throw new Exception("SceneManager was already added.");
                }
            }

            _sceneManagers.Add(sceneManager);

            sceneManager.Initialize();
        }
        #endregion
        #endregion
        #region Scene Methods
        public Scene GetScene(int index)
        {
            if (_destroyed)
            {
                throw new Exception("Scene has been destroyed.");
            }

            if (index < 0 || index >= _gameObjects.Count)
            {
                throw new Exception("index was out of range.");
            }

            return _gameObjects[index];
        }
        public List<Scene> GetScenes()
        {
            if (_destroyed)
            {
                throw new Exception("Scene has been destroyed.");
            }

            return new List<Scene>(_gameObjects);
        }
        public int GetSceneCount()
        {
            if (_destroyed)
            {
                throw new Exception("Scene has been destroyed.");
            }

            return _gameObjects.Count;
        }
        #region Internal Methods
        internal void RemoveScene(Scene scene)
        {
            if (_destroyed)
            {
                throw new Exception("Scene has been destroyed.");
            }

            if (scene is null)
            {
                throw new Exception("Scene was null.");
            }

            if (scene.game != this)
            {
                throw new Exception("Scene belongs on a different Game.");
            }

            for (int i = 0; i < _gameObjects.Count; i++)
            {
                if (_gameObjects[i] == scene)
                {
                    _gameObjects.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Scene not found.");
        }
        internal void AddScene(Scene scene)
        {
            if (_destroyed)
            {
                throw new Exception("Scene has been destroyed.");
            }

            if (scene is null)
            {
                throw new Exception("Scene was null.");
            }

            if (scene.game != this)
            {
                throw new Exception("Scene belongs to a different Game.");
            }

            foreach (Scene _scene in _gameObjects)
            {
                if (_scene == scene)
                {
                    throw new Exception("Scene was already added.");
                }
            }

            _gameObjects.Add(scene);

            scene.Initialize();
        }
        #endregion
        #endregion
        #endregion
        #region Overridables
        protected virtual void onDestroy()
        {

        }
        protected virtual void initialize()
        {

        }
        protected virtual void prepare()
        {

        }
        protected virtual void update()
        {

        }
        protected virtual void cleanup()
        {

        }
        protected virtual void render()
        {

        }
        #endregion
    }
}