using System;
using System.Collections.Generic;
namespace EpsilonEngine
{
    public sealed class DefaultGameObject : GameObjectBase
    {
        private List<ComponentBase> components = new List<ComponentBase>();
        private List<int> componentsToRemove = new List<int>();
        private List<ComponentBase> componentsToAdd = new List<ComponentBase>();

        public DefaultGameObject(SceneBase scene) : base(scene)
        {

        }
        public override void Initialize()
        {

        }
        public override void Update()
        {
            foreach (ComponentBase c in components)
            {
                c.Update();
            }
        }

        public override void Cleanup()
        {
            if (componentsToRemove is null)
            {
                componentsToRemove = new List<int>();
            }
            componentsToRemove.Sort();
            foreach (int componentID in componentsToRemove)
            {
                components.RemoveAt(componentID);
            }
            componentsToRemove = new List<int>();

            foreach (ComponentBase componentToAdd in componentsToAdd)
            {
                components.Add(componentToAdd);
            }
            foreach (ComponentBase componentToAdd in componentsToAdd)
            {
                componentToAdd.Initialize();
            }
            componentsToAdd = new List<ComponentBase>();
        }

        #region Component Management Methods
        public ComponentBase GetComponent(int index)
        {
            if (components is null)
            {
                components = new List<ComponentBase>();
                return null;
            }
            if (index < 0 || index >= components.Count)
            {
                throw new ArgumentException();
            }
            return components[index];
        }
        public ComponentBase GetComponent(Type targetType)
        {
            if (components is null)
            {
                components = new List<ComponentBase>();
                return null;
            }
            if (targetType is null)
            {
                throw new NullReferenceException();
            }
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i].GetType().IsAssignableFrom(targetType))
                {
                    return components[i];
                }
            }
            return null;
        }
        public T GetComponent<T>() where T : ComponentBase
        {
            if (components is null)
            {
                components = new List<ComponentBase>();
                return null;
            }
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i].GetType().IsAssignableFrom(typeof(T)))
                {
                    return (T)components[i];
                }
            }
            return null;
        }
        public List<ComponentBase> GetComponents()
        {
            return new List<ComponentBase>(components);
        }
        public List<ComponentBase> GetComponents(Type targetType)
        {
            if (components is null)
            {
                components = new List<ComponentBase>();
                return null;
            }
            if(targetType is null)
            {
                throw new NullReferenceException();
            }
            List<ComponentBase> output = new List<ComponentBase>();
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i].GetType().IsAssignableFrom(targetType))
                {
                    output.Add(components[i]);
                }
            }
            return output;
        }
        public List<T> GetComponents<T>() where T : ComponentBase
        {
            if (components is null)
            {
                components = new List<ComponentBase>();
                return null;
            }
            List<T> output = new List<T>();
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i].GetType().IsAssignableFrom(typeof(T)))
                {
                    output .Add((T)components[i]);
                }
            }
            return output;
        }
        public int GetComponentCount()
        {
            if (components is null)
            {
                components = new List<ComponentBase>();
                return 0;
            }
            return components.Count;
        }
        public void RemoveComponent(int index)
        {
            if (components is null)
            {
                components = new List<ComponentBase>();
                return;
            }
            if (index < 0 || index >= components.Count)
            {
                throw new ArgumentException();
            }
            if (componentsToRemove is null)
            {
                componentsToRemove = new List<int>();
            }
            componentsToRemove.Add(index);
        }
        public void RemoveComponent(ComponentBase target)
        {
            if (components is null)
            {
                components = new List<ComponentBase>();
                return;
            }
            if (target is null)
            {
                throw new NullReferenceException();
            }
            if (componentsToRemove is null)
            {
                componentsToRemove = new List<int>();
            }
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i] == target)
                {
                    componentsToRemove.Add(i);
                }
            }
        }
        public void RemoveComponents(Type targetType)
        {
            if (components is null)
            {
                components = new List<ComponentBase>();
                return;
            }
            if (targetType is null)
            {
                throw new NullReferenceException();
            }
            if (componentsToRemove is null)
            {
                componentsToRemove = new List<int>();
            }
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i].GetType().IsAssignableFrom(targetType))
                {
                    componentsToRemove.Add(i);
                }
            }
        }
        public void RemoveComponents<T>() where T : ComponentBase
        {
            if (components is null)
            {
                components = new List<ComponentBase>();
                return;
            }
            if (componentsToRemove is null)
            {
                componentsToRemove = new List<int>();
            }
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i].GetType().IsAssignableFrom(typeof(T)))
                {
                    componentsToRemove.Add(i);
                }
            }
        }
        public void AddComponent(ComponentBase newComponent)
        {
            if (componentsToAdd is null)
            {
                componentsToAdd = new List<ComponentBase>();
            }
            if(newComponent is null)
            {
                throw new NullReferenceException();
            }
            componentsToAdd.Add(newComponent);
        }
        #endregion
    }
}