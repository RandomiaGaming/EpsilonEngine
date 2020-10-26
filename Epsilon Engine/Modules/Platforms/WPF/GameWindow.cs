using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace EpsilonEngine.Platforms.WPF
{
    public partial class GameWindow : Window
    {
        private static Stopwatch gameTimer = new Stopwatch();
        private static long lastFrameTicks = 0;
        private static System.Windows.Controls.Image canvas;
        public static Texture frame;
        public GameWindow()
        {
            ShowInTaskbar = true;
            Title = "EpsilonEngine";

            System.Windows.Controls.Image imageControl = new System.Windows.Controls.Image();
            RenderOptions.SetBitmapScalingMode(imageControl, BitmapScalingMode.NearestNeighbor);
            imageControl.Stretch = Stretch.Fill;
            canvas = imageControl;
            Content = imageControl;
            //Timeline.SetDesiredFrameRate(this., int.MaxValue);

            gameTimer = new Stopwatch();
            gameTimer.Start();
            lastFrameTicks = 0;

            CompositionTarget.Rendering += Rendering;
        }
        private static BitmapImage ToBitmapImage(Bitmap bitmap)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }
        public void Rendering(object o, EventArgs args)
        {
            Console.WriteLine($"{(gameTimer.ElapsedTicks - lastFrameTicks) / 1000}k TPF");
            lastFrameTicks = gameTimer.ElapsedTicks;
            Bitmap frame = new Bitmap(16, 16);
            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 16; y++)
                {
                    frame.SetPixel(x, y, System.Drawing.Color.FromArgb(RandomnessHelper.Next(0, 255), RandomnessHelper.Next(0, 255), RandomnessHelper.Next(0, 255)));
                }
            }
            canvas.Source = ToBitmapImage(frame);
        }
    }
}