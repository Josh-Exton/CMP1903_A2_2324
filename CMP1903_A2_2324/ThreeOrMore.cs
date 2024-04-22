using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324
{
    internal class ThreeOrMore : Game, IPlayable
    {
        public ThreeOrMore() 
        {
            Statistics.ThreeOrMorePlaysUpdate();
            Play();
        }
        public void Play()
        {
            Console.WriteLine();
            List<Die> rolls = DiceList(5);
            List<int> numList = new List<int>(5);
            int total = 0;
            while (total < 20)
            {

                for (int i = 0; i < rolls.Count; i++) 
                {
                    numList.Insert(i, rolls[i].Roll());
                }

                Console.Write("The numbers you rolled are - ");
                foreach (int i in numList)
                {
                    Console.Write($"{i} ");
                }

                Console.WriteLine();
                List<int> duplicates = new List<int> ();

                int counter = 5;
                while ((duplicates.Count() == 0) && (counter > 1))
                {
                    duplicates = numList
                    .GroupBy(x => x)
                    .Where(g => g.Count() >= counter)
                    .Select(g => g.Key)
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
                            foreach (int i in numList)
                            {
                                numList.Insert(i, rolls[i].Roll());
                                counter = 5;
                                while ((duplicates.Count() == 0) && (counter > 1))
                                {
                                    duplicates = numList
                                    .GroupBy(x => x)
                                    .Where(g => g.Count() >= counter)
                                    .Select(g => g.Key)
                                    .ToList();
                                    counter--;
                                }
                            }
                        }

                        else if (choice == "2")
                        {
                            foreach (int i in numList)
                            {
                                if (duplicates[0] == numList[i])
                                {
                                    numList.Insert(i, rolls[i].Roll());
                                }
                            }
                            counter = 4;
                            while ((duplicates.Count() == 0) && (counter > 0))
                            {
                                duplicates = numList
                                .GroupBy(x => x)
                                .Where(g => g.Count() > counter)
                                .Select(g => g.Key)
                                .ToList();
                                counter--;
                            }
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
                }

                if (counter == 2)
                {
                    total = total + 3;
                }
                if (counter == 3)
                { 
                    total = total + 6;
                }
                if(counter == 4) 
                { 
                    total = total + 12;
                }
                Console.WriteLine(counter + 1);
                Console.WriteLine(total);
                Console.ReadLine();
            }
        }
    }
}