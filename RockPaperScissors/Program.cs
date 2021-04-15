using System;
using System.Linq;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the player and opponent objects with a temporary name
            Player mainPlayer = new Player("");
            Opponent aiEnemy = new Opponent();

            // Greet and request a valid name
            Console.WriteLine("Welcome to Rock Paper Scissors. What is your name?");
            mainPlayer.RequestName();

            // Main game loop in a do while() to ensure it runs at least once
            do
            {
                // If not yet defined, ask the player how many round they would like to play, validate
                mainPlayer.RequestNumberOfRounds();

                // Request player chooses a hand
                mainPlayer.RequestPlayerHand();

                // Generate a random opponent hand
                aiEnemy.GenerateHand();

                // Decide win/lose/tie
                string roundResult = aiEnemy.DetermineRound(mainPlayer.Hand);

                // Let the player object act upon win/lose/tie
                mainPlayer.ProcessRound(roundResult);

                // If no rounds remaining, display results and ask the player if they would like to play again.
                if (mainPlayer.RoundsRemaining == 0)
                {
                    mainPlayer.DisplayResults();
                    mainPlayer.PromptToReplay();
                }
            } while (mainPlayer.RoundsRemaining > 0);













        }
    }  
}
