using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoutingSimulator
{
    public partial class MainForm : Form
    {
        IList<Node> nodes = new List<Node>();

        int size = 64;

        public MainForm()
        {
            InitializeComponent();

            

        }

        private void panelGraphics_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PictureBox pb = new PictureBox();
                pb.Image = Image.FromFile("node.png");
                pb.Location = new Point(e.X - size / 2, e.Y - size / 2);
                panelGraphics.Controls.Add(pb);

                pb.MouseDown += new MouseEventHandler(NodePictureBox_MouseDown);
                pb.MouseUp += new MouseEventHandler(NodePictureBox_MouseUp);
                pb.MouseMove += new MouseEventHandler(NodePictureBox_MouseMove);

                var node = new Node("A", pb);
                nodes.Add(node);

                


                Refresh();

            }

        }

        private bool moving;
        private Point startLocation;

        private void NodePictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                moving = true;
                startLocation = e.Location;
            }
        }

        private void NodePictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
        }

        private void NodePictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (moving)
            {
                pb.Left += e.Location.X - startLocation.X;
                pb.Top += e.Location.Y - startLocation.Y;
            }
        }



    }
}
