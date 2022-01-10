using System;
namespace EpsilonEngine
{
    public abstract class GameManager
    {
        public bool destroyed
        {
            get
            {
                return _destroyed;
            }
        }
        private bool _destroyed = false;
        public Game game
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
        private Game _game = null;
        public GameManager(Game game)
        {
            if (game is null)
            {
                throw new Exception("game was null.");
            }
            _game = game;
            _game.AddGameManager(this);
        }
        #region Methods
        public void Destroy()
        {
            if (_destroyed)
            {
                throw new Exception("GameManager has been destroyed.");
            }
            onDestroy();
            _game.RemoveGameManager(this);
            _destroyed = true;
        }
        internal void Initialize()
        {
            if (_destroyed)
            {
                throw new Exception("GameManager has been destroyed.");
            }
            initialize();
        }
        internal void Prepare()
        {
            if (_destroyed)
            {
                throw new Exception("GameManager has been destroyed.");
            }
            prepare();
        }
        internal void Update()
        {
            if (_destroyed)
            {
                throw new Exception("GameManager has been destroyed.");
            }
            update();
        }
        internal void Cleanup()
        {
            if (_destroyed)
            {
                throw new Exception("GameManager has been destroyed.");
            }
            cleanup();
        }
        internal void Render()
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