using System;
namespace EpsilonEngine
{
    public abstract class GameManager
    {
        #region Variables
        public string _name = "Unnamed Game Manager";
        private bool _destroyed = false;
        private Game _game;
        #endregion
        #region Properties
        public GameInterface GameInterface
        {
            get
            {
                if (_destroyed)
                {
                    throw new Exception("GameManager has been destroyed.");
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
                    throw new Exception("GameManager has been destroyed.");
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
                    throw new Exception("GameManager has been destroyed.");
                }
                return _name;
            }
            set
            {
                if (_destroyed)
                {
                    throw new Exception("GameManager has been destroyed.");
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
        public GameManager(Game game)
        {
            if (game is null)
            {
                throw new Exception("game cannot be null.");
            }

            _game = game;

            _game.AddGameManager(this);
        }
        #endregion
        #region Overrides
        public override string ToString()
        {
            if (_destroyed)
            {
                throw new Exception("GameManager has been destroyed.");
            }

            return $"EpsilonEngine.GameManager({_name})";
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
                throw new Exception("GameManager has been destroyed.");
            }

            initialize();
        }
        public void Prepare()
        {
            if (_destroyed)
            {
                throw new Exception("GameManager has been destroyed.");
            }

            prepare();
        }
        public void Update()
        {
            if (_destroyed)
            {
                throw new Exception("GameManager has been destroyed.");
            }

            update();
        }
        public void Cleanup()
        {
            if (_destroyed)
            {
                throw new Exception("GameManager has been destroyed.");
            }

            cleanup();
        }
        public void Render()
        {
            if (_destroyed)
            {
                throw new Exception("GameManager has been destroyed.");
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