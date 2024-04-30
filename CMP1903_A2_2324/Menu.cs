using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Xml.Serialization;

namespace CMP1903_A2_2324
{
    /// <summary>
    /// The menu of the game
    /// </summary>
    internal class Menu
    {
        /// <summary>
        /// Displays the menu
        /// </summary>
        public void DisplayMenu()
        {
            bool done = false;
            string choice;
            // Makes sure the user enters the right option
            while (done == false)
            {
                DisplayOptions();
                choice = Console.ReadLine().Trim();

                // Checking what the user inputted
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

        /// <summary>
        /// Displays the menu options
        /// </summary>
        private void DisplayOptions()
        {
            // Writes out the options
            Console.WriteLine("Please select what you want to do from the options below");
            Console.WriteLine("1: play sevens out");
            Console.WriteLine("2: play three or more");
            Console.WriteLine("3: provide statistics");
            Console.WriteLine("4: test");
            Console.WriteLine("5: exit");
        }

        /// <summary>
        /// Displays the mode options and asks you which mode you play
        /// </summary>
        /// <returns>Returns the mode you play</returns>
        private string DisplayModeOptions()
        {
            string modeChoice;
            string mode = "";
            Console.WriteLine();
            // Writes out the options
            Console.WriteLine("Please select what you want to do from the options below");
            Console.WriteLine("1: play 2 player mode");
            Console.WriteLine("2: play vs computer");
            // Makes sure the user enters the right option
            while ((mode != "player") && (mode != "computer"))
            {
                modeChoice = Console.ReadLine().Trim();
                Console.WriteLine(modeChoice);
                // Checking what the user inputted
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