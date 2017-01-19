using Layered2D;
using Layered2D.Windows;
using SkiaSharp;
using System.Windows.Forms;

namespace OvalPerformanceTest
{
    class TestScreen : LayeredWindow
    {
        SKPaint p;
        FPSCounter fps = new FPSCounter();
        public TestScreen() : base()
        {
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;

            p = new SKPaint()
            {
                Color = SKColors.BlueViolet,
                Style = SKPaintStyle.Stroke,
                TextSize = 25,
                IsAntialias = true
            };
        }

        public override void OnRender(LayeredContext context)
        {
            base.OnRender(context);
            fps.Update();

            for (int i = 0; i < 2048; i++)
            {
                context.DrawOval(100 + i, 100 + i, 50, 50, p);
            }

            context.DrawText(fps.FPS.ToString(), 10, 30, p);
        }
    }
}
