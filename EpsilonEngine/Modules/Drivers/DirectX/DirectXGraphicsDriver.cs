using System;
using SharpDX.Windows;

namespace EpsilonEngine.Modules.Drivers.DirectX
{
    public class DirectXGraphicsDriver : GraphicsDriver
    {
        public DirectXGraphicsDriver(Machine machine) : base(machine)
        {

        }
        public override void Update()
        {

        }
        public override void Initialize()
        {
            RenderForm form = new RenderForm();
            form.Show();
        }
        public override void Draw(Texture frame)
        {

        }

        public override int GetRefreshRate()
        {
            return 60;
        }

        public override Vector2Int GetViewPortRect()
        {
            return new Vector2Int(1920, 1080);
        }
    }
}
