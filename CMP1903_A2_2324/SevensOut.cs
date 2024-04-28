using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace CMP1903_A2_2324
{
    internal sealed class SevensOut : Game, IPlayable
    {

        public SevensOut(string mode)
        {
            Statistics.SevensOutPlaysUpdate();
            Mode = mode;
        }

        public void Play()
        {
            long player1Score = PlayRound();
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
                }

                total += sum;

                Console.WriteLine($"The total is {total}");

                foreach (Die die in rolls)
                {
                    die.Roll();
                }
            }
            Console.WriteLine();
            Console.WriteLine($"The final total is {total}");
            Statistics.SevensOutHighScoreUpdate(total);

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
                if (Mode == "player")
                {
                    Console.WriteLine("Player 2 wins");
                    Statistics.player2WinsUpdate();
                }
                else if (Mode == "computer")
                {
                    Console.WriteLine("Computer wins");
                    Statistics.computerWinsUpdate();
                }
            }
            else
            {
                Console.WriteLine("The game was a draw");
                Statistics.drawUpdate();
            }
        }
    }
}   