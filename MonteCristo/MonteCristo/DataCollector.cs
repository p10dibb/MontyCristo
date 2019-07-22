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

       
        private Player p;

        public DataCollector()
        {
            p = new Player();
       
        }

        public void RunRoulettStats(int trials,double startingMoney, int maxRounds,double initialBet)
        {
            dataset max = new dataset(0,0,0,"",0);
            LinkedList < dataset > colection = new LinkedList<dataset>();

           
     
                foreach (string bettype in p.roulett.BetTypes)
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

        public void RunRoulettStats_Specific(int trials, double startingMoney, int Rounds, double initialBet, string betOn)
        {


            double maxMoney = 0;
            int zeros = 0;
            int amountGain = 0;
            int amountLoss = 0;
            int amountEven = 0;
            double totalMoney = 0;
            double avgMoney = 0;

            for (int i = 0; i < trials; i++) {
                p.Money = startingMoney;

                double winnings = p.PlayRoulettInput(Rounds, betOn, initialBet);
                if (winnings == 0)
                {
                    zeros++;
                }
                else if (maxMoney < winnings)
                {
                    maxMoney = winnings;
                }
                if (winnings > startingMoney)
                {
                    amountLoss++;
                }
                else if (winnings < startingMoney)
                {
                    amountGain++;
                }
                else
                {
                    amountEven++;
                }
                totalMoney += winnings;

            }

            avgMoney = totalMoney / trials;

            Console.WriteLine("trials: " + trials + ", starting money: " + startingMoney + ", Rounds: " + Rounds + ",");
            Console.WriteLine("Initial Bet: " + initialBet + ", bet On:" + betOn);
            Console.WriteLine("Max Money " + maxMoney + ", Average Money: " + avgMoney + ", amount of zeros: " + zeros);
            Console.WriteLine("Broke Even amt: " + amountEven + ", gained money: " + amountGain + ", lost money: " + amountLoss);
        

        }







        

        



    }
}
