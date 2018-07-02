using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int cmdShow);

        private static Random rnd = new Random();

        private static int height;
        private static int width;
        private static int[] y;

        static void Main(string[] args)
        {
            Init();

            // Main loop
            while (true)
            {
                for (int x = 0; x < width; ++x)
                {
                    // White char
                    Console.SetCursorPosition(x, y[x]);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write((char)rnd.Next(15, 255));

                    // Bright green char
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(x, OnScreen(y[x] - 2));
                    Console.Write((char)rnd.Next(15, 255));

                    // Dark green char
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.SetCursorPosition(x, OnScreen(y[x] - 6));
                    Console.Write((char)rnd.Next(15, 255));

                    // Space char 20 rows above
                    Console.SetCursorPosition(x, OnScreen(y[x] - 20));
                    Console.Write(" ");

                    y[x] = OnScreen(y[x] + 1);
                }
                Thread.Sleep(1000 / 60);
            }
        }

        private static int OnScreen(int y)
        {
            return y < 0 ? y + height : y < height ? y : 0;
        }

        private static void Init()
        {
            IntPtr hConsole = Process.GetCurrentProcess().MainWindowHandle;
            ShowWindow(hConsole, 3); //SW_MAXIMIZE = 3

            Console.ForegroundColor = ConsoleColor.Green;
            Console.CursorVisible = false;

            height = Console.WindowHeight;
            width = Console.WindowWidth - 1;
            y = new int[width];

            // First time init
            for (int i = 0; i < width; i++)
            {
                y[i] = rnd.Next(height);
            }
        }

    }
}
