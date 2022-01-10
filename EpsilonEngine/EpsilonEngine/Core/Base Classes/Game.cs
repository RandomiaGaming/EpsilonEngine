using System.Collections.Generic;
using System;
namespace EpsilonEngine
{
    public class Game
    {
        public bool destroyed { get; private set; } = false;
        private List<View> _views = new List<View>();
        private List<GameManager> _gameManagers = new List<GameManager>();
        private GameInterface _gameInterface = null;
        public string name = "Unnamed Game";
        public Game(GameInterface gameInterface)
        {
            if (gameInterface is null)
            {
                throw new Exception("gameInterface cannot be null.");
            }
            _gameInterface = gameInterface;
            _gameInterface.SetGame(this);
        }


        public GameManager GetGameManager(int index)
        {
            if (destroyed)
            {
                throw new Exception("Game has been exited.");
            }
            if (index < 0 || index >= gameManagers.Count)
            {
                throw new ArgumentException();
            }
            return gameManagers[index];
        }
        public GameManager GetGameManager(Type type)
        {
            if (destroyed)
            {
                throw new Exception("Game has been exited.");
            }
            if (type is null)
            {
                throw new NullReferenceException();
            }
            if (!type.IsAssignableFrom(typeof(GameManager)))
            {
                throw new ArgumentException();
            }
            for (int i = 0; i < gameManagers.Count; i++)
            {
                if (gameManagers[i].GetType().IsAssignableFrom(type))
                {
                    return gameManagers[i];
                }
            }
            return null;
        }
        public T GetGameManager<T>() where T : GameManager
        {
            if (destroyed)
            {
                throw new Exception("Game has been exited.");
            }
            for (int i = 0; i < gameManagers.Count; i++)
            {
                if (gameManagers[i].GetType().IsAssignableFrom(typeof(T)))
                {
                    return (T)gameManagers[i];
                }
            }
            return null;
        }
        public List<GameManager> GetGameManagers()
        {
            if (destroyed)
            {
                throw new Exception("Game has been exited.");
            }
            return new List<GameManager>(gameManagers);
        }
        public List<GameManager> GetGameManagers(Type type)
        {
            if (destroyed)
            {
                throw new Exception("Game has been exited.");
            }
            if (type is null)
            {
                throw new NullReferenceException();
            }
            if (!type.IsAssignableFrom(typeof(GameManager)))
            {
                throw new ArgumentException();
            }
            List<GameManager> output = new List<GameManager>();
            for (int i = 0; i < gameManagers.Count; i++)
            {
                if (gameManagers[i].GetType().IsAssignableFrom(type))
                {
                    output.Add(gameManagers[i]);
                }
            }
            return output;
        }
        public List<T> GetGameManagers<T>() where T : GameManager
        {
            if (destroyed)
            {
                throw new Exception("Game has been exited.");
            }
            List<T> output = new List<T>();
            for (int i = 0; i < gameManagers.Count; i++)
            {
                if (gameManagers[i].GetType().IsAssignableFrom(typeof(T)))
                {
                    output.Add((T)gameManagers[i]);
                }
            }
            return output;
        }
        public int GetGameManagerCount()
        {
            if (destroyed)
            {
                throw new Exception("Game has been exited.");
            }
            return gameManagers.Count;
        }
        public void RemoveGameManager(GameManager gameManager)
        {
            if (destroyed)
            {
                throw new Exception("Game has been exited.");
            }
            if (gameManager is null)
            {
                throw new Exception("GameManager was null.");
            }
            if (gameManager.game != this)
            {
                throw new Exception("GameManager belongs on a different Game.");
            }
            for (int i = 0; i < gameManagers.Count; i++)
            {
                if (gameManagers[i] == gameManager)
                {
                    gameManagers.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("GameManager not found on this scene.");
        }
        public void AddGameManager(GameManager gameManager)
        {
            if (destroyed)
            {
                throw new Exception("Game has been exited.");
            }
            if (gameManager is null)
            {
                throw new Exception("GameManager was null.");
            }
            if (gameManager.game != this)
            {
                throw new Exception("GameManager belongs to a different Game.");
            }
            for (int i = 0; i < gameManagers.Count; i++)
            {
                if (gameManagers[i] == gameManager)
                {
                    throw new Exception("GameManager was already added.");
                }
            }
            gameManagers.Add(gameManager);
            gameManager.CallInitialize();
        }
        public void SetScene(Scene scene)
        {
            if (destroyed)
            {
                throw new Exception("Game has been exited.");
            }
            if (scene is null)
            {
                this.scene = null;
                return;
            }
            if (scene.game != this)
            {
                throw new Exception("Scene belongs to a different Game.");
            }
            this.scene = scene;
        }

        #region Methods
        public void Initialize()
        {

        }
        public void Destroy()
        {
            if (destroyed)
            {
                throw new Exception("Game has been exited.");
            }
            foreach (GameManager gameManager in _gameManagers)
            {
                gameManager.Destroy();
            }
            foreach (Scene scene in _scenes)
            {
                scene.Destroy();
            }
            destroyed = true;
        }
        public void Update()
        {
            if (destroyed)
            {
                throw new Exception("Game has been quit.");
            }
            foreach (GameManager gameManager in gameManagers)
            {
                gameManager.CallPrepare();
            }
            scene.Prepare();
            canvas.Prepare();
            foreach (GameManager gameManager in gameManagers)
            {
                gameManager.CallUpdate();
            }
            scene.Update();
            canvas.Prepare();
            foreach (GameManager gameManager in gameManagers)
            {
                gameManager.CallCleanup();
            }
            foreach (Scene scene in scenes)
            {
                scene.Cleanup();
            }
            return Render();
        }
        public void Render()
        {
            if (destroyed)
            {
                throw new Exception("Game has been quit.");
            }
            RenderTexture output = new RenderTexture();
            foreach (GameManager gameManager in gameManagers)
            {
                output.Merge(gameManager.CallRender());
            }
            foreach (Scene scene in scenes)
            {
                output.Merge(scene.Render());
            }
            return output;
        }
        #endregion
        #region Overrides
        public override string ToString()
        {
            return $"EpsilonEngine.Game({name})";
        }
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