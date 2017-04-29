using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutingSimulator
{
    public class Node
    {
        public int Weight { get; set; }
        public IList<Node> ConnectedNodes { get; set; }

        public string Name { get; set; }



    }
}
