using System;
using System.Collections.Generic;
namespace EpsilonEngine
{
    public class Scene
    {
        public readonly Game game;

        public SceneRenderer renderer;

        public List<GameObject> gameObjects = new List<GameObject>();
        public Scene(Game game)
        {
            if (game is null)
            {
                throw new NullReferenceException();
            }
            this.game = game;
        }

        public virtual void Initialize()
        {
            foreach (GameObject go in gameObjects)
            {
                go.Initialize();
            }
        }

        public virtual void Update()
        {
            foreach (GameObject go in gameObjects)
            {
                go.Update();
            }
        }
    }
}
