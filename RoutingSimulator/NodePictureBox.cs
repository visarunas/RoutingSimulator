using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoutingSimulator
{
    public class NodePictureBox : PictureBox
    {
        public Node node;


        public NodePictureBox(Node node, Point location)
        {
            this.node = node;
            this.Location = location;
            this.Image = Image.FromFile(Properties.Resources.NodeImage);

        }



    }
}
    
