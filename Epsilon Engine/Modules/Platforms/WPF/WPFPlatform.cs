namespace EpsilonEngine.Platforms.WPF
{
    public static class WPFPlatform
    {
        public static void Initialize()
        {
            GameWindow window = new GameWindow();
            window.ShowDialog();
        }
        public static void Update()
        {

        }
    }
}