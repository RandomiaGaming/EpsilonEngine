using System.Collections.Generic;

namespace Epsilon_Engine
{
    public sealed class Game_Object
    {
        private List<Component> Components = new List<Component>();
        public List<Component> Get_Component_List()
        {
            return new List<Component>(Components);
        }
        public List<T> Get_Components<T>() where T : Component, new()
        {
            List<T> Output = new List<T>();
            foreach (Component C in Components)
            {
                if (C.GetType() == typeof(T))
                {
                    Output.Add((T)C);
                }
            }
            return Output;
        }
        public Component Get_Component(int Index)
        {
            if (Index < 0 || Index >= Components.Count)
            {
                return null;
            }
            else
            {
                return Components[Index];
            }
        }
        public T Get_Component<T>() where T : Component, new()
        {
            foreach (Component C in Components)
            {
                if (C.GetType() == typeof(T))
                {
                    return (T)C;
                }
            }
            return null;
        }
        public int Get_Component_Count()
        {
            return Components.Count;
        }
        public void Add_Component<T>() where T : Component, new()
        {
            Components.Add(new T());
        }
        public void Add_Component(Component New_Component)
        {
            Components.Add(New_Component);
        }
        public void Initialize()
        {
            foreach (Component C in Components)
            {
                C.Initialize(this);
            }
        }
        public void Update(double Delta_Time)
        {
            foreach (Component C in Components)
            {
                C.Update(this, Delta_Time);
            }
        }
        private Game_Object() { }
        public static Game_Object Create()
        {
            return new Game_Object();
        }
    }
}