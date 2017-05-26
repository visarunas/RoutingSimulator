using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;


namespace RoutingSimulator
{
    public class NodeVisualController
    {
        const int nodeSize = 64;

        private Control panelGraphics;

        private bool moving;
        private Point startLocation;

        private NodePictureBox selectedNode1, selectedNode2;
        private List<NodePictureBox> node1List = new List<NodePictureBox>();
        private List<NodePictureBox> node2List = new List<NodePictureBox>();

        public NodeVisualController(Control panelGraphics)
        {
            this.panelGraphics = panelGraphics;
            this.panelGraphics.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGraphics_Paint);
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
            NodePictureBox node = sender as NodePictureBox;

            if (e.Button == MouseButtons.Left)
            {
                moving = true;

                if (NodePictureBox.ModifierKeys.HasFlag(Keys.Control))
                {
                    if (selectedNode1 == null)
                    {
                        selectedNode1 = node;
                    }
                    else if (selectedNode2 == null)
                    {
                        if (selectedNode1 != node)
                        {
                            selectedNode2 = node;

                            LinkNodes(selectedNode1, selectedNode2);
                            selectedNode1 = null;
                            selectedNode2 = null;

                        }
                        
                    }
                    else
                    {
                        selectedNode1 = null;
                        selectedNode2 = null;
                    }
                    
                }
                
            }
            if (e.Button == MouseButtons.Right)
            {

            }
        }

        public void LinkNodes(NodePictureBox node1, NodePictureBox node2)
        {
            node1List.Add(node1);
            node2List.Add(node2);
            panelGraphics.Invalidate();
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

                panelGraphics.Invalidate();
            }
        }


        private void panelGraphics_Paint(object sender, PaintEventArgs e)
        {

            using (var pen = new Pen(Color.Red, 4))
            {
                for (int i = 0; i < node1List.Count; i++)
                {

                    e.Graphics.DrawLine(pen, 
                        node1List[i].Location.X + nodeSize / 2,
                        node1List[i].Location.Y + nodeSize / 2,
                        node2List[i].Location.X + nodeSize / 2,
                        node2List[i].Location.Y + nodeSize / 2);
                }
            }

            
        }

        
    }
}