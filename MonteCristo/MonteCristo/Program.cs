using System;

namespace MonteCristo
{
    class Program
    {
        static void Main(string[] args)
        {
            Roulett r = new Roulett();
          
            Console.WriteLine(r.Play(21,"21"));
        }
    }
}
