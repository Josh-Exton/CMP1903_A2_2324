using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324
{
    internal static class Statistics
    {

        // defining the fields
        private static int _sevensOutPlays = 0;
        private static long _sevensOutHighScore = 0;
        private static int _threeOrMorePlays = 0;
        private static int _player1Wins = 0;
        private static int _player2Wins = 0;
        private static int _computerWins = 0;
        private static int _draws = 0;

        // defining the propities
        static public int SevensOutPlays
        {
            get { return _sevensOutPlays; }
            private set { _sevensOutPlays = value; }
        }

        static public long SevensOutHighScore
        {
            get { return _sevensOutHighScore; }
            private set { _sevensOutHighScore = value; }
        }
        static public int ThreeOrMorePlays
        {
            get { return _threeOrMorePlays; }
            private set { _threeOrMorePlays = value; }
        }

        static public int Player1Wins
        {
            get { return _player1Wins; }
            private set { _player1Wins = value; }
        }

        static public int Player2Wins
        {
            get { return _player2Wins; }
            private set { _player2Wins = value; }
        }
        static public int ComputerWins
        {
            get { return _computerWins; }
            private set { _computerWins = value; }
        }
        static public int Draws
        {
            get { return _draws; }
            private set { _draws = value; }
        }

        static public void SevensOutPlaysUpdate()
        {
            SevensOutPlays++;
        }

        static public void SevensOutHighScoreUpdate(long score)
        { 
            if (SevensOutHighScore < score) 
            { 
                SevensOutHighScore = score;
            }
        }

        static public void ThreeOrMorePlaysUpdate()
        { 
            ThreeOrMorePlays++;
        }

        static public void player1WinsUpdate()
        {
            Player1Wins++;
        }

        static public void player2WinsUpdate() 
        { 
            Player2Wins++;
        }

        static public void computerWinsUpdate() 
        { 
            ComputerWins++;
        }

        static public void drawUpdate()
        { 
            Draws++;
        }

        static public void DisplayStatistics()
        {
            Console.WriteLine();
            Console.WriteLine($"Sevens out has been played {SevensOutPlays} times");
            Console.WriteLine($"The sevens out high score is {SevensOutHighScore}");
            Console.WriteLine($"Three or more has been played {ThreeOrMorePlays} times");
            Console.WriteLine($"Player 1 has won {Player1Wins} times in total");
            Console.WriteLine($"Player 2 has won {Player2Wins} times in total");
            Console.WriteLine($"The computer has won {ComputerWins} times in total");
            Console.WriteLine($"There has been {Draws} in total");
        }
    }
}