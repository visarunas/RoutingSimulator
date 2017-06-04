using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutingSimulator
{
    public class Packet
    {
        public int data;

        public Packet()
        {
            Random r = new Random();
            data = r.Next();
        }
    }
}
