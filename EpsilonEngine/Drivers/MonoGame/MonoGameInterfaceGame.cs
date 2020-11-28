using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace EpsilonEngine.Drivers.MonoGame
{
    public class MonogameInterfaceGame : Microsoft.Xna.Framework.Game
    {
        private readonly MonoGameInterface gameInterface = null;
        public MonogameInterfaceGame(MonoGameInterface gameInterface)
        {
            if(gameInterface is null)
            {
                throw new NullReferenceException();
            }
            this.gameInterface = gameInterface;

            GraphicsDeviceManager graphics = new GraphicsDeviceManager(this)
            {
                SynchronizeWithVerticalRetrace = false
            };
            Window.AllowUserResizing = true;
            Window.AllowAltF4 = true;
            Window.IsBorderless = false;
            Window.Title = "EpsilonEngine - RandomiaGaming";
            IsMouseVisible = true;
            IsFixedTimeStep = true;
            TargetElapsedTime = new TimeSpan(10000000 / 60);
        }
        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void Update(GameTime gameTime)
        {
            gameInterface.Tick();
            base.Update(gameTime);

            if (gameInterface.game.requestingToQuit)
            {
                base.Exit();
            }
        }
        protected override void Draw(GameTime gameTime)
        {
            Texture frameBuffer = ((MonoGameGraphicsDriver)gameInterface.graphicsDriver).frameBuffer;
            if (frameBuffer != null)
            {
                Texture2D frame = new Texture2D(GraphicsDevice, frameBuffer.width, frameBuffer.height);
                Microsoft.Xna.Framework.Color[] data = new Microsoft.Xna.Framework.Color[frameBuffer.width * frameBuffer.height];
                int i = 0;
                for (int y = 0; y < frameBuffer.height; y++)
                {
                    for (int x = 0; x < frameBuffer.width; x++)
                    {
                        Color pixelColor = frameBuffer.GetPixelUnsafe(x, frameBuffer.height - y - 1);
                        data[i] = new Microsoft.Xna.Framework.Color(pixelColor.r, pixelColor.g, pixelColor.b);
                        i++;
                    }
                }
                frame.SetData(data);
                SpriteBatch spriteBatch = new SpriteBatch(GraphicsDevice);
                spriteBatch.Begin(samplerState: SamplerState.PointClamp);
                spriteBatch.Draw(frame, new Microsoft.Xna.Framework.Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Microsoft.Xna.Framework.Color.White);
                spriteBatch.End();
            }
            base.Draw(gameTime);
        }
    }
}