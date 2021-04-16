using System;
using System.Collections.Generic;

namespace FishingSimulation
{
    public class Fish
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Fish(int xpos, int ypos)
        { X = xpos; Y = ypos; }
    }
    class Program
    {
        static List<Fish> AllFish = new List<Fish>();
        static Random R = new Random();
        static void Main(string[] args)
        {
            SpawnFish();
            GetBestCatch();
            Console.ReadKey();
        }
        private static void SpawnFish()
        {
            for (int i = 0; i < 100000; i++)
            {
                Fish newFish = new Fish(R.Next(0, 999), R.Next(1, 999));
                AllFish.Add(newFish);
            }
        }

        private static void GetBestCatch()
        {
            int biggestCount = 0;
            int Xres = 0;
            int Yres = 0;

            for (int i = 0; i < 1000; i += 10)
            {
                for (int j = 0; j < 1000; j += 10)
                {
                    int fishCount = 0;
                    foreach (Fish fish in AllFish)
                    {
                        if (fish.X >= i
                            && fish.X <= i + 30
                            && fish.Y >= j
                            && fish.Y <= j + 30)
                        {
                            fishCount++;
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
        }
    }
}
