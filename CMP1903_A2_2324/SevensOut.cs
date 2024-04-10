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
            List<object> rolls = DiceList(2);
            bool done = false;
            int total = 0;
            while (!done)
            {
                int sum = 0;
                foreach (object roll in rolls) 
                { 
                    // sum = sum + roll.get properity or roll
                }
                if (sum == 7)
                {
                    break;
                }
                else if (sum == 2)
                {
                    total = total + (sum * 2);
                }

                else
                {
                    total = total + sum;
                }
                Console.WriteLine($"Rolled number 1 is {sum}");
                Console.WriteLine($"Rolled number 2 is {sum}");
                Console.WriteLine($"The sum is {sum}");
                Console.WriteLine($"The total is {total}");
            }
            Console.WriteLine($"The final total is {total}");
        }
    }
}