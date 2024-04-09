using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324
{
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
}
