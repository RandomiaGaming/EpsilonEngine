using System;

namespace EpsilonEngine
{
    public class GameInterface : Microsoft.Xna.Framework.Game
    {
        private Game _game = null;
        public Game game
        {
            get
            {
                return _game;
            }
        }
        public GameInterface(Game game)
        {
            if (game is null)
            {
                throw new NullReferenceException();
            }
            _game = game;
            _game.SetMonoGameInterface(this);

            graphics = new Microsoft.Xna.Framework.GraphicsDeviceManager(this)
            {
                SynchronizeWithVerticalRetrace = false
            };

            Window.AllowUserResizing = true;
            Window.AllowAltF4 = true;
            Window.IsBorderless = false;
            Window.Title = game.name;
            IsMouseVisible = true;
            IsFixedTimeStep = true;
            TargetElapsedTime = new TimeSpan(10000000 / 60);
        }

        private Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch = null;
        private Microsoft.Xna.Framework.Graphics.RenderTarget2D renderTarget;
        private Microsoft.Xna.Framework.GraphicsDeviceManager graphics;
        protected override void Initialize()
        {
            base.Initialize();

            spriteBatch = new Microsoft.Xna.Framework.Graphics.SpriteBatch(GraphicsDevice);

            renderTarget = new Microsoft.Xna.Framework.Graphics.RenderTarget2D(GraphicsDevice, 64, 64, false, Microsoft.Xna.Framework.Graphics.SurfaceFormat.Color, Microsoft.Xna.Framework.Graphics.DepthFormat.None);

            thatOneTexture = new Microsoft.Xna.Framework.Graphics.Texture2D(GraphicsDevice, 32, 32);
            Microsoft.Xna.Framework.Color[] textureBuffer = new Microsoft.Xna.Framework.Color[32 * 32];
            int i = 0;
            for (int y = 32 - 1; y >= 0; y--)
            {
                for (int x = 0; x < 32; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        textureBuffer[i] = new Microsoft.Xna.Framework.Color(255, 255, 255, 255);
                    }
                    else
                    {
                        textureBuffer[i] = new Microsoft.Xna.Framework.Color(0, 0, 0, 255);
                    }
                    i++;
                }
            }
            thatOneTexture.SetData(textureBuffer);
        }
        protected override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
        }
        protected override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            //Small Rendering
            GraphicsDevice.SetRenderTarget(renderTarget);
            GraphicsDevice.Clear(backgroundColor);
            spriteBatch.Begin(samplerState: Microsoft.Xna.Framework.Graphics.SamplerState.PointClamp);
            spriteBatch.Draw(thatOneTexture, new Microsoft.Xna.Framework.Rectangle(0, 0, 32, 32), new Microsoft.Xna.Framework.Rectangle(0, 0, thatOneTexture.Width, thatOneTexture.Height), Microsoft.Xna.Framework.Color.White, 0, new Microsoft.Xna.Framework.Vector2(0, 0), Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 0);
            spriteBatch.End();
            GraphicsDevice.SetRenderTarget(null);
            //Big Rendering
            GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.Black);
            spriteBatch.Begin(samplerState: Microsoft.Xna.Framework.Graphics.SamplerState.PointClamp);
            spriteBatch.Draw(renderTarget, new Microsoft.Xna.Framework.Rectangle(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), new Microsoft.Xna.Framework.Rectangle(0, 0, renderTarget.Width, renderTarget.Height), Microsoft.Xna.Framework.Color.White, 0f, new Microsoft.Xna.Framework.Vector2(renderTarget.Width / 2.0f, renderTarget.Height / 2.0f), Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 0);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}