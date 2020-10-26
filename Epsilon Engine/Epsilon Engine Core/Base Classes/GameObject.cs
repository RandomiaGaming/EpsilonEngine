using System;
using System.Collections.Generic;
namespace EpsilonEngine
{
    public class GameObject
    {
        public string name = "Unnamed Gameobject";
        protected List<Component> components = new List<Component>();
        #region Creation methods.
        protected GameObject()
        {
            name = "Unnamed Gameobject";
            components = new List<Component>();
        }
        public virtual GameObject Create()
        {
            GameObject output = new GameObject
            {
                name = "Unnamed Gameobject",
                components = new List<Component>()
            };
            return output;
        }
        public virtual GameObject Create(string name)
        {
            GameObject output = new GameObject
            {
                name = name,
                components = new List<Component>()
            };
            return output;
        }
        public virtual GameObject Create(List<Component> components)
        {
            GameObject output = new GameObject
            {
                name = "Unnamed Gameobject",
                components = new List<Component>(components)
            };
            return output;
        }
        public virtual GameObject Create(string name, List<Component> components)
        {
            GameObject output = new GameObject
            {
                name = name,
                components = new List<Component>(components)
            };
            return output;
        }
        #endregion
        #region Component managment methods.
        public int GetComponentCount()
        {
            if (components is null)
            {
                components = new List<Component>();
            }
            return components.Count;
        }
        public Component GetComponent(int index)
        {
            if (components is null)
            {
                components = new List<Component>();
            }
            if (index < 0 || index >= components.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                return components[index];
            }
        }
        public void AddComponent(Component newComponent)
        {
            if (components is null)
            {
                components = new List<Component>();
            }
            components.Add(newComponent);
        }
        public void RemoveComponent(int index)
        {
            if (components is null)
            {
                components = new List<Component>();
            }
            components.RemoveAt(index); ;
        }
#endregion
        #region Update and initialize methods.
        public virtual void Initialize()
        {
            foreach (Component c in components)
            {
                c.Initialize();
            }
        }
        public virtual void Update()
        {
            foreach (Component c in components)
            {
                c.Update();
            }
        }
        #endregion
    }
}