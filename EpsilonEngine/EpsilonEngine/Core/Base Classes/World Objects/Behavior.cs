using System;
namespace EpsilonEngine
{
    public abstract class Component
    {
        public bool destroyed { get; private set; } = false;
        public Game game
        {
            get
            {
                if (!destroyed)
                {
                    throw new Exception("Component has been destroyed.");
                }
                return _gameObject.game;
            }
        }
        public Scene scene
        {
            get
            {
                if (destroyed)
                {
                    throw new Exception("Component has been destroyed.");
                }
                return _gameObject.scene;
            }
        }
        public GameObject gameObject
        {
            get
            {
                if (destroyed)
                {
                    throw new Exception("Component has been destroyed.");
                }
                return _gameObject;
            }
        }
        private GameObject _gameObject = null;
        public Component(GameObject gameObject)
        {
            if (gameObject is null)
            {
                throw new NullReferenceException();
            }
            _gameObject = gameObject;
            _gameObject.AddComponent(this);
        }
        public void CallDestroy()
        {
            if (destroyed)
            {
                throw new Exception("Component has been destroyed.");
            }
            Destroy();
            _gameObject.RemoveComponent(this);
            destroyed = true;
        }
        public void CallInitialize()
        {
            if (destroyed)
            {
                throw new Exception("Component has been destroyed.");
            }
            Initialize();
        }
        public void CallPrepare()
        {
            if (destroyed)
            {
                throw new Exception("Component has been destroyed.");
            }
            Prepare();
        }
        public void CallUpdate()
        {
            if (destroyed)
            {
                throw new Exception("Component has been destroyed.");
            }
            Update();
        }
        public void CallCleanup()
        {
            if (destroyed)
            {
                throw new Exception("Component has been destroyed.");
            }
            Cleanup();
        }
        public RenderTexture CallRender()
        {
            if (destroyed)
            {
                throw new Exception("Component has been destroyed.");
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