namespace RG_Engine.Internal
{
    public abstract class RG_Renderer
    {
        public abstract RG_Texture Render();
        public virtual void Initialize() { }
    }
}
