using System;
using System.Collections.Generic;
using Touch.Modules;

namespace Touch.Base
{
    class Game
    {
        private bool isRunning = true;
        private Player player = new Player();
        private Map map;

        public Game()
        {
            Console.Clear();
            Console.WriteLine("Name of the map");
            string? choose = Console.ReadLine();
            Console.Clear();
            map = new Map("Data/Tiles.json", choose, ref isRunning, player);
            if (isRunning == true)
            {
                Console.WriteLine("Press any key to continue");
            }
        }
        public void Update()
        {
            while (isRunning)
            {
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                Console.Clear();
                if(key.Key == ConsoleKey.Q)
                {
                    isRunning = false;
                    Console.WriteLine("Quit");
                    Console.ReadKey(intercept: true);
                }
                player.Update(key, map, ref isRunning);
            }
        }
    }
}
