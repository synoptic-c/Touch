using System;
using System.Collections.Generic;

namespace Touch.Modules
{
    class Player
    {
        public int x { get; set; }
        public int y { get; set; }
        private List<string> backPack = new List<string>();

        public Player()
        {
            x = 0;
            y = 0;
        }
        public void Update(ConsoleKeyInfo key, Map map, ref bool isRunning)
        {
            if(map.map == null || map.tiles == null)
            {
                return;
            }

            int speedX = 0;
            int speedY = 0;

            if(key.Key == ConsoleKey.A)
            {
                speedX--;
            }
            if(key.Key == ConsoleKey.D)
            {
                speedX++;
            }
            if(key.Key == ConsoleKey.W)
            {
                speedY--;
            }
            if(key.Key == ConsoleKey.S)
            {
                speedY++;
            }

            x += speedX;
            if (map.tiles[map.map[y][x]].solid == 1)
            {
                if (speedX > 0)
                {
                    x--;
                }
                if (speedX < 0)
                {
                    x++;
                }
            }

            y += speedY;
            if (map.tiles[map.map[y][x]].solid == 1)
            {
                if (speedY > 0)
                {
                    y--;
                }
                if (speedY < 0)
                {
                    y++;
                }
            }

            if (key.Key == ConsoleKey.E)
            {
                if (map.tiles[map.map[y][x]].name == "key")
                {
                    map.map[y][x] = 11;
                    backPack.Add("key");
                    Console.WriteLine("You found a key");
                    Console.ReadKey(intercept: true);
                    Console.Clear();
                }
                if (map.tiles[map.map[y][x]].name == "exit")
                {
                    if (backPack.Contains("key"))
                    {
                        isRunning = false;
                        Console.WriteLine("You escaped");
                        Console.ReadKey(intercept: true);
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("The door is locked");
                        Console.ReadKey(intercept: true);
                        Console.Clear();
                    }
                }
            }

            Console.WriteLine(map.tiles[map.map[y][x]].name);
        }
    }
}
