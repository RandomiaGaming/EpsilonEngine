using System;
using System.Collections.Generic;

namespace Epsilon_Engine
{
    public sealed class RG_Game_Object
    {
        private List<RG_Component> Components = new List<RG_Component>();
        public List<RG_Component> Get_Component_List()
        {
            return new List<RG_Component>(Components);
        }
        public List<T> Get_Components<T>() where T : RG_Component, new()
        {
            List<T> Output = new List<T>();
            foreach (RG_Component C in Components)
            {
                if (C.GetType() == typeof(T))
                {
                    Output.Add((T)C);
                }
            }
            return Output;
        }
        public RG_Component Get_Component(int Index)
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
        public T Get_Component<T>() where T : RG_Component, new()
        {
            foreach (RG_Component C in Components)
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
        public void Add_Component<T>() where T : RG_Component
        {
           // Components.Add((RG_Component)T.Create());
        }
        public void Add_Component(RG_Component New_Component)
        {
            Components.Add(New_Component);
        }
        public void Initialize()
        {
            foreach (RG_Component C in Components)
            {
                C.Initialize(this);
            }
        }
        public void Update(double Delta_Time)
        {
            foreach (RG_Component C in Components)
            {
                C.Update(this, Delta_Time);
            }
        }
        private RG_Game_Object() { }
        public static RG_Game_Object Create()
        {
            return new RG_Game_Object();
        }
    }
}