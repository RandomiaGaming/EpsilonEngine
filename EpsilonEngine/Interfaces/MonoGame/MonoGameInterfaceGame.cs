using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace EpsilonEngine.Interfaces.MonoGame
{
    public class MonoGameInterfaceGame : Game
    {
        private readonly MonoGameInterface gameInterface = null;
        public MonoGameInterfaceGame(MonoGameInterface gameInterface)
        {
            if (gameInterface is null)
            {
                throw new NullReferenceException();
            }
            this.gameInterface = gameInterface;

            _ = new GraphicsDeviceManager(this)
            {
                SynchronizeWithVerticalRetrace = false
            };
            Window.AllowUserResizing = true;
            Window.AllowAltF4 = true;
            Window.IsBorderless = false;
            Window.Title = "EpsilonEngine - RandomiaGaming";
            IsMouseVisible = true;
            IsFixedTimeStep = false;
            TargetElapsedTime = new TimeSpan(10000000 / 60);
        }
        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void Update(GameTime gameTime)
        {
            Console.WriteLine($"{gameTime.ElapsedGameTime.Ticks / 1000}k TPF which is {(int)(1.0 / (gameTime.ElapsedGameTime.Ticks / 10000000.0))} FPS.");
            gameInterface.MonoGameUpdateCallBack();
            base.Update(gameTime);
            if (gameInterface.game.requestingToQuit)
            {
                base.Exit();
            }
        }
        protected override void Draw(GameTime gameTime)
        {
            Texture frameBuffer = gameInterface.frameBuffer;
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
                spriteBatch.Draw(frame, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Microsoft.Xna.Framework.Color.White);
                spriteBatch.End();
            }
            base.Draw(gameTime);
        }
    }
}