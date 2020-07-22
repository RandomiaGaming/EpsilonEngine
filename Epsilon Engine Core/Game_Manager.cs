namespace Epsilon_Engine
{
    public abstract class Game_Manager
    {
        public Game_Manager() { }
        public virtual void Initialize() { }
        public virtual void Update(double Delta_Time) { }
    }
}