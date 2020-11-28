using System;
using System.Collections.Generic;
namespace EpsilonEngine
{
    public class GameObject
    {
        public string name = "Unnamed Gameobject";
        public Vector2Int position = Vector2Int.Zero;

        public List<Component> components = new List<Component>();

        public readonly GameInterface gameInterface = null;
        public readonly Game game = null;
        public readonly Scene scene = null;
        public GameObject(Scene scene)
        {
            if (scene is null)
            {
                throw new NullReferenceException();
            }
            this.scene = scene;
            if(scene.game is null)
            {
                throw new NullReferenceException();
            }
            game = scene.game;
            if(scene.gameInterface is null)
            {
                throw new NullReferenceException();
            }
            gameInterface = scene.gameInterface;
        }
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

        public List<Component> GetComponentsOfType(Type targetType)
        {
            List<Component> output = new List<Component>();

            foreach (Component c in components)
            {
                if (c.GetType().IsAssignableFrom(targetType))
                {
                    output.Add(c);
                }
            }

            return output;
        }
    }
}