namespace WindowsFormsApp1
{
    partial class FormListenRobot
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
            this.buttonStartListen = new System.Windows.Forms.Button();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonStartListen
            // 
            this.buttonStartListen.Location = new System.Drawing.Point(129, 121);
            this.buttonStartListen.Name = "buttonStartListen";
            this.buttonStartListen.Size = new System.Drawing.Size(127, 28);
            this.buttonStartListen.TabIndex = 5;
            this.buttonStartListen.Text = "开始等待接入";
            this.buttonStartListen.UseVisualStyleBackColor = true;
            this.buttonStartListen.Click += new System.EventHandler(this.buttonStartListen_Click);
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(116, 63);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(154, 25);
            this.textBoxPort.TabIndex = 4;
            this.textBoxPort.Text = "12122";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "请输入要使用的端口：";
            // 
            // FormListenRobot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 183);
            this.Controls.Add(this.buttonStartListen);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.label1);
            this.Name = "FormListenRobot";
            this.Text = "等待AI程序接入";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartListen;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label label1;
    }
}