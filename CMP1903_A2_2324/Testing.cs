using System;
using System.Diagnostics;

namespace CMP1903_A2_2324
{
    internal class Testing
    {

        /// <summary>
        /// Creating the die and game objects
        /// </summary>
        Die dice = new Die();
        SevensOut sevensOut = new SevensOut("computer");
        ThreeOrMore threeOrMore = new ThreeOrMore("computer");

        // Checks the roll methods in the die class to see if returns a number between 1 and 6
        public void DieCheck()
        { 
            // Getting the value from the property
            int roll = dice.Num;
            // Cehcking if it is between 1 and 6
            Debug.Assert(roll > 0 && roll < 7);
        }
    }
}
