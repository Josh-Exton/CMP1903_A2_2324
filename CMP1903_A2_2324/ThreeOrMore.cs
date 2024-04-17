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
            Statistics.ThreeOrMorePlaysUpdate();
            Play();
        }
        public void Play()
        {
            List<Die> rolls = DiceList(5);
            List<int> numList = new List<int>(5);
            int total = 0;
            while (total < 20)
            {
                for (int i = 0; i < rolls.Count; i++) 
                {
                    numList.Insert(i, rolls[i].Roll());
                }
                var duplicates = from n in numList where n > 0 select n;
                break;
            }
        }
    }
}