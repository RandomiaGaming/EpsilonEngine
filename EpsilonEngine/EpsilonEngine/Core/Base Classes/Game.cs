using System.Collections.Generic;
using System;
namespace EpsilonEngine
{
    public class Game
    {
        #region Variables
        private List<Scene> _scenes = new List<Scene>();
        private List<GameManager> _gameManagers = new List<GameManager>();
        private GameInterface _gameInterface = null;
        public string _name = "Unnamed Game";
        private bool _destroyed = false;
        #endregion
        #region Properties
        public GameInterface GameInterface
        {
            get
            {
                if (_destroyed)
                {
                    throw new Exception("Game has been destroyed.");
                }
                return _gameInterface;
            }
        }
        public string Name
        {
            get
            {
                if (_destroyed)
                {
                    throw new Exception("Game has been destroyed.");
                }
                return _name;
            }
            set
            {
                if (_destroyed)
                {
                    throw new Exception("Game has been destroyed.");
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
        public Game(GameInterface gameInterface)
        {
            if (gameInterface is null)
            {
                throw new Exception("gameInterface cannot be null.");
            }

            _gameInterface = gameInterface;

            _gameInterface.SetGame(this);
        }
        #endregion
        #region Overrides
        public override string ToString()
        {
            if (_destroyed)
            {
                throw new Exception("Game has been destroyed.");
            }
            return $"EpsilonEngine.Game({_name})";
        }
        #endregion
        #region Methods
        #region Basic Methods
        public void Initialize()
        {
            if (_destroyed)
            {
                throw new Exception("Game has been destroyed.");
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

            foreach (GameManager gameManager in _gameManagers)
            {
                gameManager.Destroy();
            }

            foreach (Scene scene in _scenes)
            {
                scene.Destroy();
            }

            _destroyed = true;
        }
        public void Update()
        {
            if (_destroyed)
            {
                throw new Exception("Game has been destroyed.");
            }

            prepare();
            foreach (GameManager gameManager in _gameManagers)
            {
                gameManager.Prepare();
            }
            foreach (Scene scene in _scenes)
            {
                scene.Prepare();
            }

            update();
            foreach (GameManager gameManager in _gameManagers)
            {
                gameManager.Update();
            }
            foreach (Scene scene in _scenes)
            {
                scene.Update();
            }

            cleanup();
            foreach (GameManager gameManager in _gameManagers)
            {
                gameManager.Cleanup();
            }
            foreach (Scene scene in _scenes)
            {
                scene.Cleanup();
            }
        }
        public void Render()
        {
            if (_destroyed)
            {
                throw new Exception("Game has been destroyed.");
            }

            render();
            foreach (GameManager gameManager in gameManagers)
            {
                gameManager.Render();
            }
            foreach (Scene scene in _scenes)
            {
                scene.Render();
            }
        }
        #endregion
        #region GameManager Methods
        public GameManager GetGameManager(int index)
        {
            if (_destroyed)
            {
                throw new Exception("Game has been destroyed.");
            }

            if (index < 0 || index >= _gameManagers.Count)
            {
                throw new Exception("index was out of range.");
            }

            return _gameManagers[index];
        }
        public GameManager GetGameManager(Type type)
        {
            if (_destroyed)
            {
                throw new Exception("Game has been destroyed.");
            }

            if (type is null)
            {
                throw new Exception("type cannot be null.");
            }

            if (!type.IsAssignableFrom(typeof(GameManager)))
            {
                throw new Exception("type must be equal to GameManager or be assignable from GameManager.");
            }

            foreach (GameManager gameManager in _gameManagers)
            {
                if (gameManager.GetType().IsAssignableFrom(type))
                {
                    return gameManager;
                }
            }

            return null;
        }
        public T GetGameManager<T>() where T : GameManager
        {
            if (_destroyed)
            {
                throw new Exception("Game has been destroyed.");
            }

            foreach (GameManager gameManager in _gameManagers)
            {
                if (gameManager.GetType().IsAssignableFrom(typeof(T)))
                {
                    return (T)gameManager;
                }
            }

            return null;
        }
        public List<GameManager> GetGameManagers()
        {
            if (_destroyed)
            {
                throw new Exception("Game has been destroyed.");
            }

            return new List<GameManager>(_gameManagers);
        }
        public List<GameManager> GetGameManagers(Type type)
        {
            if (_destroyed)
            {
                throw new Exception("Game has been destroyed.");
            }

            if (type is null)
            {
                throw new Exception("type cannot be null.");
            }

            if (!type.IsAssignableFrom(typeof(GameManager)))
            {
                throw new Exception("type must be equal to GameManager or be assignable from GameManager.");
            }

            List<GameManager> output = new List<GameManager>();

            foreach (GameManager gameManager in _gameManagers)
            {
                if (gameManager.GetType().IsAssignableFrom(type))
                {
                    output.Add(gameManager);
                }
            }

            return output;
        }
        public List<T> GetGameManagers<T>() where T : GameManager
        {
            if (_destroyed)
            {
                throw new Exception("Game has been destroyed.");
            }

            List<T> output = new List<T>();

            foreach (GameManager gameManager in _gameManagers)
            {
                if (gameManager.GetType().IsAssignableFrom(typeof(T)))
                {
                    output.Add((T)gameManager);
                }
            }

            return output;
        }
        public int GetGameManagerCount()
        {
            if (_destroyed)
            {
                throw new Exception("Game has been destroyed.");
            }

            return _gameManagers.Count;
        }
        #region Internal Methods
        internal void RemoveGameManager(GameManager gameManager)
        {
            if (_destroyed)
            {
                throw new Exception("Game has been destroyed.");
            }

            if (gameManager is null)
            {
                throw new Exception("GameManager was null.");
            }

            if (gameManager.Game != this)
            {
                throw new Exception("GameManager belongs on a different Game.");
            }

            for (int i = 0; i < _gameManagers.Count; i++)
            {
                if (_gameManagers[i] == gameManager)
                {
                    _gameManagers.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("GameManager not found.");
        }
        internal void AddGameManager(GameManager gameManager)
        {
            if (_destroyed)
            {
                throw new Exception("Game has been destroyed.");
            }

            if (gameManager is null)
            {
                throw new Exception("GameManager was null.");
            }

            if (gameManager.Game != this)
            {
                throw new Exception("GameManager belongs to a different Game.");
            }

            foreach (GameManager _gameManager in _gameManagers)
            {
                if (_gameManager == gameManager)
                {
                    throw new Exception("GameManager was already added.");
                }
            }

            _gameManagers.Add(gameManager);

            gameManager.Initialize();
        }
        #endregion
        #endregion
        #region Scene Methods
        public Scene GetScene(int index)
        {
            if (_destroyed)
            {
                throw new Exception("Game has been destroyed.");
            }

            if (index < 0 || index >= _scenes.Count)
            {
                throw new Exception("index was out of range.");
            }

            return _scenes[index];
        }
        public List<Scene> GetScenes()
        {
            if (_destroyed)
            {
                throw new Exception("Game has been destroyed.");
            }

            return new List<Scene>(_scenes);
        }
        public int GetSceneCount()
        {
            if (_destroyed)
            {
                throw new Exception("Game has been destroyed.");
            }

            return _scenes.Count;
        }
        #region Internal Methods
        internal void RemoveScene(Scene scene)
        {
            if (_destroyed)
            {
                throw new Exception("Game has been destroyed.");
            }

            if (scene is null)
            {
                throw new Exception("Scene was null.");
            }

            if (scene.game != this)
            {
                throw new Exception("Scene belongs on a different Game.");
            }

            for (int i = 0; i < _scenes.Count; i++)
            {
                if (_scenes[i] == scene)
                {
                    _scenes.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Scene not found.");
        }
        internal void AddScene(Scene scene)
        {
            if (_destroyed)
            {
                throw new Exception("Game has been destroyed.");
            }

            if (scene is null)
            {
                throw new Exception("Scene was null.");
            }

            if (scene.game != this)
            {
                throw new Exception("Scene belongs to a different Game.");
            }

            foreach (Scene _scene in _scenes)
            {
                if (_scene == scene)
                {
                    throw new Exception("Scene was already added.");
                }
            }

            _scenes.Add(scene);

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