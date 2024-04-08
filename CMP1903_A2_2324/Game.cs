using System;

namespace CMP1903_A2_2324
{
    internal class Game
    {
        // Creating the dice objects 
        Die dice1 = new Die();
        Die dice2 = new Die();
        Die dice3 = new Die();

        // initializing the rolled numbers fields so I can make the property
        private int rolledNumber1;
        private int rolledNumber2;
        private int rolledNumber3;

        // Setting them as properties so I can access them in the testing class

        /// <summary>
        /// Properity for storing the 1st rolled value
        /// </summary>
        public int RolledNumber1
        {
            get { return rolledNumber1; }
            set { rolledNumber1 = value; }
        }

        /// <summary>
        /// Properity for storing the 2nd rolled value
        /// </summary>
        public int RolledNumber2
        {
            get { return rolledNumber2; }
            set { rolledNumber2 = value; }
        }

        /// <summary>
        /// Properity for storing the 3rd rolled value
        /// </summary>
        public int RolledNumber3
        {
            get { return rolledNumber3; }
            set { rolledNumber3 = value; }
        }

        /// <summary>
        /// Create 3 dice objects then get the values and add them together
        /// </summary>
        /// <returns>The total of the rolls</returns>
        public int Play()
        {
            // Getting the rolled number by accessing the property
            rolledNumber1 = dice1.Roll();
            Console.WriteLine($"You rolled a {rolledNumber1}");
            rolledNumber2 = dice2.Roll();
            Console.WriteLine($"You rolled a {rolledNumber2}");
            rolledNumber3 = dice3.Roll();
            Console.WriteLine($"You rolled a {rolledNumber3}");
            // Getting the total
            int totalNumber = rolledNumber1 + rolledNumber2 + rolledNumber3;
            Console.WriteLine($"The total of your rolls are {totalNumber}");
            // Returning the total number for the testing class
            return totalNumber;
        }


        /// <summary>
        /// This mehod calls the Play method in a while loop until the user ends it
        /// </summary>
        public void PlayContinuous()
        {
            // Setting a done variable to False so I can end the while loop by setting it to true
            bool done = false;
            while (done == false)
            {
                // Playing the game by calling the method
                Play();
                // adding another while loop
                bool yesOrNo = false;
                while (!yesOrNo)
                {
                    // Asking user to play again
                    Console.WriteLine("Type \"yes\" if you want to play again and \"no\" if you don't");
                    string playAgain = Console.ReadLine();
                    // Two methods to help against type errors but doesn't prevent them
                    // Gets rid of any white spaces before and after the word
                    playAgain = playAgain.Trim();
                    // Makes the word all lowercase
                    playAgain.ToLower();
                    if (playAgain == "yes" || playAgain == "no")
                    {
                        // Ending the second loop
                        yesOrNo = true;
                    }

                    if (playAgain == "no")
                    {
                        // Ending the first loop
                        done = true;
                    }
                }
                // Two methods to help against type errors but doesn't prevent them
                // Seperating the games in the terminal
                Console.WriteLine("");
            }
        }
    }
}
