using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Player
    {
        public string Name
        { get; set; }

        //Constructor
        public Player(string name)
        {
            this.Name = name;
        }

        public int RoundsRequested
        { get; set; }
        public int RoundsRemaining
        { get; set; }

        public int Hand
        { get; set; }

        public int SessionWins
        { get; set; }

        public int SessionLosses
        { get; set; }

        public int SessionTies
        { get; set; }

        public int TotalWins
        { get; set; }

        public int TotalLosses
        { get; set; }

        public int TotalTies
        { get; set; }

        public int TotalRoundsPlayed
        { get; set; }

        private void ResetPlayer()
        {
            // Reset the player fields for a new set of rounds
            this.RoundsRequested = 0;
            this.SessionLosses = 0;
            this.SessionTies = 0;
            this.SessionWins = 0;
        }

        public void RequestName()
        {
            while (this.Name == "")
            {             
                string inputTemp = Console.ReadLine();
                // Cycle through each character with a Linq lambda to validate each character as a letter
                bool nameValid = inputTemp.All(c => Char.IsLetter(c));
                if (!nameValid)
                {
                    Console.WriteLine("That name was not valid. Please use letters only, no spaces or other characters.");
                }
                else
                {
                    this.Name = inputTemp;
                    Console.WriteLine($"Welcome to the game, {inputTemp}!");
                }
            }
        }

        public void RequestNumberOfRounds()
        {
            while (this.RoundsRequested == 0)
            {
                Console.WriteLine("How many rounds would you like to play? Choose between 1 and 10.");
                string inputTemp = Console.ReadLine();
                // Attempt to convert the input into a short
                short result;
                bool roundsValid = Int16.TryParse(inputTemp, out result);
                // Validate
                if (roundsValid && result > 0 && result < 11)
                {
                    Console.WriteLine($"You have chosen to play {result} rounds.");
                    this.RoundsRequested = result;
                    this.RoundsRemaining = result;
                }
                else
                {
                    Console.WriteLine("You entered an invalid number of rounds.");
                }
            }
        }

        public void RequestPlayerHand()
        {
        while (this.Hand == 0)
            {
                Console.WriteLine("\nPlease choose a hand. You can choose Rock, Paper or Scissors.\nAlternatively you can choose 1, 2 or 3. 1 = Rock, 2 = Paper, 3 = Scissors.");
                string inputTemp = Console.ReadLine().ToUpper();
                // Validate input
                switch (inputTemp)
                {
                    case "1":
                        this.Hand = 1;
                        break;
                    case "2":
                        this.Hand = 2;
                        break;
                    case "3":
                        this.Hand = 3;
                        break;
                    case "ROCK":
                        this.Hand = 1;
                        break;
                    case "PAPER":
                        this.Hand = 2;
                        break;
                    case "SCISSORS":
                        this.Hand = 3;
                        break;
                    default:
                        Console.WriteLine("The input provided was not valid.");
                        break;
                }
                if (this.Hand == 1) { Console.WriteLine("You chose Rock."); }
                else if (this.Hand == 2) { Console.WriteLine("You chose Paper."); }
                else if (this.Hand == 3) { Console.WriteLine("You chose Scissors."); }
            }
        }

        public void ProcessRound(string result)
        {
            // Adjust general fields
            this.RoundsRemaining--;
            this.TotalRoundsPlayed++;
            // Adjust W/L/Tie based on result
            if (result == "WIN")
            {
                this.SessionWins++;
                this.TotalWins++;
                Console.WriteLine("You won the round!");
            }
            else if (result == "LOSE")
            {
                this.SessionLosses++;
                this.TotalLosses++;
                Console.WriteLine("You lost the round.");
            }
            else
            {
                this.SessionTies++;
                this.TotalTies++;
                Console.WriteLine("This round was a tie.");
            }
            // Reset player hand
            this.Hand = 0;
        }

        public void DisplayResults()
        {
            Console.WriteLine($"\nYou've completed the {this.RoundsRequested} rounds you wanted to play. Here are your results...\n");
            Console.WriteLine($"Rounds played this game: {this.RoundsRequested}");
            Console.WriteLine($"Rounds won this game: {this.SessionWins}");
            Console.WriteLine($"Rounds lost this game: {this.SessionLosses}");
            Console.WriteLine($"Rounds tied this game: {this.SessionTies}\n");
            Console.WriteLine($"Rounds played in all games: {this.TotalRoundsPlayed}");
            Console.WriteLine($"Rounds won in all games: {this.TotalWins}");
            Console.WriteLine($"Rounds lose in all games: {this.TotalLosses}");
            Console.WriteLine($"Rounds tied in all games: {this.TotalTies}\n");
            // Determine overall winner
            if (this.SessionWins > this.SessionLosses)
            {
                Console.WriteLine("You were the overall winner!");
            }
            else if (this.SessionWins < this.SessionLosses)
            {
                Console.WriteLine("Your opponent was the overall winner...");
            }
            else
            {
                Console.WriteLine("Overall, you both tied. No winner!");
            }
        }

        public void PromptToReplay()
        {
            Console.WriteLine("Would you like to play another set of rounds? Enter yes to play again, or any other value to quit.");
            string tempInput = Console.ReadLine().ToUpper();
            this.ResetPlayer();
            if (tempInput == "YES")
            {                
                this.RequestNumberOfRounds();
            }
            else
            {
                Console.WriteLine($"Thanks for playing, {this.Name}.");
            }
        }
    }
}
