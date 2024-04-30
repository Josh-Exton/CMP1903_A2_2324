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
            // Getting the value from the property
            int roll = dice.Num;
            // Cehcking if it is between 1 and 6
            Debug.Assert(roll > 0 && roll < 7);
        }

        public void SevensOutCheck() 
        { 

        }

        public void ThreeOrMoreCheck() 
        { 
        
        }
    }
}
