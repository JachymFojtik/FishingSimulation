using System;
using System.Collections.Generic;

namespace FishingSimulation
{

    class Program
    {
        static Random R = new Random();            
        static void Main(string[] args)
        {
            int[,] fishPond = new int[1000,1000];
            SpawnFish(fishPond);
            GetBestCatch(fishPond);
            Console.ReadKey();
        }
        private static void SpawnFish(int[,] pond)
        {                

            for (int i = 0; i < 100000; i++)
            {
                pond[R.Next(0, 1000), R.Next(0, 1000)] += 1;
            }
        }

        private static void GetBestCatch(int[,] pond)
        {
            int biggestCount = 0;
            int Xres = 0;
            int Yres = 0;

            for (int i = 0; i <= 970; i += 10)
            {
                for (int j = 0; j <= 970; j += 10)
                {
                    int fishCount = 0;
                    for (int x = i; x < i+30; x += 1)
                    {
                        for (int y = j; y < j+30; y += 1)
                        {

                            fishCount += pond[x, y];

                        }
                    }
                    if (fishCount > biggestCount)
                    {
                        biggestCount = fishCount;
                        Xres = i; Yres = j;
                    }
                }
            }

            Console.WriteLine($"Chyceno: {biggestCount}\n");
            Console.WriteLine($"Pozice:\n" +
                $"X1: {Xres}\n" +
                $"Y1: {Yres}\n" +
                $"X2: {Xres + 30}\n" +
                $"Y2: {Yres + 30}");
            Console.ReadKey();
        }
    }
}
