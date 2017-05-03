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
        GraphicsController graphicsController;

        

        public MainForm()
        {
            InitializeComponent();

            this.graphicsController = new GraphicsController(panelGraphics);

        }

        private void panelGraphics_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                graphicsController.AddNode(new Node("A"), e.Location);
                
            }

        }



    }
}
