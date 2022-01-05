using System.Collections.Generic;
namespace EpsilonEngine
{
    public sealed class RenderTexture
    {
        public List<RenderInstruction> buffer = new List<RenderInstruction>();
        public Texture Render(PointRect bounds)
        {
            Texture output = new Texture(bounds.max.x - bounds.min.x, bounds.max.y - bounds.min.y, Color.Clear);
            foreach (RenderInstruction renderInstruction in buffer)
            {
                    TextureHelper.Blitz(renderInstruction.texture, output, new Point(renderInstruction.position.x - bounds.min.x, renderInstruction.position.y - bounds.min.y));
            }
            return output;
        }
        public Texture Render(PointRect bounds, Color backgroundColor)
        {
            Texture output = new Texture(bounds.max.x - bounds.min.x, bounds.max.y - bounds.min.y, backgroundColor);
            foreach (RenderInstruction renderInstruction in buffer)
            {
                TextureHelper.Blitz(renderInstruction.texture, output, new Point(renderInstruction.position.x - bounds.min.x, renderInstruction.position.y - bounds.min.y));
            }
            return output;
        }
        public void Draw(Texture texture, Point position)
        {
            buffer.Add(new RenderInstruction(texture, position));
        }
        public void Merge(RenderTexture other)
        {
            buffer.AddRange(other.buffer);
        }
        public void Offset(Point offset)
        {
            for (int i = 0; i < buffer.Count; i++)
            {
                buffer[i].position += offset;
            }
        }
    }
}