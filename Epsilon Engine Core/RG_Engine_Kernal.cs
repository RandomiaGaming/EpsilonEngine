using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics.Tracing;
using System.Drawing;

namespace Epsilon_Engine
{
    public sealed class Epsilon_Engine_Kernal : Game
    {
        private GraphicsDeviceManager GDM;
        private GraphicsDevice GD;
        private SpriteBatch SB;

        public Epsilon_Engine_Kernal()
        {
            Content.RootDirectory = "Assets";
            GDM = new GraphicsDeviceManager(this);
        }
        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            base.LoadContent();
            GD = GDM.GraphicsDevice;
            SB = new SpriteBatch(GD);
        }
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GD.Clear(new Microsoft.Xna.Framework.Color(255, 0, 255));
            SB.Begin();
            Texture2D Frame = new Texture2D(GD, GD.Viewport.Width, GD.Viewport.Height);
            SB.Draw(Frame, new Vector2(0.5f, 0.5f));
            SB.End();
            base.Draw(gameTime);
        }
    }
}
