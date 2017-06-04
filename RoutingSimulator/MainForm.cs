using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoutingSimulator
{
    public partial class MainForm : Form
    {
        
        NodeVisualController graphicsController;
        NodeController nodeController;

        private Alphabet alphabet = new Alphabet();


        public MainForm()
        {
            InitializeComponent();
            panelGraphics.ContextMenuStrip = panelContextMenuStrip;
            

            this.graphicsController = new NodeVisualController(this, panelGraphics);
            nodeController = new NodeController(graphicsController);


        }

        private void panelGraphics_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                
            }
            else if (e.Button == MouseButtons.Left)
            {

            }

        }

        private void panelContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            if (e.ClickedItem.Text == "Add Node")
            {
                var node = nodeController.AddNewNode();

                comboBoxSender.Items.Add(node.Name);
                checkedListBoxReceiver.Items.Add(node.Name);

                graphicsController.AddNodeGraphics(node, panelGraphics.PointToClient(MousePosition));
            }
            if (e.ClickedItem.Text == "Remove Node")
            {
                try
                {
                    var node = graphicsController.RemoveNodeGraphics(panelGraphics.PointToClient(MousePosition));

                    checkedListBoxReceiver.Items.Remove(node.Name);
                    comboBoxSender.Items.Remove(node.Name);
                    comboBoxSender.SelectedIndex = -1;

                    nodeController.UnlinkNode(node);
                    nodeController.RemoveNode(node);
                }
                catch(Exception)
                {

                }
                
            }

             
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            try
            {
                nodeController.Reset();
                foreach(NodePictureBox pb in panelGraphics.Controls)
                {
                    pb.Image = Image.FromFile(Properties.Resources.NodeImage);
                }

                foreach(var selection in checkedListBoxReceiver.CheckedItems)
                {
                    var receiver = nodeController.nodes.Find(x => x.Name == selection.ToString());
                    receiver.Receiver = true;
                }

                var node = nodeController.nodes.Find(x => x.Name == (string)comboBoxSender.SelectedItem);
                

                nodeController.SendJoinQuery(node);
           


            }
            catch(Exception)
            {

            }

        }

        public void NodePictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            NodePictureBox node = sender as NodePictureBox;

            dataGridViewTable.Rows.Clear();

            foreach(var entry in node.node.routingTable)
            {
                dataGridViewTable.Rows.Add(entry.Destination, entry.NextNode);
            }

        }

        private void buttonStop_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonCheckConnections_Click(object sender, EventArgs e)
        {
            graphicsController.CheckConnection();
        }
    }
}
