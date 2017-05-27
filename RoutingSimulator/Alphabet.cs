using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutingSimulator
{
    class Alphabet
    {
        char letter = 'Z';

        public string GetNextLetter()
        {

            if (letter == 'Z')
                letter = 'A';

            else
                letter = (char)(((int)letter) + 1);

            return letter.ToString();
        }
    }
}
