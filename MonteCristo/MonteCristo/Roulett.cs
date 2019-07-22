using System;
using System.Collections.Generic;
using System.Text;

namespace Roulett
{
    public class Box
    {
        private string number;
        private string color;


        public Box()
        {
            number = "0";
            color = "white";
        }
        public Box(string c, string num)
        {
            this.number = num;
            this.color = c;
        }

        public string Number
        {
            get { return this.number; }
            set { this.number = value; }
        }

        public string Color
        {
            get { return this.color; }
            set {
                if (value == "red" || value == "black") {
                }
                this.color = value;
            }

        }

    }
    public class Roulett
    {
        private static int Min = 1;
        private static int Max = 37;
    
        private Box[] Boxes;
        private static Random rand = new Random(DateTime.Now.Second);
        LinkedList<string> betTypes = new LinkedList<string>();

        public Roulett()
        {
            Boxes = new Box[(Max - Min)+3];
            Boxes[0] = new Box("green","0");
            Boxes[1] = new Box("red", "1");
            Boxes[2] = new Box("red", "2");
            Boxes[3] = new Box("red", "3");
            Boxes[4] = new Box("black", "4");
            Boxes[5] = new Box("red", "5");
            Boxes[6] = new Box("black", "6");
            Boxes[7] = new Box("red", "7");
            Boxes[8] = new Box("black", "8");
            Boxes[9] = new Box("red", "9");
            Boxes[10] = new Box("black", "10");
            Boxes[11] = new Box("black", "11");
            Boxes[12] = new Box("red", "12");
            Boxes[13] = new Box("black", "13");
            Boxes[14] = new Box("red", "14");
            Boxes[15] = new Box("black", "15");
            Boxes[16] = new Box("red", "16");
            Boxes[17] = new Box("black", "17");
            Boxes[18] = new Box("red", "18");
            Boxes[19] = new Box("red", "19");
            Boxes[20] = new Box("black", "20");
            Boxes[21] = new Box("red", "21");
            Boxes[22] = new Box("black", "22");
            Boxes[23] = new Box("red", "23");
            Boxes[24] = new Box("black", "24");
            Boxes[25] = new Box("red", "25");
            Boxes[26] = new Box("black", "26");
            Boxes[27] = new Box("red", "27");
            Boxes[28] = new Box("black", "28");
            Boxes[29] = new Box("black", "29");
            Boxes[30] = new Box("red", "30");
            Boxes[31] = new Box("black", "31");
            Boxes[32] = new Box("red", "32");
            Boxes[33] = new Box("black", "33");
            Boxes[34] = new Box("red", "34");
            Boxes[35] = new Box("black", "35");
            Boxes[36] = new Box("red", "36");
            Boxes[37]=new Box("green","00");
           

            betTypes.AddFirst("red");
            betTypes.AddLast("black");
            betTypes.AddLast("00");           
            for (int i = 0; i < 37; i++)
            {
                betTypes.AddLast("" + i);
            }

        }

        //returns the tile that is spun
        public Box Spin() {

            return Boxes[rand.Next(Min, Max) - 1];
        }



        public double Play(double amt, string bet)
        {
            double ret = 0;
            Box spin = this.Spin();

            if (bet.CompareTo("red") == 0 || bet.CompareTo("black") == 0)
            {
                Console.WriteLine(spin.Color + " " + spin.Number);
                if (spin.Color.CompareTo(bet) == 0)
                {
                    ret = amt;
                    Console.WriteLine("congrats you won $" + ret);
                    return ret;
                }
                else
                {
                    Console.WriteLine("you Lost $" + amt);
                    return amt * -1;
                }

            }
            else if (Int32.Parse(bet) >= Min && Int32.Parse(bet) < Max)
            {

                if (spin.Number == bet)
                {
                    ret = amt * (Max - Min - 1);
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
        public LinkedList<string> BetTypes
        {
            get { return this.BetTypes; }
        }
    }

 
}


