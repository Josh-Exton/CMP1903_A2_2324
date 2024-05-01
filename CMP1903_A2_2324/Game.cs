using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Xml.Serialization;

namespace CMP1903_A2_2324
{
    /// <summary>
    /// A dice game which you inherit from
    /// </summary>
    internal abstract class Game : IPlayable
    {
        // Defining the mode field
        private string _mode;

        /// <summary>
        /// Protect propertie so the inherited games can access the mode
        /// </summary>
        protected string _Mode
        {
            get { return _mode; }
            set { _mode = value; } 
        }

        /// <summary>
        /// Makes sure there is a Play functionality in the inherited classes
        /// </summary>
        public abstract void Play();

        /// <summary>
        /// Creates a array containg die objects
        /// </summary>
        /// <param name="length">How many dice you want in the list</param>
        /// <returns>The dice array</returns>
        /// <exception cref="ArgumentException">If you pass in a value less than 1</exception>
        protected List<Die> DiceList(int length)
        {
            // If a value is passed that is less than 1 it throws an exception
            if (length <= 0)
            {
                throw new ArgumentException("Length must be a positive integer.", nameof(length));
            }

            // Creates an empty array of the size specified and adds that amount of dice objects
            List<Die> list = new List<Die>();
            for (int i = 0; i < length; i++)
            {
                list.Add(new Die());
            }

            return list;
        }


        /// <summary>
        /// Displays the dice rolls
        /// </summary>
        /// <param name="dice">The dice list</param>
        protected void DisplayDice(List<Die> dice)
        {
            Console.Write("The numbers you rolled are - ");
            foreach (Die die in dice)
            {
                Console.Write($"{die.Num} ");
            }

            Console.WriteLine();
        }

    }
}