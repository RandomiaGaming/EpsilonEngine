using System;
using System.Diagnostics;
using System.Threading;

namespace Epsilon_Engine.Internal
{
    internal static class Epsilon_Engine_Kernal
    {
        public static double maxFPS = 1000;
        private static Stopwatch gameTimer = new Stopwatch();
        public static TimeSpan startTime = new TimeSpan(0);
        public static TimeSpan deltaTime = new TimeSpan(0);
        private static TimeSpan lastFrameTime = new TimeSpan(0);
        public static double Current_FPS = 0;
        private static bool wantsToQuit = false;
        internal static void Consume_Thread()
        {
            gameTimer.Restart();
            while (!wantsToQuit)
            {
                Update();
                long minTPF = (long)((1 / maxFPS) * 10000000.0);
                while (gameTimer.ElapsedTicks - lastFrameTime.Ticks < minTPF)
                {

                }
                startTime = new TimeSpan(gameTimer.ElapsedTicks);
                deltaTime = new TimeSpan(gameTimer.ElapsedTicks - lastFrameTime.Ticks);
                Current_FPS = 1.0 / deltaTime.TotalSeconds;
                lastFrameTime = new TimeSpan(gameTimer.ElapsedTicks);
            }
            Process.GetCurrentProcess().Kill();
        }
        public static void Update()
        {
            //GameManagerUpdate()
            //ComponentUpdate();
            //PhysicsUpdate();
            //Render();
        }
        public static void Initialize()
        {

        }
    }
}