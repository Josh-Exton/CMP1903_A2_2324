using System;

namespace CMP1903_A2_2324
{
    internal class Die
    {
        // Creating the random field
        private static readonly Random rand = new Random();
        // Creating the number field
        private int _num;

        /// <summary>
        /// The number properity which will be between 1 and 6
        /// </summary>
        public int Num
        {
            get { return _num; }
            set { _num = value; }
        }

        /// <summary>
        /// Constructer which will initize random and set the number field
        /// </summary>
        public Die()
        {
            // initizling the random 
            _num = Roll();
        }

        /// <summary>
        /// Gets a value 1 to 6 
        /// </summary>
        /// <returns>A value from 1 to 6</returns>
        public int Roll()
        {
            // Asaigns a random number between 1 and 6
            int num = rand.Next(1,7);
                        // Making sure it is between 1 and 6
            while (num < 1 || num > 7)
            {
                num = rand.Next(1, 7);
            }
            return num;
        }
    }
}
