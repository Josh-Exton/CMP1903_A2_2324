using System;
using System.Linq;
using System.Xml.Serialization;

namespace CMP1903_A2_2324
{
    /// <summary>
    /// The main program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Starting point of the program
        /// </summary>
        static void Main(string[] args)
        {
            // Creating the menu object
            Menu menu = new Menu();
            // Calling the menu display method
            menu.DisplayMenu();
            Console.ReadKey();
        }
    }
}