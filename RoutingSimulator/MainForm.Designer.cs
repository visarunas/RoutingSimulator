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
            this.checkedListBoxReceiver = new System.Windows.Forms.CheckedListBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.comboBoxSender = new System.Windows.Forms.ComboBox();
            this.dataGridViewTable = new System.Windows.Forms.DataGridView();
            this.Destination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NextNode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTable)).BeginInit();
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
            // checkedListBoxReceiver
            // 
            this.checkedListBoxReceiver.FormattingEnabled = true;
            this.checkedListBoxReceiver.Location = new System.Drawing.Point(333, 49);
            this.checkedListBoxReceiver.Name = "checkedListBoxReceiver";
            this.checkedListBoxReceiver.Size = new System.Drawing.Size(120, 94);
            this.checkedListBoxReceiver.TabIndex = 3;
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(168, 161);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 4;
            this.buttonSend.Text = "Start";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(349, 161);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 5;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // comboBoxSender
            // 
            this.comboBoxSender.FormattingEnabled = true;
            this.comboBoxSender.Location = new System.Drawing.Point(140, 84);
            this.comboBoxSender.Name = "comboBoxSender";
            this.comboBoxSender.Size = new System.Drawing.Size(151, 21);
            this.comboBoxSender.TabIndex = 6;
            // 
            // dataGridViewTable
            // 
            this.dataGridViewTable.AllowUserToAddRows = false;
            this.dataGridViewTable.AllowUserToDeleteRows = false;
            this.dataGridViewTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Destination,
            this.NextNode});
            this.dataGridViewTable.Location = new System.Drawing.Point(592, 12);
            this.dataGridViewTable.Name = "dataGridViewTable";
            this.dataGridViewTable.ReadOnly = true;
            this.dataGridViewTable.Size = new System.Drawing.Size(246, 163);
            this.dataGridViewTable.TabIndex = 7;
            this.dataGridViewTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTable_CellContentClick);
            // 
            // Destination
            // 
            this.Destination.HeaderText = "Destination";
            this.Destination.Name = "Destination";
            this.Destination.ReadOnly = true;
            // 
            // NextNode
            // 
            this.NextNode.HeaderText = "Next Node";
            this.NextNode.Name = "NextNode";
            this.NextNode.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 654);
            this.Controls.Add(this.dataGridViewTable);
            this.Controls.Add(this.comboBoxSender);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.checkedListBoxReceiver);
            this.Controls.Add(this.panelGraphics);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.panelContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGraphics;
        private System.Windows.Forms.ContextMenuStrip panelContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeNodeToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox checkedListBoxReceiver;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.ComboBox comboBoxSender;
        private System.Windows.Forms.DataGridView dataGridViewTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destination;
        private System.Windows.Forms.DataGridViewTextBoxColumn NextNode;
    }
}

