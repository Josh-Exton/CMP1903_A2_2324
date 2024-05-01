using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace CMP1903_A2_2324
{
    internal sealed class ThreeOrMore : Game
    {

        // Setting up the scores so the testing class can access them.

        // defining the fields 
        private int _player1Total;
        private int _otherTotal;

        // defining the properties

        /// <summary>
        /// Gets the final sum of player 1
        /// </summary>
        public int Player1Total
        {
            get { return _player1Total; }
            private set { _player1Total = value; }
        }

        /// <summary>
        /// Gets the final sum of the other player
        /// </summary>
        public int OtherTotal
        {
            get { return _otherTotal; }
            private set { _otherTotal = value; }
        }

        /// <summary>
        /// Updates the _Mode propertie to the parameter which needs to be "player" or "computer"
        /// </summary>
        /// <param name="mode">Playing againt a player or computer</param>
        public ThreeOrMore(string mode)
        {
            // Updates the Statistic
            Statistics.ThreeOrMorePlaysUpdate();
            // Assigns the mode property to the parameter
            mode = mode.ToLower();
            mode = mode.Trim();
            _Mode = mode;
        }

        /// <summary>
        /// Mainly for testing and sets the _Mode to "computer"
        /// </summary>
        public ThreeOrMore()
        {
            // Assigns the mode property to "computer"
            _Mode = "computer";
        }

        /// <summary>
        /// Plays the three of more game
        /// </summary>
        public override void Play()
        {
            long turn = 1;
            List<Die> rolls = DiceList(5);

            // Main game loop
            while ((Player1Total < 20) && (OtherTotal < 20))
            {
                // Displaying who's turn it is
                if (turn % 2 == 1)
                {
                    Console.WriteLine($"Player 1 turn");
                }

                else if ((turn % 2 == 0) && (_Mode == "player"))
                {
                    Console.WriteLine($"Player 2 turn");
                }

                else
                {
                    Console.WriteLine($"The computers turn");
                }

                Console.WriteLine();
                DisplayDice(rolls);
                // Finding the duplicates
                int duplicateValue = FindDuplicatesValue(rolls);
                int duplicateCount = FindDuplicatesCount(rolls);

                // Checking for a reroll
                duplicateCount = CheckReroll(duplicateValue, duplicateCount, ref rolls, turn);

                // Updating the score
                if (turn % 2 == 1)
                {
                    Player1Total = ScoreUpdate(duplicateCount, Player1Total, 1);
                }

                else
                {
                    OtherTotal = ScoreUpdate(duplicateCount, OtherTotal, 2);
                }

                // Rerolling the dice
                foreach (Die die in rolls)
                {
                    die.Roll();
                }

                // Incrementing the turn
                turn++;
                Console.WriteLine();
            }
            DisplayWinner(turn);
        }

        /// <summary>
        /// Gets how many times a duplicate which appears the most appears
        /// </summary>
        /// <param name="dice">The dice list</param>
        /// <returns>How many times the duplicate appears</returns>
        private int FindDuplicatesCount(List<Die> dice)
        {
            // A linq which gets how many times any duplicate appears
            var duplicates = from die in dice
                             group die by die.Num into dieGroup
                             where dieGroup.Count() > 1
                             select dieGroup.Count();

            if (duplicates.Count() > 0 ) 
            {
                // Reurinmg the biggest number
                return duplicates.Max();
            }

            // returning 1 if there are no duplicates
            return 1;
        }

        /// <summary>
        /// Gets the value of the duplicate which appears the most
        /// </summary>
        /// <param name="dice">The dice list</param>
        /// <returns>The value of the duplicate</returns>
        private int FindDuplicatesValue(List<Die> dice)
        {
            // A linq which gets the value of the duplicate which appears the most
            var duplicates = from die in dice
                             group die by die.Num into dieGroup
                             where dieGroup.Count() > 1
                             orderby dieGroup.Count() descending
                             select dieGroup.Key;

            // Displays the first result or a default value if there are no duplicates
            return duplicates.FirstOrDefault();
        }

        /// <summary>
        /// Checks to see if the list needs rerolling
        /// </summary>
        /// <param name="value">The value that appears the most</param>
        /// <param name="count">How many times the value appears</param>
        /// <param name="rolls">The dice list</param>
        /// <param name="turn">The current turn</param>
        /// <returns>The count because it could perform another count check</returns>
        private int CheckReroll(int value, int count, ref List<Die> rolls, long turn)
        {
            // Checking if the count is 2
            if (count == 2) 
            {
                bool done = false;
                string choice = "";
                // A loop to make sure the suer enter the correct value
                while (!done)
                {
                    // Asking the user which option they want to select
                    Console.WriteLine("Please select what you want to do from the options below");
                    Console.WriteLine("1: Reroll all dice");
                    Console.WriteLine("2: Reroll remaining dice");

                    if ((turn % 2 == 0) && (_Mode == "computer"))
                    {
                        // I made the computer choose 2 since it is the optimal choice
                        choice = "2";
                        done = true;
                    }

                    else if ((choice != "1") || (choice != "2"))
                    {
                        choice = Console.ReadLine().Trim();
                        done = true;
                    }

                    else
                    {
                        Console.WriteLine("Invalid choice. Please select again.");
                    }

                    Console.WriteLine();
                }

                // Rerolls the list
                foreach (Die die in rolls)
                {
                    // Depending on the user choice it skips the duplicated value
                    if ((choice == "2") && (value == die.Num))
                    { 
                        continue;
                    }
                    die.Roll();
                }

                DisplayDice(rolls);

                // Getting the count of the rerolled list
                count = FindDuplicatesCount(rolls);
            }

            return count;
        }

        /// <summary>
        /// Updates the score
        /// </summary>
        /// <param name="count">>How many times a duplicate which appears the most appears</param>
        /// <param name="total">The current total</param>
        /// <param name="turn">What turn it is</param>
        /// <returns>The new total</returns>
        private int ScoreUpdate(int count, int total, int turn)
        {
            // Checking how many points the player haqs scored
            int score = 0;
            if (count == 3)
            {
                score = 3;
            }

            else if (count == 4)
            {
                score = 6;
            }

            else if (count == 5)
            {
                score = 12;
            }

            total += score;

            // Displays the final total and the points they scored
            if (turn == 1)
            {
                Console.WriteLine($"Player 1 has scored {score} points");
                Console.WriteLine($"Player 1 total is {total} points");
            }

            else if ((turn == 2) && (_Mode == "player"))
            {
                Console.WriteLine($"Player 2 has scored {score} points");
                Console.WriteLine($"Player 2 total is {total} points");
            }

            else
            {
                Console.WriteLine($"The computer has scored {score} points");
                Console.WriteLine($"The computers total is {total} points");
            }

            return total;
        }

        /// <summary>
        /// Displays the winner
        /// </summary>
        /// <param name="turn">The current turn</param>
        private void DisplayWinner(long turn)
        {
            // Displays who has won based on the current turn
            if (turn % 2 == 0)
            {
                Console.WriteLine($"Player 1 wins");
                Statistics.player1WinsUpdate();
            }

            else if ((turn % 2 == 1) && (_Mode == "player"))
            {
                Console.WriteLine($"Player 2 wins");
                Statistics.player2WinsUpdate();
            }

            else
            {
                Console.WriteLine($"The computer wins");
                Statistics.ComputerWinsUpdate();
            }
        }
    }
}