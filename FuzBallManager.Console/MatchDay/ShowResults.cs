using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIConsole.MatchDay
{
    public class ShowResults
    {
        int RandomizeTwoInts(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
