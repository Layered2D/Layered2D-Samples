using System;
using SkiaSharp;
using System.Drawing;
using SkiaSharp.Views.Desktop;
using Layered2D.Collections;

namespace BounceBalls
{
    class Ball
    {
        public SKPaint Paint { get; set; }

        public float X { get; set; }
        public float Y { get; set; }

        public float Radius { get; set; }

        public float SpeedX { get; set; } = 1f;
        public float SpeedY { get; set; } = 1f;

        public int DirectionX = 1;
        public int DirectionY = 1;

        public float Opacity { get; set; } = 1;

        internal static void CreateBalls(ref LazyList<Ball> lazyAddBalls, int Width, int Height)
        {
            Random r = new Random();
            for (int i = 0; i < 128; i++)
            {
                lazyAddBalls.LazyAdd(new BounceBalls.Ball()
                {
                    X = Width / 2,
                    Y = Height / 2,
                    SpeedX = r.Next(12) + 1,
                    SpeedY = r.Next(12) + 1,
                    Radius = r.Next(2, 30),
                    DirectionX = new[] { -1, 1 }[r.Next(2)],
                    DirectionY = new[] { -1, 1 }[r.Next(2)],
                    Paint = new SKPaint()
                    {
                        Color = Color.FromArgb(
                            r.Next(256),
                            r.Next(256),
                            r.Next(256)
                            ).ToSKColor(),
                        Style = SKPaintStyle.Stroke,
                        StrokeWidth = 2,
                        IsAntialias = true
                    }
                });
            }
        }
    }
}
