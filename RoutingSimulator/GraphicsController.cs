using System;
using System.Drawing;
using System.Windows.Forms;

namespace RoutingSimulator
{
    public class GraphicsController
    {
        const int nodeSize = 64;

        private Control panelGraphics;

        private bool moving;
        private Point startLocation;

        public GraphicsController(Control panelGraphics)
        {
            this.panelGraphics = panelGraphics;
        }

        public void AddNodeGraphics(Node node, Point location)
        {

            NodePictureBox pb = new NodePictureBox(node, new Point(location.X - nodeSize / 2, location.Y - nodeSize / 2));
            pb.SizeMode = PictureBoxSizeMode.AutoSize;
            panelGraphics.Controls.Add(pb);

            pb.MouseDown += new MouseEventHandler(NodePictureBox_MouseDown);
            pb.MouseUp += new MouseEventHandler(NodePictureBox_MouseUp);
            pb.MouseMove += new MouseEventHandler(NodePictureBox_MouseMove);

            panelGraphics_Paint(this, null);

        }



        private void NodePictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                moving = true;
            }
            if (e.Button == MouseButtons.Right)
            {

            }
        }

        private void NodePictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;

        }

        internal void RemoveNodeGraphics(Point point)
        {
            throw new NotImplementedException();
        }

        private void NodePictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (moving)
            {
                pb.Left += e.Location.X - startLocation.X - nodeSize / 2;
                pb.Top += e.Location.Y - startLocation.Y - nodeSize / 2;

                panelGraphics_Paint(this, null);
            }
        }


        private void panelGraphics_Paint(object sender, PaintEventArgs e)
        {
            panelGraphics.Refresh();
        }
    }
}