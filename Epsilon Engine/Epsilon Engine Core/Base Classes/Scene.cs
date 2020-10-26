using System.Collections.Generic;
namespace EpsilonEngine
{
    public class Scene
    {
        public string name = "Unnamed Scene";
        public List<GameObject> gameObjects = new List<GameObject>();
        public virtual void Initialize(SceneInitializationPacket packet)
        {

        }
        public virtual SceneReturnPacket Update(SceneUpdatePacket packet)
        {
            return new SceneReturnPacket();
        }
    }
}