namespace Epsilon_Engine
{
    public abstract class Component
    {
        public Component() { }
        public virtual void Update(Game_Object Parent_Game_Object, double Delta_Time) { }
        public virtual void Initialize(Game_Object Parent_Game_Object) { }
    }
}