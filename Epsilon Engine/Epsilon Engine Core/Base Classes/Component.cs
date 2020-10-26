namespace EpsilonEngine
{
    public abstract class Component
    {
        public bool enabled = true;
        public readonly GameObject parent = null;
        public virtual void Update()
        {

        }
        public virtual void Initialize()
        {

        }
    }
}