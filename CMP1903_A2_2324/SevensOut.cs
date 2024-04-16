using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324
{
    internal class SevensOut : Game, IPlayable
    {
        public SevensOut()
        {
            Play();
        }

        public void Play()
        {
            List<Die> rolls = DiceList(2);
            bool done = false;
            int num1;
            int num2;
            int sum;
            int total = 0;
            while (!done)
            {
                Console.WriteLine();

                num1 = rolls[0].Roll();
                num2 = rolls[1].Roll();
                sum = num1 + num2;

                Console.WriteLine($"Rolled number 1 is {num1}");
                Console.WriteLine($"Rolled number 2 is {num2}");
                Console.WriteLine($"The sum is {sum}");

                if (sum == 7)
                {
                    break;
                }
                else if (num1 == num2)
                {
                    total = total + (sum * 2);
                }

                else
                {
                    total = total + sum;
                }
                Console.WriteLine($"The total is {total}");
            }
            Console.WriteLine();
            Console.WriteLine($"The final total is {total}");
        }
    }
}