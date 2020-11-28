using System;
using System.Collections.Generic;
namespace EpsilonEngine
{
    public class Scene
    {
        public SceneRenderer renderer;

        public List<GameObject> gameObjects = new List<GameObject>();

        public readonly GameInterface gameInterface = null;
        public readonly Game game = null;
        public Scene(Game game)
        {
            if (game is null)
            {
                throw new NullReferenceException();
            }
            this.game = game;
            if (game.gameInterface is null)
            {
                throw new NullReferenceException();
            }
            gameInterface = game.gameInterface;
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
