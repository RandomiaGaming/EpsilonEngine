using System;
namespace EpsilonEngine
{
    public abstract class GameManager
    {
        public bool destroyed { get; private set; } = false;
        public Game game
        {
            get
            {
                if (!destroyed)
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
                throw new NullReferenceException();
            }
            _game = game;
            _game.AddGameManager(this);
        }
        public void CallDestroy()
        {
            if (destroyed)
            {
                throw new Exception("GameManager has been destroyed.");
            }
            Destroy();
            _game.RemoveGameManager(this);
            destroyed = true;
        }
        public void CallInitialize()
        {
            if (destroyed)
            {
                throw new Exception("GameManager has been destroyed.");
            }
            Initialize();
        }
        public void CallPrepare()
        {
            if (destroyed)
            {
                throw new Exception("GameManager has been destroyed.");
            }
            Prepare();
        }
        public void CallUpdate()
        {
            if (destroyed)
            {
                throw new Exception("GameManager has been destroyed.");
            }
            Update();
        }
        public void CallCleanup()
        {
            if (destroyed)
            {
                throw new Exception("GameManager has been destroyed.");
            }
            Cleanup();
        }
        public RenderTexture CallRender()
        {
            if (destroyed)
            {
                throw new Exception("GameManager has been destroyed.");
            }
            return Render();
        }
        protected virtual void Destroy()
        {

        }
        protected virtual void Initialize()
        {

        }
        protected virtual void Prepare()
        {

        }
        protected virtual void Update()
        {

        }
        protected virtual void Cleanup()
        {

        }
        protected virtual RenderTexture Render()
        {
            return new RenderTexture();
        }
    }
}