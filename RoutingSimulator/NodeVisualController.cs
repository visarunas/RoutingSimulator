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
        private List<VisualEdge<NodePictureBox>> edgeList = new List<VisualEdge<NodePictureBox>>();
        private NodeController nodeController = new NodeController();

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

            panelGraphics.Refresh();

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
            edgeList.Add(new VisualEdge<NodePictureBox>(node1, node2));

            nodeController.LinkNodes(node1.node, node2.node);


            panelGraphics.Invalidate();
        }

        private void NodePictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;

        }

        public Node RemoveNodeGraphics(Point point)
        {
            point.X -= nodeSize / 2;
            point.Y -= nodeSize / 2;

            foreach (NodePictureBox control in panelGraphics.Controls)
            {
                if (control.Bounds.Contains(point))
                {
                    for(int i = 0; i < edgeList.Count; i++)
                    {
                        if (edgeList[i].End == control || edgeList[i].Start == control)
                        {
                            edgeList.RemoveAt(i);
                            i--;
                        }
                    }
                    var removedNode = control.node;

                    panelGraphics.Controls.Remove(control);
                    panelGraphics.Refresh();

                    return removedNode;
                }
          
            }
            throw new Exception();
            
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
                for (int i = 0; i < edgeList.Count; i++)
                {

                    e.Graphics.DrawLine(pen, 
                        edgeList[i].Start.Location.X + nodeSize / 2,
                        edgeList[i].Start.Location.Y + nodeSize / 2,
                        edgeList[i].End.Location.X + nodeSize / 2,
                        edgeList[i].End.Location.Y + nodeSize / 2);
                }
                
            }

            
        }

        
    }
}