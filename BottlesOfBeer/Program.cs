using System;

namespace BottlesOfBeer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            for (var i = 1; i <= 100; i++)
            {
                Console.WriteLine(BottlesOfBeer.GetVerse(i));
            }
        }
    }
}
