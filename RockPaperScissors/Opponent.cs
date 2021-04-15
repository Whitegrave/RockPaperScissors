using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Opponent
    {
        public int Hand
        { get; set; }

        public void GenerateHand()
        {
            Random gen = new Random();
            // Generate random # between 1 and 3
            // 1 == Rock
            // 2 == Paper
            // 3 == Scissors
            this.Hand = gen.Next(1, 4);
            if (this.Hand == 1) { Console.WriteLine("\nYour opponent chose Rock."); }
            else if (this.Hand == 2) { Console.WriteLine("\nYour opponent chose Paper."); }
            else { Console.WriteLine("\nYour opponent chose Scissors."); }
        }

        public string DetermineRound(int playerHand)
        {
            // 1 == Rock
            // 2 == Paper
            // 3 == Scissors
            // Compare hands
            // AI chose Rock
            if (this.Hand == 1)
            {
                //Clear hand for next round
                this.Hand = 0;
                if (playerHand == 1) { return "TIE"; }
                else if (playerHand == 2) { return "WIN"; }
                else { return "LOSE"; }
            }
            // AI chose Paper
            else if (this.Hand == 2)
            {
                //Clear hand for next round
                this.Hand = 0;
                if (playerHand == 1) { return "LOSE"; }
                else if (playerHand == 2) { return "TIE"; }
                else { return "WIN"; }
            }
            // AI chose Scissors
            else
            {
                //Clear hand for next round
                this.Hand = 0;
                if (playerHand == 1) { return "WIN"; }
                else if (playerHand == 2) { return "LOSE"; }
                else { return "TIE"; }
            }
        }
    }
}
