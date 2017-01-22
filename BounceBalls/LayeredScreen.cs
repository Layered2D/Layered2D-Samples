using System;
using System.Windows.Forms;
using System.Collections.Generic;

using SkiaSharp;
using Layered2D;
using Layered2D.Windows;
using Layered2D.Collections;
using SkiaSharp.Views.Desktop;

namespace BounceBalls
{
    [System.ComponentModel.DesignerCategory("code")]
    public class LayeredScreen : LayeredWindow
    {
        FPSCounter fps = new FPSCounter();

        Random r = new Random();
        LazyList<Ball> balls = new LazyList<Ball>();

        public LayeredScreen() : base()
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size.ToSKSize();
            this.Location = Screen.PrimaryScreen.Bounds.Location;
            this.StartPosition = FormStartPosition.Manual;

            Ball.CreateBalls(ref balls, this.Width, this.Height);
        }

        public override void OnRender(LayeredContext context)
        {
            base.OnRender(context);
            fps.Update();

            context.Clear();

            balls.Apply();

            foreach (Ball ball in balls)
            {
                ball.X += ball.SpeedX * ball.DirectionX;
                ball.Y += ball.SpeedY * ball.DirectionY;

                if (ball.X < ball.Radius || ball.X > Width - ball.Radius)
                    ball.DirectionX *= -1;

                if (ball.Y < ball.Radius || ball.Y > Height - ball.Radius)
                    ball.DirectionY *= -1;

                ball.X = Math.Min(Math.Max(ball.X, ball.Radius), Width - ball.Radius);
                ball.Y = Math.Min(Math.Max(ball.Y, ball.Radius), Width - ball.Radius);

                ball.Opacity = Math.Max(ball.Opacity, 0);
                ball.Paint.Color = ball.Paint.Color.WithAlpha((byte)(255 * ball.Opacity));

                if (ball.Opacity < float.Epsilon)
                    balls.LazyRemove(ball);

                context.DrawOval(ball.X, ball.Y, ball.Radius, ball.Radius, ball.Paint);
            }

            using (var paint = new SKPaint()
            {
                Color = SKColors.Red,
                TextAlign = SKTextAlign.Right,
                TextSize = 20,
                IsAntialias = true
            })
            {
                context.DrawText($"FPS: {fps.FPS}",
                    (int)(Width - 10),
                    (int)(Height - 10),
                    paint);

                context.DrawText($"Object: {balls.Count}",
                    (int)(Width - 10),
                    (int)(Height - 10 - paint.TextSize * 1.5),
                    paint);
            }
        }
    }
}
