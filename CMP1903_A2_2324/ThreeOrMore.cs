using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324
{
    internal class ThreeOrMore : Game, IPlayable
    {
        public ThreeOrMore() 
        {
            Play();
        }
        public void Play()
        {
            List<object> rolls = DiceList(5);
            int total = 0;
            while (total < 20)
            {
                total++;
            }
        }
    }
}
