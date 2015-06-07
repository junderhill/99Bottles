using System;
namespace BottlesOfBeer
{
    class Program
    {
        static void Main(string[] args)
        {
           for(int i = 1; i <= 100; i++){
              Console.WriteLine(BottlesOfBeer.GetVerse(i));
           }
        }
    }
}
