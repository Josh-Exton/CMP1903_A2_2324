using System;

namespace CMP1903_A2_2324
{
    internal class Program
    {
        /// <summary>
        /// Main loop of the program
        /// </summary>
        static void Main(string[] args)
        {
            // Creating the game object
            Game game = new Game();
            bool done = false;
            while (!done) 
            {
                // Asking the user if they want to play the game once or multiple times
                Console.WriteLine("Type \"once\" if you want to play the game once or \"continuous\" if you want to the game multiple times");
                String continuous = Console.ReadLine();
                // Two methods to help against type errors but doesn't prevent them
                // Gets rid of any white spaces before and after the word
                continuous = continuous.Trim();
                // Makes the word all lowercase
                continuous = continuous.ToLower();
                if (continuous == "once")
                {
                    // Playing the game once
                    game.Play();
                    // Ending the loop
                    done = true;
                }
                else if (continuous == "continuous")
                {
                    // Playing the game multiple times
                    game.PlayContinuous();
                    done = true;
                }
            }

            // Finished the loop and displays the message to say that the game is completed 
            Console.WriteLine("Thanks for Playing");
            // Seperating the games and the testing in the termial
            Console.WriteLine("");
            // Creating the test object
            Testing test = new Testing();
            // Checking the methods in each class
            test.DieCheck();
            test.GameCheck();
            Console.ReadKey();
        }
    }
}
