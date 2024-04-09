using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Xml.Serialization;

namespace CMP1903_A2_2324
{
    internal class Game
    {
        static Game() 
        {
            Console.WriteLine("Constructer");
            Menu();
        }

        static private void Menu()
        {
            bool done = false;
            string choice;
            DisplayOptions();
            while (done == false)
            {
                choice = Console.ReadLine().Trim();
                if (choice == "1")
                {
                    SevensOut sevensOut = new SevensOut();
                    DisplayOptions();
                }
                else if (choice == "2")
                {
                    ThreeOrMore threeOrMore = new ThreeOrMore();
                    DisplayOptions();
                }
                else if (choice == "3")
                { 
                    Statistics statistics = new Statistics();
                    DisplayOptions();
                }
                else if (choice == "4")
                {
                    Testing testing = new Testing();
                    DisplayOptions();
                }
                else if (choice == "5")
                {
                    done = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please select again.");
                }
            }
        }
        static private void DisplayOptions()
        {
            Console.WriteLine("Please select what you want to do from the options below");
            Console.WriteLine("1: play sevens out");
            Console.WriteLine("2: play three or more");
            Console.WriteLine("3: provide statistics");
            Console.WriteLine("4: test");
            Console.WriteLine("5: exit");
        }

    }
}
