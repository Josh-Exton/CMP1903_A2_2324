using System;
using System.Collections.Generic;
using System.Linq;

namespace CMP1903_A2_2324
{
    internal class Game
    {
    }

    internal class SevensOut : Game
    {
        Die dice1 = new Die();
        Die dice2 = new Die();
        List<int> rolls = new List<int>();

        public void Play()
        {
            bool done = false;
            int total = 0;
            while (!done)
            {
                int rolledNumber1 = dice1.Roll();
                int rolledNumber2 = dice2.Roll();
                int sum = rolledNumber1 + rolledNumber2;
                if (sum == 7)
                {
                    done = true;
                }
                else if (rolledNumber1 == rolledNumber2) 
                {
                    total = total + (sum * 2);
                }

                else 
                {
                    total = total + sum;
                }
                Console.WriteLine($"Rolled number 1 is {rolledNumber1}");
                Console.WriteLine($"Rolled number 2 is {rolledNumber2}");
                Console.WriteLine($"The sum is {sum}");
                Console.WriteLine($"The total is {total}");
                Console.WriteLine();
            }
            Console.WriteLine($"The final total is {total}");
        }
    }

    internal class ThreeOrMore : Game
    {
        Die dice1 = new Die();
        Die dice2 = new Die();
        Die dice3 = new Die();
        Die dice4 = new Die();
        Die dice5 = new Die();
        List<int> rolls = new List<int>();

        public void Play() 
        {
            bool done = false;
            int total = 0;
            while (total < 20)
            {
                int rolledNumber1 = dice1.Roll();
                int rolledNumber2 = dice2.Roll();
                int rolledNumber3 = dice3.Roll();
                int rolledNumber4 = dice4.Roll();
                int rolledNumber5 = dice5.Roll();
                rolls.Add(rolledNumber1);
                rolls.Add(rolledNumber2);
                rolls.Add(rolledNumber3);
                rolls.Add(rolledNumber4);
                rolls.Add(rolledNumber5);
                IEnumerable<int> output = rolls
                                          .GroupBy(i => i)
                                          .Where(g => g.Count() > 1)
                                          .Select(g => g.Key);
                Console.WriteLine(output);
                total = 20;
            }
        }
    }
}
