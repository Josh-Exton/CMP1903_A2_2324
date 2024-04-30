using System;
using System.Xml.Serialization;

namespace CMP1903_A2_2324
{
    /// <summary>
    /// Plays the Sevens Out game
    /// </summary>
    internal sealed class SevensOut : Game
    {
        /// <summary>
        /// Updates the _Mode propertie to the parameter which needs to be "player" or "computer"
        /// </summary>
        /// <param name="mode">Playing againt a player or computer</param>
        public SevensOut(string mode)
        {
            Statistics.SevensOutPlaysUpdate();
            mode = mode.ToLower();
            mode = mode.Trim();
            _Mode = mode;
        }

        /// <summary>
        /// Mainly for testing and sets the _Mode to "computer"
        /// </summary>
        public SevensOut() 
        {
            _Mode = "computer";
        }

        public override void Play()
        {
            Console.WriteLine("Player 1's turn");
            long player1Score = PlayRound();
            if (_Mode == "player")
            {
                Console.WriteLine("Player 2's turn");
            }

            else if (_Mode == "computer")
            {
                Console.WriteLine("computers turn turn");
            }

            long otherScore = PlayRound();
            DetermineWinner(player1Score, otherScore);
        }

        private long PlayRound()
        {
            bool done = false;
            Die[] rolls = DiceArray(2);
            long total = 0;
            while (!done) 
            {
                int sum = rolls[0].Num + rolls[1].Num;

                Console.WriteLine($"Rolled number 1 is {rolls[0].Num}");
                Console.WriteLine($"Rolled number 2 is {rolls[1].Num}");
                Console.WriteLine($"The sum is {sum}");

                if (sum == 7)
                {
                    break;
                }

                if (rolls[0].Num == rolls[1].Num)
                {
                    sum *= 2;
                    Console.WriteLine($"Your new sum is {sum}");
                }

                total += sum;

                Console.WriteLine($"The total is {total}");
                Console.WriteLine();

                foreach (Die die in rolls)
                {
                    die.Roll();
                }
            }

            Console.WriteLine($"The final total is {total}");
            Statistics.SevensOutHighScoreUpdate(total);
            Console.WriteLine();
            return total;            
        }

        private void DetermineWinner(long player1Score, long player2Score)
        {
            if (player1Score > player2Score)
            {
                Console.WriteLine("Player 1 wins");
                Statistics.player1WinsUpdate();
            }

            else if (player1Score < player2Score)
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