using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        private static Random r = new Random();

        private static int heigth;
        private static int width;
        private static int[] y;

        static void Main(string[] args)
        {
            Init();

            // Main loop
            while (true)
            {
                // 3 Chars (row) at a time (1 bright, 1 dark green and 1 space)
                for(int x = 0; x < width; ++x)
                {
                    // Bright green char
                    Console.SetCursorPosition(x, y[x]);
                    Console.Write((char)r.Next(15, 255));

                    // Space Char 20 rows above
                    Console.SetCursorPosition(x, OnScreen(y[x] - 20));
                    Console.Write(" ");

                    y[x] = OnScreen(y[x] + 1);
                }
                Thread.Sleep(1000 / 60);
            }
        }

        private static int OnScreen(int y)
        {
            return y < 0 ? y + heigth : y < heigth ? y : 0;
        }

        private static void Init()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WindowHeight = Console.BufferHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.BufferWidth = Console.LargestWindowWidth;
            Console.CursorVisible = false;

            heigth = Console.WindowHeight;
            width = Console.WindowWidth - 1;
            y = new int[width];

            // First time init
            for (int i = 0; i < width; i++)
            {
                y[i] = r.Next(heigth);
            }
        }

    }
}
