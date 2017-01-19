using Layered2D.Windows;
using System;
using System.Windows.Forms;

namespace OvalPerformanceTest
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            TestScreen ts = new TestScreen();

            RenderLoop.Run(
                ts,
                new RenderLoop.RenderCallback(() =>
                {
                    ts.Render();
                }));
        }
    }
}
