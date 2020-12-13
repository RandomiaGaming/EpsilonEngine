using System;
using System.Collections.Generic;

namespace EpsilonEngine.Modules.Pixel2D
{
    public class Pixel2DGameObject : GameObjectBase
    {
        public Vector2Int position = Vector2Int.Zero;
        public Texture texture = null;

        private List<Pixel2DComponent> components = new List<Pixel2DComponent>();
        private List<int> componentsToRemove = new List<int>();
        private List<Pixel2DComponent> componentsToAdd = new List<Pixel2DComponent>();

        public readonly Pixel2DScene pixel2DScene = null;
        public Pixel2DGameObject(Pixel2DScene pixel2DScene) : base(pixel2DScene)
        {
            if(pixel2DScene is null)
            {
                throw new NullReferenceException();
            }
            this.pixel2DScene = pixel2DScene;
        }
        public override void Initialize()
        {

        }
        public override void Update()
        {
            foreach (Pixel2DComponent c in components)
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

            foreach (Pixel2DComponent componentToAdd in componentsToAdd)
            {
                components.Add(componentToAdd);
            }
            foreach (Pixel2DComponent componentToAdd in componentsToAdd)
            {
                componentToAdd.Initialize();
            }
            componentsToAdd = new List<Pixel2DComponent>();
        }

        #region Component Management Methods
        public Pixel2DComponent GetComponent(int index)
        {
            if (components is null)
            {
                components = new List<Pixel2DComponent>();
                return null;
            }
            if (index < 0 || index >= components.Count)
            {
                throw new ArgumentException();
            }
            return components[index];
        }
        public Pixel2DComponent GetComponent(Type targetType)
        {
            if (components is null)
            {
                components = new List<Pixel2DComponent>();
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
        public T GetComponent<T>() where T : Pixel2DComponent
        {
            if (components is null)
            {
                components = new List<Pixel2DComponent>();
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
        public List<Pixel2DComponent> GetComponents()
        {
            return new List<Pixel2DComponent>(components);
        }
        public List<Pixel2DComponent> GetComponents(Type targetType)
        {
            if (components is null)
            {
                components = new List<Pixel2DComponent>();
                return null;
            }
            if (targetType is null)
            {
                throw new NullReferenceException();
            }
            List<Pixel2DComponent> output = new List<Pixel2DComponent>();
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i].GetType().IsAssignableFrom(targetType))
                {
                    output.Add(components[i]);
                }
            }
            return output;
        }
        public List<T> GetComponents<T>() where T : Pixel2DComponent
        {
            if (components is null)
            {
                components = new List<Pixel2DComponent>();
                return null;
            }
            List<T> output = new List<T>();
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i].GetType().IsAssignableFrom(typeof(T)))
                {
                    output.Add((T)components[i]);
                }
            }
            return output;
        }
        public int GetComponentCount()
        {
            if (components is null)
            {
                components = new List<Pixel2DComponent>();
                return 0;
            }
            return components.Count;
        }
        public void RemoveComponent(int index)
        {
            if (components is null)
            {
                components = new List<Pixel2DComponent>();
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
        public void RemoveComponent(Pixel2DComponent targetComponent)
        {
            if (components is null)
            {
                components = new List<Pixel2DComponent>();
                return;
            }
            if (targetComponent is null)
            {
                throw new NullReferenceException();
            }
            if (componentsToRemove is null)
            {
                componentsToRemove = new List<int>();
            }
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i] == targetComponent)
                {
                    componentsToRemove.Add(i);
                }
            }
        }
        public void RemoveComponents(Type targetType)
        {
            if (components is null)
            {
                components = new List<Pixel2DComponent>();
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
        public void RemoveComponents<T>() where T : Pixel2DComponent
        {
            if (components is null)
            {
                components = new List<Pixel2DComponent>();
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
        public void AddComponent(Pixel2DComponent newComponent)
        {
            if (componentsToAdd is null)
            {
                componentsToAdd = new List<Pixel2DComponent>();
            }
            if (newComponent is null)
            {
                throw new NullReferenceException();
            }
            componentsToAdd.Add(newComponent);
        }
        #endregion
    }
}
