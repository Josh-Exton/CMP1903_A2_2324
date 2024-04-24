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
            int player1Total = 0;
            int otherTotal = 0;
            int turn = 1;
            while ((player1Total < 20) && (otherTotal < 20))
            {
                Console.WriteLine();

                Console.Write("The numbers you rolled are - ");
                foreach (Die dice in rolls)
                {
                    Console.Write($"{dice.Num} ");
                }

                Console.WriteLine();

                int counter = 5;
 
                List<Die> duplicates = new List<Die> ();

                while ((duplicates.Count == 0) && (counter > 1))
                {
                    duplicates = (from die in rolls
                                 group die by die.Num into g
                                 where g.Count() >= counter
                                 from dice in g
                                 select dice).
                                 ToList();

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
                            foreach (Die dice in rolls)
                            {
                                dice.Roll();
                            }
                            done = true;
                        }

                        else if (choice == "2")
                        {
                            foreach (Die dice in rolls)
                            {
                                if (dice.Num != duplicates[0].Num)
                                {
                                    dice.Roll();
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

                    foreach (Die dice in rolls)
                    {
                        Console.Write($"{dice.Num} ");
                    }

                    Console.ReadLine();

                    Console.WriteLine();

                    counter = 5;
                    duplicates.Clear();

                    while ((duplicates.Count == 0) && (counter > 1))
                    {
                        duplicates = (from die in rolls
                                      group die by die.Num into g
                                      where g.Count() >= counter
                                      from dice in g
                                      select dice).
                                      ToList();

                        counter--;
                    }
                }
                if ((turn % 2) == 1)
                {
                    if (counter == 2)
                    {
                        player1Total = player1Total + 3;
                        Console.WriteLine("Player 1 just scored 3 point");
                    }
                    else if (counter == 3)
                    {
                        player1Total = player1Total + 6;
                        Console.WriteLine("Player 1 just scored 6 point");
                    }
                    else if (counter == 4)
                    {
                        player1Total = player1Total + 12;
                        Console.WriteLine("Player 1 just scored 12 point");
                    }
                    Console.WriteLine($"Player 1 total is {player1Total}");
                }

                else
                {
                    if (counter == 2)
                    {
                        otherTotal = otherTotal + 3;
                    }
                    else if (counter == 3)
                    {
                        otherTotal = otherTotal + 6;
                    }
                    else if (counter == 4)
                    {
                        otherTotal = otherTotal + 12;
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

                foreach (Die dice in rolls)
                {
                    dice.Roll();
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