using System.Windows.Forms;
using Layered2D.Windows;

namespace BounceBalls
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var ls = new LayeredScreen();

            RenderLoop.Run(
                ls,
                new RenderLoop.RenderCallback(() =>
                {
                    ls.Render();
                }));
        }
    }
}
