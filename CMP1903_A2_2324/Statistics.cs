using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324
{
    internal class Statistics
    {
        private static int sevensOutPlays = 0;
        private static int sevensOutHighScore = 0;
        private static int threeOrMorePlays = 0;

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

        static public void DisplayStatistics()
        {
            Console.WriteLine($"Sevens out has been played {sevensOutPlays} times");
            Console.WriteLine($"The sevens out high score is {sevensOutHighScore}");
            Console.WriteLine($"Three or more has been played {threeOrMorePlays} times");
            Console.WriteLine();
        }
    }
}