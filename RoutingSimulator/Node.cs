using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoutingSimulator
{
    public class Node
    {
        public Node(string name)
        {
            this.Name = name;
        }

        public int Id { get; set; }
        public int Weight { get; set; }
        public List<Node> ConnectedNodes { get; set; } = new List<Node>();

        public string Name { get; set; }

    }
}
