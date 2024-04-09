using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324
{
    internal class ThreeOrMore : Game
    {
        List<object> dice = new List<object>();

        private void DiceList()
        {
            for (int i = 0; i < 5; i++)
            {
                dice.Add(new Die());
            }
        }

        public void Play()
        {
            int total = 0;
            while (total < 20)
            {
                total = 20;
            }
        }
    }
}
