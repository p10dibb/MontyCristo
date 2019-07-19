using System;
using System.Collections.Generic;
using System.Text;

namespace Roulett
{
    public class Box
    {
        private int number;
        private string color;

       public Box()
        {
            number = 0;
            color = "white";
        }

        public int Number
        {
            get { return this.number; }
            set { this.number = value; }
        }

        public string Color
        {
            get { return this.color; }
            set {
                if( value =="red" || value == "black"){
                }
                this.color = value;
            }

        }

    }
    public class Roulett
    {
        private static int Min = 1;
        private static int Max = 37;
        private int TotalRed = 0;
        private int TotalBlack = 0;
        private Box[] Boxes;
        private static Random rand = new Random(DateTime.Now.Second);

        public Roulett()
        {
            Boxes = new Box[Max-Min];
            for (int i = 0; i < Max - 1; i++)
            {
                Boxes[i] = new Box();
                if (i % 2 == 0)
                {
                    Boxes[i].Color = "red";
                    TotalRed++;
                    
                }
                else
                {
                    Boxes[i].Color = "black";
                    TotalBlack++;
                }
                Boxes[i].Number = i + Min;
            }


        }

        //returns the tile that is spun
        public Box Spin() {
            
            return Boxes[rand.Next(Min, Max)-1];
        }



        public double Play(double amt,string bet)
        {
            double ret = 0;
            Box spin = this.Spin();

            if (bet.CompareTo("red") == 0 || bet.CompareTo("black") == 0)
            {
                Console.WriteLine(spin.Color + " " + spin.Number);
                if (spin.Color.CompareTo(bet) == 0)
                {
                    ret = amt ;
                    Console.WriteLine("congrats you won $" + ret);
                    return ret;
                }
                else
                {
                    Console.WriteLine("you Lost $" + amt);
                    return amt*-1;
                }

            }
            else if (Int32.Parse(bet) >= Min && Int32.Parse(bet) < Max)
            {
                
                if (spin.Number == Int32.Parse(bet))
                {
                    ret= amt * (Max - Min-1);
                    Console.WriteLine("congrats you won $" + ret);
                    return ret;
                }
                else {
                    Console.WriteLine("you Lost $" + amt);
                    return -amt;
                }
            }

            Console.WriteLine("invalid Bet");
            return 0;
        }
    }
}
