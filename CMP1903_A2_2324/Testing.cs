using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CMP1903_A2_2324
{
    /// <summary>
    /// Testing the program
    /// </summary>
    internal class Testing
    {
        /// <summary>
        /// Creating the die and game objects
        /// </summary>
        Die dice = new Die();
        SevensOut sevensOut = new SevensOut();
        ThreeOrMore threeOrMore = new ThreeOrMore();

        /// <summary>
        /// Checks the roll methods in the die class to see if returns a number between 1 and 6
        /// </summary>
        public void DieCheck()
        {
            // Cehcking if it is between 1 and 6 by accessing the property
            Debug.Assert((dice.Num > 0) && (dice.Num < 7));
        }

        public void SevensOutCheck() 
        {
            // Plays the game
            Console.WriteLine("Playing sevens out with the computer");
            sevensOut.Play();
            Console.WriteLine();
            // Cehcking if the sum is 7 by accessing property
            Debug.Assert(sevensOut.Player1Sum == 7);
            Debug.Assert(sevensOut.OtherSum == 7);
        }

        public void ThreeOrMoreCheck() 
        {
            // Plays the game
            Console.WriteLine("Playing three or more with the computer");
            threeOrMore.Play();
            Console.WriteLine();
            // Cehcking if the total is 20 or greater by accessing property
            Debug.Assert((threeOrMore.Player1Total >= 20) || (threeOrMore.OtherTotal >= 20));
        }
    }
}
