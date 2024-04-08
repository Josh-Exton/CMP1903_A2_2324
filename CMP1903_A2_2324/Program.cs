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
            // SevensOut sevensOut = new SevensOut();
            // sevensOut.Play();
            ThreeOrMore threeOrMore = new ThreeOrMore();
            threeOrMore.Play();
            Console.ReadKey();
        }
    }
}
