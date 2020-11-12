namespace EpsilonEngine
{
    public class TextureSheet
    {
        public readonly Texture data;
        public readonly int tileWidth;
        public readonly int tileHeight;

        public Texture GetTexture(int x, int y)
        {
            Texture output = new Texture(tileWidth, tileHeight, Color.Clear);
            output.Blitz(data, -tileWidth * x, -tileHeight * y);
            return output;
        }
        public TextureSheet(Texture data, int tileWidth, int tileHeight)
        {
            this.data = data;
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
        }
    }
}
