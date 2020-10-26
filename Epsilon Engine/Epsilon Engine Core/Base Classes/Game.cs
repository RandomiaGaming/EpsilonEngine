using System.Collections.Generic;

namespace EpsilonEngine
{
    public class Game
    {
        public List<Scene> scenes = new List<Scene>();
        public virtual GameReturnPacket Update(GameUpdatePacket packet)
        {
            GameReturnPacket output = new GameReturnPacket();
            SceneUpdatePacket sceneUP = new SceneUpdatePacket
            {
                parent = this
            };
            foreach (Scene scene in scenes)
            {
                SceneReturnPacket sceneRP = scene.Update(sceneUP);
                if (sceneRP.requestQuit)
                {
                    output.requestQuit = true;
                }
            }
            output.frameTexture = new Texture(packet.viewPortSize, Color.Black);
            return output;
        }
        public virtual void Initialize(GameInitializationPacket packet)
        {
            AssetLoader.ReloadAssets();
            SceneInitializationPacket sceneIP = new SceneInitializationPacket
            {
                args = packet.args,
                platform = packet.platform,
                parent = this
            };
            foreach (Scene scene in scenes)
            {
                scene.Initialize(sceneIP);
            }
        }
    }
}