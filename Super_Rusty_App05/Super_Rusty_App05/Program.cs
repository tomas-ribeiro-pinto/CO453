using System;
using App05_Super_Rusty;

namespace Super_Rusty_App05
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
}
