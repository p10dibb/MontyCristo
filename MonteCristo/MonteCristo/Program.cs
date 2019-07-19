using System;

namespace Roulett
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p = new Player(2000);
            double total = 0;
            for (int i = 0; i < 10000; i++)
            {
                p.Money = 200;
                total += p.PlayRoulettInput(20, "red", 2);
            }
            double avg=total/10000;
            Console.WriteLine("avg: " + avg);

       
        }
    }
}
