using System;
using System.Collections.Generic;
namespace EpsilonEngine
{
    public class GameObject
    {
        public readonly Game game;
        public readonly Machine machine;

        public string name = "Unnamed Gameobject";
        public Vector2Int position = Vector2Int.Zero;

        public List<Component> components = new List<Component>();

        public GameObject(Game game)
        {
            if (game is null)
            {
                throw new NullReferenceException();
            }
            this.game = game;
            if(game.machine is null)
            {
                throw new NullReferenceException();
            }
            machine = game.machine;
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