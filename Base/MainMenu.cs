using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Touch.Base
{
    class MainMenu
    {
        private bool isRunning;

        public MainMenu()
        {
            isRunning = true;
            Console.Title = "Touch";
        }

        public void Update()
        {
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("[S]Start");
                Console.WriteLine("[Q]Quit");
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.S)
                {
                    Game game = new Game();
                    game.Update();
                }
                if (key.Key == ConsoleKey.Q)
                {
                    isRunning = false;
                }
            }
        }
    }
}