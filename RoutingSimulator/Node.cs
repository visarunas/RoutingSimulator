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
        public Node(string name, PictureBox pb)
        {
            this.Name = name;
            this.Pb = pb;
        }

        public int Id { get; set; }
        public int Weight { get; set; }
        public List<Node> ConnectedNodes { get; set; }

        public string Name { get; set; }

        public PictureBox Pb { get; set; }

    }
}
