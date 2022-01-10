using System;

namespace EpsilonEngine
{
    public sealed class GameInterface : Microsoft.Xna.Framework.Game
    {
        #region Contants
        private static readonly Microsoft.Xna.Framework.Color errorPink = new Microsoft.Xna.Framework.Color(255, 0, 255, 255);
        #endregion
        #region Variables
        private Microsoft.Xna.Framework.GraphicsDeviceManager _graphicsDeviceManager = null;
        private Game _game = null;
        private TimeSpan _timeSinceStart = new TimeSpan(0);
        private TimeSpan _deltaTime = new TimeSpan(0);
        private string _name = "Unnamed Game Interface";
        private bool _destroyed = false;
        #endregion
        #region Properties
        public Microsoft.Xna.Framework.GameWindow GameWindow
        {
            get
            {
                return Window;
            }
        }
        public Microsoft.Xna.Framework.GraphicsDeviceManager GraphicsDeviceManager
        {
            get
            {
                return graphics;
            }
        }
        public Game Game
        {
            get
            {
                return _game;
            }
        }
        public TimeSpan TimeSinceStart
        {
            get
            {
                return _timeSinceStart;
            }
        }
        public TimeSpan DeltaTime
        {
            get
            {
                return _deltaTime;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if(de)
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
            base.Window.Title = "Unnamed Game";

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
            if (_game is null)
            {
                throw new Exception("Cannot run game interface until game is set.");
            }
            _game.Initialize();

            base.Initialize();
        }
        protected sealed override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
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
            if (_game is null)
            {
                throw new Exception("Cannot run game interface until game is set.");
            }

            GraphicsDevice.Clear(errorPink);

            _game.Render();

            base.Draw(gameTime);
        }
        protected override void Dispose(bool disposing)
        {
            if (!(_game is null))
            {
                _game.Destroy();
            }

            base.Dispose(disposing);
        }
        protected override void OnExiting(object sender, EventArgs args)
        {
            if (!(_game is null))
            {
                _game.Destroy();
            }

            this.Dispose();

            base.OnExiting(sender, args);
        }
        public override string ToString()
        {
            return $"EpsilonEngine.GameInterface({_name})";
        }
        #endregion
        #region Methods
        internal void SetGame(Game game)
        {
            if (game is null)
            {
                throw new Exception("game was null.");
            }
            _game = game;
        }
        public void Destroy()
        {
            if (!(_game is null))
            {
                _game.Destroy();
            }

            this.Dispose();
        }
        #endregion
    }
}