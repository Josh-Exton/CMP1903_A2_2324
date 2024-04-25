﻿using System;

namespace CMP1903_A2_2324
{
    internal class Die
    {
        // Creating the random field
        private static Random rand;
        // Creating the number field
        private int _num;

        /// <summary>
        /// The number properity which will be between 1 and 6
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
            rand = new Random();
            //initizling the random 
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
            // Keeps the propity updated
            Num = num;
            // returns the number
            return num;
        }
    }
}