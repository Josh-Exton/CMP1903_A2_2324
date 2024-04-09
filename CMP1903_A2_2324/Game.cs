using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace CMP1903_A2_2324
{
    internal class Game
    {
        SevensOut sevensOut = new SevensOut();
        ThreeOrMore threeOrMore = new ThreeOrMore();
        public void Menu()
        {
            Console.WriteLine("hi");
            bool done = false;
            while (!done)
            {
                Console.WriteLine("Select which game you want to play below");
                Console.WriteLine("1: sevens out");
                Console.WriteLine("2: three or more");
                string choice = Console.ReadLine();
                choice = choice.Trim();
                if (choice == "1")
                { 
                    sevensOut.Play();
                    done = true;
                }
                else if (choice == "2") 
                {
                    threeOrMore.Play();
                    done = true;
                }
            }
        }
    }
}
