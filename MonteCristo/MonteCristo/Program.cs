using System;
using System.Diagnostics;
using System.IO;

namespace Roulett
{
    class Program
    {
        static void Main(string[] args)
        {

            Stopwatch sw = new Stopwatch();
            DataCollector d = new DataCollector();
            sw.Start();
            // d.RunRoulettStats(10000, 1000, 30, 1);
            d.RunRoulettStats_Specific(10, 200, 10, 1, "red");
            sw.Stop();
            Console.WriteLine(sw.Elapsed.Seconds+"seconds");

            string createText = "Hello and Welcome" + Environment.NewLine;
            File.WriteAllText("C:\\Users\\PDibble\\Desktop\\New folder\\MontyCristo\\MonteCristo\\out.csv", createText);

            //Player p = new Player(2000);
            //double total = 0;
            //for (int i = 0; i < 10000; i++)
            //{
            //    p.Money = 200;
            //    total += p.PlayRoulettInput(20, "red", 2);
            //}
            //double avg=total/10000;
            //Console.WriteLine("avg: " + avg);


        }
    }
}
