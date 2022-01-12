using System;

namespace EpsilonEngine
{
    public sealed class GameInterface : Microsoft.Xna.Framework.Game
    {
        #region Variables
        private Microsoft.Xna.Framework.GraphicsDeviceManager _graphicsDeviceManager = null;
        private Game _game = null;
        private TimeSpan _timeSinceStart = new TimeSpan(0);
        private TimeSpan _deltaTime = new TimeSpan(0);
        private string _name = "Unnamed Game Interface";
        private bool _destroyed = false;
        private bool _running = false;
        #endregion
        #region Properties
        public Microsoft.Xna.Framework.GameWindow GameWindow
        {
            get
            {
                if (_destroyed)
                {
                    throw new Exception("GameInterface has been destroyed.");
                }
                return Window;
            }
        }
        public Microsoft.Xna.Framework.GraphicsDeviceManager GraphicsDeviceManager
        {
            get
            {
                if (_destroyed)
                {
                    throw new Exception("GameInterface has been destroyed.");
                }
                return _graphicsDeviceManager;
            }
        }
        public Game Game
        {
            get
            {
                if (_destroyed)
                {
                    throw new Exception("GameInterface has been destroyed.");
                }
                return _game;
            }
        }
        public TimeSpan TimeSinceStart
        {
            get
            {
                if (_destroyed)
                {
                    throw new Exception("GameInterface has been destroyed.");
                }
                return _timeSinceStart;
            }
        }
        public TimeSpan DeltaTime
        {
            get
            {
                if (_destroyed)
                {
                    throw new Exception("GameInterface has been destroyed.");
                }
                return _deltaTime;
            }
        }
        public string Name
        {
            get
            {
                if (_destroyed)
                {
                    throw new Exception("GameInterface has been destroyed.");
                }
                return _name;
            }
            set
            {
                if (_destroyed)
                {
                    throw new Exception("GameInterface has been destroyed.");
                }
                _name = value;
            }
        }
        public bool Running
        {
            get
            {
                if (_destroyed)
                {
                    throw new Exception("GameInterface has been destroyed.");
                }
                return _running;
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
        public GameInterface()
        {
            _graphicsDeviceManager = new Microsoft.Xna.Framework.GraphicsDeviceManager(this);

            _graphicsDeviceManager.GraphicsProfile = Microsoft.Xna.Framework.Graphics.GraphicsProfile.Reach;
            _graphicsDeviceManager.HardwareModeSwitch = true;
            _graphicsDeviceManager.IsFullScreen = false;
            _graphicsDeviceManager.PreferHalfPixelOffset = false;
            _graphicsDeviceManager.PreferMultiSampling = false;
            _graphicsDeviceManager.PreferredBackBufferFormat = Microsoft.Xna.Framework.Graphics.SurfaceFormat.Color;
            _graphicsDeviceManager.PreferredBackBufferWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            _graphicsDeviceManager.PreferredBackBufferHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height;
            _graphicsDeviceManager.SupportedOrientations = Microsoft.Xna.Framework.DisplayOrientation.LandscapeLeft | Microsoft.Xna.Framework.DisplayOrientation.LandscapeRight | Microsoft.Xna.Framework.DisplayOrientation.Portrait | Microsoft.Xna.Framework.DisplayOrientation.PortraitDown | Microsoft.Xna.Framework.DisplayOrientation.Unknown | Microsoft.Xna.Framework.DisplayOrientation.Default;
            _graphicsDeviceManager.SynchronizeWithVerticalRetrace = false;

            _graphicsDeviceManager.ApplyChanges();

            base.GraphicsDevice.BlendState = Microsoft.Xna.Framework.Graphics.BlendState.AlphaBlend;
            base.GraphicsDevice.DepthStencilState = Microsoft.Xna.Framework.Graphics.DepthStencilState.None;
            base.GraphicsDevice.RasterizerState = Microsoft.Xna.Framework.Graphics.RasterizerState.CullNone;
            base.GraphicsDevice.ScissorRectangle = new Microsoft.Xna.Framework.Rectangle();
            base.GraphicsDevice.Viewport = new Microsoft.Xna.Framework.Graphics.Viewport(0, 0, GraphicsDevice.Adapter.CurrentDisplayMode.Width, GraphicsDevice.Adapter.CurrentDisplayMode.Height);

            base.Content = null;
            base.Window.AllowAltF4 = true;
            base.Window.AllowUserResizing = true;
            base.Window.IsBorderless = false;
            base.Window.Position = new Microsoft.Xna.Framework.Point();
            base.Window.Title = _name;

            base.InactiveSleepTime = new TimeSpan(10000000 * 3);
            base.IsFixedTimeStep = false;
            base.IsMouseVisible = true;
            base.MaxElapsedTime = new TimeSpan(10000000 / 30);
            base.TargetElapsedTime = new TimeSpan(10000000 / 60);
        }
        #endregion
        #region Overrides
        protected sealed override void Initialize()
        {
            if (_destroyed)
            {
                throw new Exception("GameInterface has been destroyed.");
            }

            if (_game is null)
            {
                throw new Exception("Cannot run game interface until game is set.");
            }
            _running = true;

            _game.Initialize();

            base.Initialize();
        }
        protected sealed override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (_destroyed)
            {
                throw new Exception("GameInterface has been destroyed.");
            }

            if (_game is null)
            {
                throw new Exception("Cannot run game interface until game is set.");
            }

            _timeSinceStart = gameTime.TotalGameTime;
            _deltaTime = gameTime.ElapsedGameTime;

            _game.Update();

            base.Update(gameTime);
        }
        protected sealed override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (_destroyed)
            {
                throw new Exception("GameInterface has been destroyed.");
            }

            if (_game is null)
            {
                throw new Exception("Cannot run game interface until game is set.");
            }

            GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.Black);

            _game.Render();

            base.Draw(gameTime);
        }
        protected override void Dispose(bool disposing)
        {
            DestroyWithoutDispose();
            base.Dispose(disposing);
        }
        protected override void OnExiting(object sender, EventArgs args)
        {
            Destroy();
        }
        public override string ToString()
        {
            if (_destroyed)
            {
                throw new Exception("GameInterface has been destroyed.");
            }

            return $"EpsilonEngine.GameInterface({_name})";
        }
        #endregion
        #region Methods
        internal void SetGame(Game game)
        {
            if (_running)
            {
                throw new Exception("game cannot be set while running.");
            }
            if (game is null)
            {
                throw new Exception("game was null.");
            }
            _game = game;
        }
        public void Destroy()
        {
            if (_destroyed)
            {
                return;
            }

            DestroyWithoutDispose();

            this.Dispose();
        }
        #region Private Methods
        private void DestroyWithoutDispose()
        {
            if (_destroyed)
            {
                return;
            }

            if (!(_game is null))
            {
                _game.Destroy();
            }
            _destroyed = true;
        }
        #endregion
        #endregion
    }
}