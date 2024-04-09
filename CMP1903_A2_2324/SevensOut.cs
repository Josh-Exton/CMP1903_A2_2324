using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324
{
    internal class SevensOut : Game
    {

        public SevensOut()
        {
            Play();
        }

        private void Play()
        {
            bool done = false;
            int total = 0;
            while (!done)
            {
                int sum = 0;
                if (sum == 7)
                {
                    done = true;
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