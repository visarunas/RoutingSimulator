namespace RoutingSimulator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelGraphics = new System.Windows.Forms.Panel();
            this.panelContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGraphics
            // 
            this.panelGraphics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGraphics.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelGraphics.Location = new System.Drawing.Point(12, 199);
            this.panelGraphics.Name = "panelGraphics";
            this.panelGraphics.Size = new System.Drawing.Size(1073, 443);
            this.panelGraphics.TabIndex = 0;
            this.panelGraphics.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelGraphics_MouseDown);
            // 
            // panelContextMenuStrip
            // 
            this.panelContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNodeToolStripMenuItem,
            this.removeNodeToolStripMenuItem});
            this.panelContextMenuStrip.Name = "panelContextMenuStrip";
            this.panelContextMenuStrip.Size = new System.Drawing.Size(150, 48);
            this.panelContextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.panelContextMenuStrip_ItemClicked);
            // 
            // addNodeToolStripMenuItem
            // 
            this.addNodeToolStripMenuItem.Name = "addNodeToolStripMenuItem";
            this.addNodeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.addNodeToolStripMenuItem.Text = "Add Node";
            // 
            // removeNodeToolStripMenuItem
            // 
            this.removeNodeToolStripMenuItem.Name = "removeNodeToolStripMenuItem";
            this.removeNodeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.removeNodeToolStripMenuItem.Text = "Remove Node";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 654);
            this.Controls.Add(this.panelGraphics);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.panelContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGraphics;
        private System.Windows.Forms.ContextMenuStrip panelContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeNodeToolStripMenuItem;
    }
}

