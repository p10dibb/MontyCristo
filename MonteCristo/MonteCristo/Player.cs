using System;
using System.Collections.Generic;
using System.Text;

namespace Roulett
{
    class Player
    {
        private double money;
        private Random rand = new Random();
        public Roulett roulett;

        public Player()
        {
            roulett = new Roulett();
            money = 0;


        }
        public Player(double m)
        {
            money = m;
            roulett = new Roulett();


        }


        //randomly plays roulet till the no money
        public int PlayRoulettRandom()
        {
            int rounds = 0;
            if  (money > 0){
                double bet = 0;
                double winnings;
                double initialAmount = money;
                
                
                int choice = rand.Next(0, 1);

                
                if (choice == 0) //color
                {
                    Console.WriteLine("Color");
                    string[] colors =new string[2];
                    colors[0] = "red";
                    colors[1] = "black";
                    string colorChoice=colors[rand.Next(0,1)];
                    Console.WriteLine("betting on:" + colorChoice);
                    bet = money / 100;
                    while (money > 0)
                    {
                        rounds++;
                        winnings = roulett.Play(bet, colorChoice);

                        if (winnings < 0)
                        {
                            bet *=2;
                        }
                        else
                        {
                            bet +=+ winnings / 2;
                        }
                        money += winnings;
                        bet = MaxBet(bet);
                        Console.WriteLine("Money: " + money);
                    }               


                }
                else //number
                {
                    
                    int losingStreak = 0;
                    Console.WriteLine("Numbers");
                    int numberChoice = rand.Next(1, 37);
                    Console.WriteLine("netting on: " + numberChoice);
                    bet = money / 1000;

                    while (money > 0)
                    {
                        rounds++;
                        Console.WriteLine("Bet: " + bet);
                        winnings = roulett.Play(bet, ""+numberChoice);

                        if (winnings < 0 && losingStreak%36!=0)
                        {
                            losingStreak = 0;
                            bet *=2; 
                        }
                        else
                        {
                            bet += winnings / 2;
                        }
                        money += winnings;
                        bet = MaxBet(bet);
                        Console.WriteLine("Money: " + money);
                    }
                }

                
                 





            }

            return rounds;

        }

        public double PlayRoulettInput(int rounds, string beton, double initialbet)
        {
            int currentRound = 0;
            double winnings = 0;
            double bet = initialbet;


            while (rounds > currentRound)
            {
                currentRound++;

                if (beton.CompareTo("red") == 0|| beton.CompareTo("black") == 0) //color
                {                                     
                    
                      
                        winnings = roulett.Play(bet,beton);

                        if (winnings < 0)
                        {
                            bet *= 2;
                        }
                        else
                        {
                            bet += +winnings / 2;
                        }
                        money += winnings;
                        bet = MaxBet(bet);
                        Console.WriteLine("Money: " + money);
                    


                }
                else
                {
                    int losingStreak = 0;                

                  
                       
                        winnings = roulett.Play(bet,  beton);

                        if (winnings < 0 && losingStreak % 36 != 0)
                        {
                            losingStreak = 0;
                            bet *= 2;
                        }
                        else
                        {
                            bet += winnings / 2;
                        }
                        money += winnings;
                        bet = MaxBet(bet);
                        Console.WriteLine("Money: " + money);
                    
                }
            }




            return money;
        }

        public double MaxBet(double bet)
        {
            if (bet < money)
            {
                return bet;
            }
            else
            {
                return money;
            }
            
        }


        public double Money
        {
            get { return money; }
            set { money = value; }
        }
    }
}
