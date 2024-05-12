namespace AppLTI
{
    partial class mainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainPage));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureUsername = new System.Windows.Forms.PictureBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.btnTerminal = new System.Windows.Forms.Button();
            this.buttonNodes = new System.Windows.Forms.Button();
            this.buttonNameSpaces = new System.Windows.Forms.Button();
            this.buttonPods = new System.Windows.Forms.Button();
            this.buttonDeployments = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUsername)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-9, -30);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1266, 768);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(512, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 43);
            this.label1.TabIndex = 1;
            this.label1.Text = "Página Principal";
            // 
            // pictureUsername
            // 
            this.pictureUsername.Image = ((System.Drawing.Image)(resources.GetObject("pictureUsername.Image")));
            this.pictureUsername.Location = new System.Drawing.Point(1200, 11);
            this.pictureUsername.Margin = new System.Windows.Forms.Padding(2);
            this.pictureUsername.Name = "pictureUsername";
            this.pictureUsername.Size = new System.Drawing.Size(39, 41);
            this.pictureUsername.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureUsername.TabIndex = 131;
            this.pictureUsername.TabStop = false;
            // 
            // textBoxIP
            // 
            this.textBoxIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxIP.Enabled = false;
            this.textBoxIP.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBoxIP.Location = new System.Drawing.Point(786, 21);
            this.textBoxIP.Multiline = true;
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(409, 22);
            this.textBoxIP.TabIndex = 129;
            this.textBoxIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnTerminal
            // 
            this.btnTerminal.Font = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerminal.Location = new System.Drawing.Point(11, 687);
            this.btnTerminal.Margin = new System.Windows.Forms.Padding(2);
            this.btnTerminal.Name = "btnTerminal";
            this.btnTerminal.Size = new System.Drawing.Size(193, 31);
            this.btnTerminal.TabIndex = 132;
            this.btnTerminal.Text = "Terminal";
            this.btnTerminal.UseVisualStyleBackColor = true;
            this.btnTerminal.Click += new System.EventHandler(this.btnTerminal_Click);
            // 
            // buttonNodes
            // 
            this.buttonNodes.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNodes.Location = new System.Drawing.Point(12, 652);
            this.buttonNodes.Name = "buttonNodes";
            this.buttonNodes.Size = new System.Drawing.Size(192, 30);
            this.buttonNodes.TabIndex = 133;
            this.buttonNodes.Text = "Nodes";
            this.buttonNodes.UseVisualStyleBackColor = true;
            this.buttonNodes.Click += new System.EventHandler(this.buttonNodes_Click);
            // 
            // buttonNameSpaces
            // 
            this.buttonNameSpaces.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNameSpaces.Location = new System.Drawing.Point(12, 616);
            this.buttonNameSpaces.Name = "buttonNameSpaces";
            this.buttonNameSpaces.Size = new System.Drawing.Size(192, 30);
            this.buttonNameSpaces.TabIndex = 134;
            this.buttonNameSpaces.Text = "Namespaces";
            this.buttonNameSpaces.UseVisualStyleBackColor = true;
            this.buttonNameSpaces.Click += new System.EventHandler(this.buttonNameSpaces_Click);
            // 
            // buttonPods
            // 
            this.buttonPods.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPods.Location = new System.Drawing.Point(12, 580);
            this.buttonPods.Name = "buttonPods";
            this.buttonPods.Size = new System.Drawing.Size(192, 30);
            this.buttonPods.TabIndex = 135;
            this.buttonPods.Text = "Pods";
            this.buttonPods.UseVisualStyleBackColor = true;
            this.buttonPods.Click += new System.EventHandler(this.buttonPods_Click);
            // 
            // buttonDeployments
            // 
            this.buttonDeployments.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeployments.Location = new System.Drawing.Point(12, 544);
            this.buttonDeployments.Name = "buttonDeployments";
            this.buttonDeployments.Size = new System.Drawing.Size(192, 30);
            this.buttonDeployments.TabIndex = 136;
            this.buttonDeployments.Text = "Deployments";
            this.buttonDeployments.UseVisualStyleBackColor = true;
            this.buttonDeployments.Click += new System.EventHandler(this.buttonDeployments_Click);
            // 
            // mainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1250, 729);
            this.Controls.Add(this.buttonDeployments);
            this.Controls.Add(this.buttonPods);
            this.Controls.Add(this.buttonNameSpaces);
            this.Controls.Add(this.buttonNodes);
            this.Controls.Add(this.btnTerminal);
            this.Controls.Add(this.pictureUsername);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "mainPage";
            this.Text = "Main Page";
            this.Load += new System.EventHandler(this.mainPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUsername)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureUsername;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Button btnTerminal;
        private System.Windows.Forms.Button buttonNodes;
        private System.Windows.Forms.Button buttonNameSpaces;
        private System.Windows.Forms.Button buttonPods;
        private System.Windows.Forms.Button buttonDeployments;
    }
}