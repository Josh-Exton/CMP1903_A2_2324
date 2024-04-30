using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Xml.Serialization;

namespace CMP1903_A2_2324
{
    internal class Menu
    {

        public void DisplayMenu()
        {
            bool done = false;
            string choice;
            while (done == false)
            {
                DisplayOptions();
                choice = Console.ReadLine().Trim();
                if (choice == "1")
                {
                    string mode = DisplayModeOptions();
                    SevensOut sevensOut = new SevensOut(mode);
                    sevensOut.Play();
                }
                else if (choice == "2")
                {
                    string mode = DisplayModeOptions();
                    ThreeOrMore threeOrMore = new ThreeOrMore(mode);
                    threeOrMore.Play();
                }
                else if (choice == "3")
                {
                    Statistics.DisplayStatistics();
                }
                else if (choice == "4")
                {
                    Testing testing = new Testing();
                    testing.DieCheck();
                }
                else if (choice == "5")
                {
                    done = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please select again.");
                }
                Console.WriteLine();
            }
        }
        private void DisplayOptions()
        {
            Console.WriteLine("Please select what you want to do from the options below");
            Console.WriteLine("1: play sevens out");
            Console.WriteLine("2: play three or more");
            Console.WriteLine("3: provide statistics");
            Console.WriteLine("4: test");
            Console.WriteLine("5: exit");
        }

        private string DisplayModeOptions()
        {
            string modeChoice;
            string mode = "";
            Console.WriteLine();
            Console.WriteLine("Please select what you want to do from the options below");
            Console.WriteLine("1: play 2 player mode");
            Console.WriteLine("2: play vs computer");
            while ((mode != "player") && (mode != "computer"))
            {
                modeChoice = Console.ReadLine().Trim();
                Console.WriteLine(modeChoice);
                if (modeChoice == "1")
                {
                    mode = "player";
                }

                else if (modeChoice == "2")
                {
                    mode = "computer";
                }

                else
                {
                    Console.WriteLine("Invalid choice. Please select again.");
                }

                Console.WriteLine();
            }

            return mode;
        }
    }
}