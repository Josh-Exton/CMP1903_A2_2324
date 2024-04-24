using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324
{
    internal class ThreeOrMore : Game, IPlayable
    {
        private string _mode;
        public ThreeOrMore(string mode) 
        {
            Statistics.ThreeOrMorePlaysUpdate();
            _mode = mode;
            Play();
        }
        public void Play()
        {
            Die[] rolls = DiceArray(5);
            int[] numList = new int[5];
            int player1Total = 0;
            int otherTotal = 0;
            int turn = 1;
            while ((player1Total < 20) || (otherTotal < 20))
            {
                Console.WriteLine();
                for (int i = 0; i < rolls.Length; i++) 
                {
                    numList[i] = rolls[i].Num;
                }


                Console.Write("The numbers you rolled are - ");
                foreach (int i in numList)
                {
                    Console.Write($"{i} ");
                }

                Console.WriteLine();
                int counter = 4;

                List<int> duplicates = new List<int> ();

                while ((duplicates.Count == 0) && (counter > 1))
                {

                    duplicates = (from num in numList
                                 group num by num into g
                                 where g.Count() >= counter
                                 select g.Key)
                                .ToList();

                    counter--;
                }


                // Checks if the counter one less than it should be because it is always decremented
                if (counter == 1)
                {
                    bool done = false;
                    string choice;
                    while (!done) 
                    {
                        Console.WriteLine("Please select what you want to do from the options below");
                        Console.WriteLine("1: Reroll all dice");
                        Console.WriteLine("2: Reroll remaining dice");
                        choice = Console.ReadLine().Trim();
                        if (choice == "1")
                        {
                            for (int i = 0; i < rolls.Length; i++)
                            {
                                numList[i] = rolls[i].Roll();
                                Console.WriteLine($"i is {i}");
                            }
                            done = true;
                        }

                        else if (choice == "2")
                        {
                            for (int i = 0; i < rolls.Length; i++)
                            {
                                Console.WriteLine($"Duplicates 0 is {duplicates[0]}");
                                if (duplicates[0] == numList[i])
                                {
                                    numList[i] = rolls[i].Roll();
                                }
                            }
                            done = true;
                        }
                        else
                        {
                            Console.WriteLine("Please enter one of the options");
                        }
                    }

                    Console.Write("The numbers you rolled are - ");

                    foreach (int i in numList)
                    {
                        Console.Write($"{i} ");
                    }

                    counter = 5;
                    while ((duplicates.Count == 0) && (counter > 1))
                    {
                        duplicates = (from num in numList
                                      group num by num into g
                                      where g.Count() >= counter
                                      select g.Key)
                                     .ToList();
                        counter--;
                    }
                }
                if ((turn % 2) == 1)
                {
                    if (counter == 2)
                    {
                        player1Total = player1Total + 3;
                    }
                    else if (counter == 3)
                    {
                        player1Total = player1Total + 6;
                    }
                    else if (counter == 4)
                    {
                        player1Total = player1Total + 12;
                    }
                    Console.WriteLine($"Player 1 total is {player1Total}");
                }

                else
                {
                    if (counter == 2)
                    {
                        player1Total = player1Total + 3;
                    }
                    else if (counter == 3)
                    {
                        player1Total = player1Total + 6;
                    }
                    else if (counter == 4)
                    {
                        player1Total = player1Total + 12;
                    }
                    if (_mode == "player")
                    {
                        Console.WriteLine($"Player 2 total is {otherTotal}");
                    }
                    else
                    {
                        Console.WriteLine($"computers total is {otherTotal}");
                    }
                }

                foreach (Die i in rolls)
                {
                    i.Roll();
                }
                turn++;
            }
            if ((turn % 2) == 1)
            {
                Console.WriteLine("Player 1 wins");
            }
            else if ((turn % 2) == 0 && (_mode == "player"))
            {
                Console.WriteLine("Player 2 wins");
            }

            else
            {
                Console.WriteLine("computer wins");
            }
        }
    }
}