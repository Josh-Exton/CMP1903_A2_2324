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
        /// <summary>
        /// Updates the _Mode propertie to the parameter which needs to be "player" or "computer"
        /// </summary>
        /// <param name="mode">Playing againt a player or computer</param>
        public ThreeOrMore(string mode)
        {
            Statistics.ThreeOrMorePlaysUpdate();
            mode = mode.ToLower();
            mode = mode.Trim();
            _Mode = mode;
        }

        /// <summary>
        /// Mainly for testing and sets the _Mode to "computer"
        /// </summary>
        public ThreeOrMore()
        {
            _Mode = "computer";
        }

        public override void Play()
        {
            int player1Total = 0;
            int otherTotal = 0;
            long turn = 1;
            Die[] rolls = DiceArray(5);

            while ((player1Total < 20) && (otherTotal < 20))
            {
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
                int duplicateValue = FindDuplicatesValue(rolls);
                int duplicateCount = FindDuplicatesCount(rolls);

                duplicateCount = CheckReroll(duplicateValue, duplicateCount, ref rolls, turn);

                if (turn % 2 == 1)
                {
                    player1Total = ScoreUpdate(duplicateCount, player1Total, 1);
                }

                else
                {
                    otherTotal = ScoreUpdate(duplicateCount, otherTotal, 2);
                }


                foreach (Die die in rolls)
                {
                    die.Roll();
                }

                turn++;
                Console.WriteLine();
            }
            DisplayWinner(turn);
        }

        private void DisplayDice(Die[] dice)
        {
            Console.Write("The numbers you rolled are - ");
            foreach (Die die in dice)
            {
                Console.Write($"{die.Num} ");
            }

            Console.WriteLine();
        }

        private int FindDuplicatesCount(Die[] dice)
        {
            var duplicates = from die in dice
                             group die by die.Num into dieGroup
                             where dieGroup.Count() > 1
                             select dieGroup.Count();

            if (duplicates.Count() > 0 ) 
            {
                return duplicates.Max();
            }

            return 0;
        }

        private int FindDuplicatesValue(Die[] dice)
        {
            var duplicates = from die in dice
                             group die by die.Num into dieGroup
                             where dieGroup.Count() > 1
                             orderby dieGroup.Count() descending
                             select dieGroup.Key;

            return duplicates.FirstOrDefault();
        }

        private int CheckReroll(int value, int count, ref Die[] rolls, long turn)
        {
            if (count == 2) 
            {
                bool done = false;
                string choice = "";
                while (!done)
                {
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

                foreach (Die die in rolls)
                {
                    if ((choice == "2") && (value == die.Num))
                    { 
                        continue;
                    }
                    die.Roll();
                }

                DisplayDice(rolls);

                count = FindDuplicatesCount(rolls);
            }

            return count;
        }

        private int ScoreUpdate(int count, int total, int turn)
        {
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

        private void DisplayWinner(long turn)
        {
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