using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324
{
    static class Statistics
    {
        private static int sevensOutPlays = 0;
        private static int sevensOutHighScore = 0;
        private static int threeOrMorePlays = 0;
        private static int player1Wins = 0;
        private static int player2Wins = 0;
        private static int computerwins = 0;

        static public void SevensOutPlaysUpdate()
        {
            sevensOutPlays++;
        }

        static public void SevensOutHighScoreUpdate(int score)
        { 
            if (sevensOutHighScore < score) 
            { 
                sevensOutHighScore = score;
            }
        }

        static public void ThreeOrMorePlaysUpdate()
        { 
            threeOrMorePlays++;
        }

        static public void player1WinsUpdate()
        {
            player1Wins++;
        }

        static public void player2WinsUpdate() 
        { 
            player2Wins++;
        }

        static public void computerwinsUpdate() 
        { 
            computerwins++;
        }

        static public void DisplayStatistics()
        {
            Console.WriteLine();
            Console.WriteLine($"Sevens out has been played {sevensOutPlays} times");
            Console.WriteLine($"The sevens out high score is {sevensOutHighScore}");
            Console.WriteLine($"Three or more has been played {threeOrMorePlays} times");
            Console.WriteLine($"Player 1 has won {player1Wins} times");
            Console.WriteLine($"Player 2 has won {player2Wins} times");
            Console.WriteLine($"The computer has won {computerwins} times");
        }
    }
}