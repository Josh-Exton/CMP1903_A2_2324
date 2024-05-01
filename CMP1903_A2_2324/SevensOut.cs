using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace CMP1903_A2_2324
{
    /// <summary>
    /// Plays the Sevens Out game
    /// </summary>
    internal sealed class SevensOut : Game
    {
        // Setting up the scores so the testing class can access them.

        // defining the fields 
        private long _player1Sum;
        private long _otherSum;

        // defining the properties

        /// <summary>
        /// Gets the final sum of player 1
        /// </summary>
        public long Player1Sum
        {
            get { return _player1Sum; }
            private set { _player1Sum = value; }
        }

        /// <summary>
        /// Gets the final sum of the other player
        /// </summary>
        public long OtherSum
        {
            get { return _otherSum; }
            private set { _otherSum = value; }
        }

        /// <summary>
        /// Updates the _Mode propertie to the parameter which needs to be "player" or "computer"
        /// </summary>
        /// <param name="mode">Playing againt a player or computer</param>
        public SevensOut(string mode)
        {
            // Updates the Statistic
            Statistics.SevensOutPlaysUpdate();
            // Assigns the mode property to the parameter
            mode = mode.ToLower();
            mode = mode.Trim();
            _Mode = mode;
        }

        /// <summary>
        /// Mainly for testing and sets the _Mode to "computer"
        /// </summary>
        public SevensOut() 
        {
            // Assigns the mode property to "computer"
            _Mode = "computer";
        }

        /// <summary>
        /// Plays the sevens out game
        /// </summary>
        public override void Play()
        {
            // Player 1 turn
            Console.WriteLine("Player 1's turn");
            long player1Score = PlayRound();
            // Other player turn
            if (_Mode == "player")
            {
                Console.WriteLine("Player 2's turn");
            }

            else if (_Mode == "computer")
            {
                Console.WriteLine("computers turn");
            }

            long otherScore = PlayRound();
            // Displays the winner
            DetermineWinner(player1Score, otherScore);
        }

        /// <summary>
        /// Plays a round of the sevens out game
        /// </summary>
        /// <returns>It returns the total</returns>
        private long PlayRound()
        {
            bool done = false;
            List<Die> rolls = DiceList(2);
            long total = 0;
            int sum = 0;
            Console.WriteLine();
            // Main loop
            while (!done) 
            {
                // Getting the sum
                sum = rolls[0].Num + rolls[1].Num;

                DisplayDice(rolls);

                Console.WriteLine($"The sum is {sum}");

                // Checking what to do based on the sum

                if (sum == 7)
                {
                    break;
                }

                if (rolls[0].Num == rolls[1].Num)
                {
                    sum *= 2;
                    Console.WriteLine($"Your new sum is {sum}");
                }

                // Adding the sum to the total

                total += sum;

                Console.WriteLine($"The total is {total}");
                Console.WriteLine();

                // Rerolling the dice

                foreach (Die die in rolls)
                {
                    die.Roll();
                }
            }

            Console.WriteLine($"The final total is {total}");
            Statistics.SevensOutHighScoreUpdate(total);
            Console.WriteLine();

            // Updating the propertie for the testing class

            if (Player1Sum == 0)
            {
                Player1Sum = sum;
            }

            else
            {
                OtherSum = sum;
            };

            return total;            
        }

        /// <summary>
        /// Determines the winner of the game
        /// </summary>
        /// <param name="player1Score">Player 1 score</param>
        /// <param name="otherScore">The other player score</param>
        private void DetermineWinner(long player1Score, long otherScore)
        {
            // Displaying the final total
            if (_Mode == "player")
            {
                Console.WriteLine($"player 1 score is {player1Score} and player 2 score is {otherScore}");
            }

            else 
            {
                Console.WriteLine($"player 1 score is {player1Score} and the computers score is {otherScore}");
            }

            Console.WriteLine();

            // Displaying the winner

            if (player1Score > otherScore)
            {
                Console.WriteLine("Player 1 wins");
                Statistics.player1WinsUpdate();
            }

            else if (player1Score < otherScore)
            {
                if (_Mode == "player")
                {
                    Console.WriteLine("Player 2 wins");
                    Statistics.player2WinsUpdate();
                }
                else if (_Mode == "computer")
                {
                    Console.WriteLine("Computer wins");
                    Statistics.ComputerWinsUpdate();
                }
            }

            else
            {
                Console.WriteLine("The game was a draw");
                Statistics.DrawsUpdate();
            }
        }
    }
}   