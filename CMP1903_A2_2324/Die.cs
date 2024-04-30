using System;
using System.Xml.Serialization;

namespace CMP1903_A2_2324
{
    /// <summary>
    /// Rolls a dice
    /// </summary>
    internal class Die
    {
        // Creating the random field
        private static Random rand;
        // Creating the number field
        private int _num;

        /// <summary>
        /// Gets the current number of the dice
        /// </summary>
        public int Num
        {
            get { return _num; }
            private set { _num = value; }
        }

        /// <summary>
        /// Constructer which will initize random and set the number field
        /// </summary>
        public Die()
        {
            // initizling the random 
            rand = new Random();
            // Gives the propertie a starting value
            Roll();
        }

        /// <summary>
        /// Gets a value 1 to 6 
        /// </summary>
        /// <returns>A value from 1 to 6</returns>
        public int Roll()
        {
            // Asaigns a random number between 1 and 6
            int num = rand.Next(1,7);
            // Keeps the propertie updated
            Num = num;
            return num;
        }
    }
}