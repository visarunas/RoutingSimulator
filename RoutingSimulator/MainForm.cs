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
        NodeVisualController graphicsController;

        

        public MainForm()
        {
            InitializeComponent();
            panelGraphics.ContextMenuStrip = panelContextMenuStrip;

            this.graphicsController = new NodeVisualController(panelGraphics);

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
                graphicsController.AddNodeGraphics(new Node("A"), panelGraphics.PointToClient(MousePosition));
            }
            if (e.ClickedItem.Text == "Remove Node")
            {
                graphicsController.RemoveNodeGraphics(panelGraphics.PointToClient(MousePosition));
            }
        }



    }
}
