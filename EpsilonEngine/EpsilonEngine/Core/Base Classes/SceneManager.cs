using System;
namespace EpsilonEngine
{
    public abstract class SceneManager
    {
        #region Variables
        public string _name = "Unnamed Scene Manager";
        private bool _destroyed = false;
        private Scene _scene;
        #endregion
        #region Properties
        public GameInterface GameInterface
        {
            get
            {
                if (_destroyed)
                {
                    throw new Exception("SceneManager has been destroyed.");
                }
                return _scene.Game.GameInterface;
            }
        }
        public Game Game
        {
            get
            {
                if (_destroyed)
                {
                    throw new Exception("SceneManager has been destroyed.");
                }
                return _scene.Game;
            }
        }
        public Scene Scene
        {
            get
            {
                if (_destroyed)
                {
                    throw new Exception("SceneManager has been destroyed.");
                }
                return _scene;
            }
        }
        public string Name
        {
            get
            {
                if (_destroyed)
                {
                    throw new Exception("SceneManager has been destroyed.");
                }
                return _name;
            }
            set
            {
                if (_destroyed)
                {
                    throw new Exception("SceneManager has been destroyed.");
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
        public SceneManager(Scene scene)
        {
            if (scene is null)
            {
                throw new Exception("scene cannot be null.");
            }

            _scene = scene;

            _scene.AddSceneManager(this);
        }
        #endregion
        #region Overrides
        public override string ToString()
        {
            if (_destroyed)
            {
                throw new Exception("SceneManager has been destroyed.");
            }

            return $"EpsilonEngine.SceneManager({_name})";
        }
        #endregion
        #region Methods
        public void Destroy()
        {
            if (_destroyed)
            {
                return;
            }

            onDestroy();
        }
        public void Initialize()
        {
            if (_destroyed)
            {
                throw new Exception("SceneManager has been destroyed.");
            }

            initialize();
        }
        public void Prepare()
        {
            if (_destroyed)
            {
                throw new Exception("SceneManager has been destroyed.");
            }

            prepare();
        }
        public void Update()
        {
            if (_destroyed)
            {
                throw new Exception("SceneManager has been destroyed.");
            }

            update();
        }
        public void Cleanup()
        {
            if (_destroyed)
            {
                throw new Exception("SceneManager has been destroyed.");
            }

            cleanup();
        }
        public void Render()
        {
            if (_destroyed)
            {
                throw new Exception("SceneManager has been destroyed.");
            }

            render();
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