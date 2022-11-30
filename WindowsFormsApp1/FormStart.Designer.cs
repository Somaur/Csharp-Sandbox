namespace WindowsFormsApp1
{
    partial class FormStart
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelBeServer = new System.Windows.Forms.Label();
            this.labelBeClient = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.labelBeServer, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelBeClient, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(582, 293);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelBeServer
            // 
            this.labelBeServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBeServer.Location = new System.Drawing.Point(295, 3);
            this.labelBeServer.Name = "labelBeServer";
            this.labelBeServer.Size = new System.Drawing.Size(281, 287);
            this.labelBeServer.TabIndex = 1;
            this.labelBeServer.Text = "等待对方连接";
            this.labelBeServer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelBeServer.Click += new System.EventHandler(this.labelBeServer_Click);
            // 
            // labelBeClient
            // 
            this.labelBeClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBeClient.Location = new System.Drawing.Point(6, 3);
            this.labelBeClient.Name = "labelBeClient";
            this.labelBeClient.Size = new System.Drawing.Size(280, 287);
            this.labelBeClient.TabIndex = 0;
            this.labelBeClient.Text = "连接到对方";
            this.labelBeClient.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelBeClient.Click += new System.EventHandler(this.labelBeClient_Click);
            // 
            // FormStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 293);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormStart";
            this.Text = "炸飞机大战";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelBeServer;
        private System.Windows.Forms.Label labelBeClient;
    }
}