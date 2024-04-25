using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324
{
    internal sealed class SevensOut : Game, IPlayable
    {
        private string _mode;

        private string Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public SevensOut(string mode)
        {
            Statistics.SevensOutPlaysUpdate();
            Mode = mode;
            Play();
        }

        public void Play()  
        {
            Die[] rolls = DiceArray(2);
            int sum;
            long player1Score = 0;
            long otherScore = 0;
            long total = 0;
            for (int i = 1; i <= 2; i++)
            {
                bool done = false;
                while (!done)
                {
                    Console.WriteLine();
                    sum = rolls[0].Num + rolls[1].Num;
                    Console.WriteLine($"Rolled number 1 is {rolls[0].Num}");
                    Console.WriteLine($"Rolled number 2 is {rolls[1].Num}");

                    if (sum == 7)
                    {
                        Console.WriteLine($"The sum is {sum}");
                        done = true;
                    }
                    else if (rolls[0].Num == rolls[1].Num)
                    {
                        sum = sum * 2;
                        total = total + sum;
                        Console.WriteLine($"The sum is {sum}");
                    }

                    else
                    {
                        total = total + sum;
                        Console.WriteLine($"The sum is {sum}");
                    }

                    Console.WriteLine($"The total is {total}");

                    foreach (Die dice in rolls)
                    {
                        dice.Roll();
                    }
                }
                Console.WriteLine();
                Console.WriteLine($"The final total is {total}");
                Statistics.SevensOutHighScoreUpdate(total);
                if (i == 1)
                { 
                    player1Score = total;
                    total = 0;
                }
                if (i == 2) 
                {
                    otherScore = total;
                }
            }
            if (player1Score > otherScore)
            {
                Console.WriteLine("Player 1 wins");
                Statistics.player1WinsUpdate();
            }
            else if ((player1Score < otherScore) && (Mode == "player"))
            {
                Console.WriteLine("Player 2 wins");
                Statistics.player2WinsUpdate();
            }
            else if ((player1Score < otherScore) && (Mode == "computer"))
            {
                Console.WriteLine("Computer wins");
                Statistics.computerWinsUpdate();
            }
            else 
            {
                Console.WriteLine("The game was a draw");
                Statistics.drawUpdate();
            }
        }
    }
}