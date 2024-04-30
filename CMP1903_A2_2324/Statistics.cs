using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Formats.Asn1.AsnWriter;

namespace CMP1903_A2_2324
{
    /// <summary>
    /// Provides statistical data for a game
    /// </summary
    internal static class Statistics
    {

        // defining the fields

        private static int _sevensOutPlays = 0;
        private static long _sevensOutHighScore = 0;
        private static int _threeOrMorePlays = 0;
        private static long _threeOrMoreMostTurns = 0;
        private static int _player1Wins = 0;
        private static int _player2Wins = 0;
        private static int _computerWins = 0;
        private static int _draws = 0;

        // defining the properties

        /// <summary>
        /// Gets the number of times Sevens Out has been played
        /// </summary>
        public static int SevensOutPlays
        {
            get { return _sevensOutPlays; }
            private set { _sevensOutPlays = value; }
        }

        /// <summary>
        /// Gets the high score achieved in Sevens Out
        /// </summary>
        public static long SevensOutHighScore
        {
            get { return _sevensOutHighScore; }
            private set { _sevensOutHighScore = value; }
        }

        /// <summary>
        /// Gets the number of times Three Or More has been played
        /// </summary>
        public static int ThreeOrMorePlays
        {
            get { return _threeOrMorePlays; }
            private set { _threeOrMorePlays = value; }
        }

        /// <summary>
        /// Gets the number of times Three Or More has been played
        /// </summary>
        public static long ThreeOrMoreMostTurns
        {
            get { return _threeOrMoreMostTurns; }
            private set { _threeOrMoreMostTurns = value; }
        }

        /// <summary>
        /// Gets the number of times player 1 has won
        /// </summary>
        public static int Player1Wins
        {
            get { return _player1Wins; }
            private set { _player1Wins = value; }
        }

        /// <summary>
        /// Gets the number of times player 2 has won
        /// </summary>
        public static int Player2Wins
        {
            get { return _player2Wins; }
            private set { _player2Wins = value; }
        }

        /// <summary>
        /// Gets the number of times the computer has won
        /// </summary>
        public static int ComputerWins
        {
            get { return _computerWins; }
            private set { _computerWins = value; }
        }

        /// <summary>
        /// Gets the number of times the game is a draw
        /// </summary>
        public static int Draws
        {
            get { return _draws; }
            private set { _draws = value; }
        }

        /// <summary>
        /// Updates the SevensOutPlays propertie 
        /// </summary>
        public static void SevensOutPlaysUpdate()
        {
            SevensOutPlays++;
        }


        /// <summary>
        /// Updates the SevensOutHighScore propertie
        /// </summary>
        /// <param name="score">The score the game you played</param>
        public static void SevensOutHighScoreUpdate(long score)
        { 
            if (SevensOutHighScore < score) 
            { 
                SevensOutHighScore = score;
            }
        }

        /// <summary>
        /// Updates the ThreeOrMorePlays propertie 
        /// </summary>
        public static void ThreeOrMorePlaysUpdate()
        { 
            ThreeOrMorePlays++;
        }

        /// <summary>
        /// Updates the ThreeOrMoreMostTurns propertie 
        /// </summary>
        public static void ThreeOrMoreMostTurnsUpdate(long turn)
        {
            if (ThreeOrMoreMostTurns < turn)
            {
                ThreeOrMoreMostTurns = turn;
            }
        }

        /// <summary>
        /// Updates the player1Wins propertie 
        /// </summary>
        public static void player1WinsUpdate()
        {
            Player1Wins++;
        }

        /// <summary>
        /// Updates the player2Wins propertie 
        /// </summary>
        public static void player2WinsUpdate() 
        { 
            Player2Wins++;
        }

        /// <summary>
        /// Updates the ComputerWins propertie 
        /// </summary>
        public static void ComputerWinsUpdate() 
        { 
            ComputerWins++;
        }

        /// <summary>
        /// Updates the Draws propertie 
        /// </summary>
        public static void DrawsUpdate()
        { 
            Draws++;
        }

        /// <summary>
        /// Displays all of the statistics
        /// </summary>
        public static void DisplayStatistics()
        {
            Console.WriteLine();
            Console.WriteLine($"Sevens out has been played {SevensOutPlays} times");
            Console.WriteLine($"The sevens out high score is {SevensOutHighScore}");
            Console.WriteLine($"Three or more has been played {ThreeOrMorePlays} times");
            Console.WriteLine($"The most amount of turns played in Three or more is {ThreeOrMoreMostTurns} times");
            Console.WriteLine($"Player 1 has won {Player1Wins} times in total");
            Console.WriteLine($"Player 2 has won {Player2Wins} times in total");
            Console.WriteLine($"The computer has won {ComputerWins} times in total");
            Console.WriteLine($"There has been {Draws} in total");
        }
    }
}