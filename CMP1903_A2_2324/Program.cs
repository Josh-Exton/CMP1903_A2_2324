﻿using System;

namespace CMP1903_A2_2324
{
    internal class Program
    {
        /// <summary>
        /// Starting point of the program
        /// </summary>
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.DisplayMenu();
            Console.ReadKey();
        }
    }
}