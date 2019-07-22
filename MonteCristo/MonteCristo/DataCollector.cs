using System;
using System.Collections.Generic;
using System.Text;

namespace Roulett
{
    class DataCollector
    {

        private struct dataset
        {
            public int rounds;
           public double initialbet;
            public double netgain;
            public string beton;
            public double initialmoney;

            public dataset(int r, double ib, double ng, string bo, double im)
            {

                rounds = r;
                initialbet = ib;
                netgain = ng;
                beton = bo;
                initialmoney = im;
            }
        }

        LinkedList<string> betTypesRoulett = new LinkedList<string>();
        private Player p;

        public DataCollector()
        {
            p = new Player();
            betTypesRoulett.AddFirst("red");
            betTypesRoulett.AddLast("black");
            for (int i = 1; i < 37; i++)
            {
                betTypesRoulett.AddLast("" + i);
            }
        }

        public void RunRoulettStats(int trials,double startingMoney, int maxRounds,double initialBet)
        {
            dataset max = new dataset(0,0,0,"",0);
            LinkedList < dataset > colection = new LinkedList<dataset>();

           
     
                foreach (string bettype in betTypesRoulett)
                {
                    for (int r = 1; r < maxRounds; r++)
                    {
                    double total = 0;
                    for (int i = 0; i < trials; i++)
                    {
                        p.Money = startingMoney;
                        total+= p.PlayRoulettInput(r, bettype, initialBet);
                        
                    }
                    dataset cur = new dataset(r, initialBet, (total/trials) - startingMoney, bettype, startingMoney);
                    if (cur.netgain > max.netgain)
                    {
                        max = cur;
                    }
                    colection.AddLast(cur);
                   

                }
                }

            Console.WriteLine("--------Final Results From "+trials+" Trials---------");
            Console.WriteLine("With starting of $" + startingMoney + " and initial bet of " +max.initialbet);
            Console.WriteLine("Optimal Rounds: " + max.rounds);
         //   Console.WriteLine("Optimal initial Bet Amount: " + max.initialbet);
            Console.WriteLine("Optimal Bet On:" + max.beton);
            Console.WriteLine("Nate money Made"+ max.netgain);



            }





        

        



    }
}
