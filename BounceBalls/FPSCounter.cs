using System;

namespace BounceBalls
{
    public class FPSCounter
    {
        int fpsStep = 0;
        int lastFps = 0;
        DateTime lastTime = DateTime.Now;

        public int FPS
        {
            get
            {
                return lastFps;
            }
        }

        public void Update()
        {
            fpsStep++;

            var delta = DateTime.Now - lastTime;
            if (delta.TotalSeconds >= 1)
            {
                lastTime = DateTime.Now;

                lastFps = fpsStep;
                fpsStep = 0;
            }
        }
    }
}
