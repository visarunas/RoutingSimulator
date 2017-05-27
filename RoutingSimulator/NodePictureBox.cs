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

            this.Paint += new PaintEventHandler((sender, e) =>
            {
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                string text = node.Name;

                SizeF textSize = e.Graphics.MeasureString(text, Font);
                PointF locationToDraw = new PointF();
                locationToDraw.X = (this.Width / 2) - (textSize.Width / 2);
                locationToDraw.Y = (this.Height) - (textSize.Height);

                e.Graphics.DrawString(text, Font, Brushes.Black, locationToDraw);
            });

        }



    }
}
    
