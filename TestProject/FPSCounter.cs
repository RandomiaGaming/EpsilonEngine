using EpsilonEngine;
namespace DMCCR
{
    public sealed class FPSCounter : SceneManager
    {
        private Texture Font0;
        private Texture Font1;
        private Texture Font2;
        private Texture Font3;
        private Texture Font4;
        private Texture Font5;
        private Texture Font6;
        private Texture Font7;
        private Texture Font8;
        private Texture Font9;
        public FPSCounter(Scene scene) : base(scene, 0, int.MaxValue)
        {
            Font0 = new Texture(Game, System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("DMCCR.Don_t_Melt____Crystal_Caves_Remastered_.Textures.0.png"));
            Font1 = new Texture(Game, System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("DMCCR.Don_t_Melt____Crystal_Caves_Remastered_.Textures.1.png"));
            Font2 = new Texture(Game, System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("DMCCR.Don_t_Melt____Crystal_Caves_Remastered_.Textures.2.png"));
            Font3 = new Texture(Game, System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("DMCCR.Don_t_Melt____Crystal_Caves_Remastered_.Textures.3.png"));
            Font4 = new Texture(Game, System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("DMCCR.Don_t_Melt____Crystal_Caves_Remastered_.Textures.4.png"));
            Font5 = new Texture(Game, System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("DMCCR.Don_t_Melt____Crystal_Caves_Remastered_.Textures.5.png"));
            Font6 = new Texture(Game, System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("DMCCR.Don_t_Melt____Crystal_Caves_Remastered_.Textures.6.png"));
            Font7 = new Texture(Game, System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("DMCCR.Don_t_Melt____Crystal_Caves_Remastered_.Textures.7.png"));
            Font8 = new Texture(Game, System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("DMCCR.Don_t_Melt____Crystal_Caves_Remastered_.Textures.8.png"));
            Font9 = new Texture(Game, System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("DMCCR.Don_t_Melt____Crystal_Caves_Remastered_.Textures.9.png"));
        }
        protected override void Render()
        {
            string currentFPSString = Game.CurrentFPS.ToString();

            char[] currentFPSChars = currentFPSString.ToCharArray();

            int currentFPSCharsLength = currentFPSChars.Length;

            int offset = 0;
            for (int i = 0; i < currentFPSCharsLength; i++)
            {
                char c = currentFPSChars[i];

                if (c == '0')
                {
                    Scene.DrawTextureScreenSpaceUnsafe(Font0._xnaTexture, new Microsoft.Xna.Framework.Vector2(offset, 0), Microsoft.Xna.Framework.Color.White);
                }
                else if (c == '1')
                {
                    Scene.DrawTextureScreenSpaceUnsafe(Font1._xnaTexture, new Microsoft.Xna.Framework.Vector2(offset, 0), Microsoft.Xna.Framework.Color.White);
                }
                else if (c == '2')
                {
                    Scene.DrawTextureScreenSpaceUnsafe(Font2._xnaTexture, new Microsoft.Xna.Framework.Vector2(offset, 0), Microsoft.Xna.Framework.Color.White);
                }
                else if (c == '3')
                {
                    Scene.DrawTextureScreenSpaceUnsafe(Font3._xnaTexture, new Microsoft.Xna.Framework.Vector2(offset, 0), Microsoft.Xna.Framework.Color.White);
                }
                else if (c == '4')
                {
                    Scene.DrawTextureScreenSpaceUnsafe(Font4._xnaTexture, new Microsoft.Xna.Framework.Vector2(offset, 0), Microsoft.Xna.Framework.Color.White);
                }
                else if (c == '5')
                {
                    Scene.DrawTextureScreenSpaceUnsafe(Font5._xnaTexture, new Microsoft.Xna.Framework.Vector2(offset, 0), Microsoft.Xna.Framework.Color.White);
                }
                else if (c == '6')
                {
                    Scene.DrawTextureScreenSpaceUnsafe(Font6._xnaTexture, new Microsoft.Xna.Framework.Vector2(offset, 0), Microsoft.Xna.Framework.Color.White);
                }
                else if (c == '7')
                {
                    Scene.DrawTextureScreenSpaceUnsafe(Font7._xnaTexture, new Microsoft.Xna.Framework.Vector2(offset, 0), Microsoft.Xna.Framework.Color.White);
                }
                else if (c == '8')
                {
                    Scene.DrawTextureScreenSpaceUnsafe(Font8._xnaTexture, new Microsoft.Xna.Framework.Vector2(offset, 0), Microsoft.Xna.Framework.Color.White);
                }
                else
                {
                    Scene.DrawTextureScreenSpaceUnsafe(Font9._xnaTexture, new Microsoft.Xna.Framework.Vector2(offset, 0), Microsoft.Xna.Framework.Color.White);
                }

                offset += 11;
            }
        }
    }
}
