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
        Game game = new Game();

        // Checks the roll methods in the die class to see if returns a number between 1 and 6
        public void DieCheck()
        { 
            // Getting the value from the property
            int roll = dice.Num;
            // Cehcking if it is between 1 and 6
            Debug.Assert(roll > 0 && roll < 7);
        }

        /// <summary>
        /// Checks the play method to see if it adds the values correctly
        /// </summary>
        public void GameCheck()
        {
            // The game plays again so I added this so it wasn't confusing for the user when it does
            Console.WriteLine("Testing");
            // Getting what the total should be
            int suspectedTotal = game.Play();
            // Getting the indivual rolls by the property
            int num1 = game.RolledNumber1;
            int num2 = game.RolledNumber2;
            int num3 = game.RolledNumber3;
            // Calculating the total
            int total = num1 + num2 + num3;
            // Checking if total is in range
            Debug.Assert(total > 2 && total < 19);
            // Comparing the total to the suspected total
            Debug.Assert(suspectedTotal == total);
        }
    }
}
