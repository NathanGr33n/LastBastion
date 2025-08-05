//Program.cs
//By: NathanGr33n
//August 2025

using System;

namespace LastBastion
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            //Creates a new game instance and runs it.
            using (var game = new Game1())
                game.Run();
        }
    }

}