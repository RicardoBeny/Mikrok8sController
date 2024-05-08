namespace AppLTI
{
    partial class namespacesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(namespacesForm));
            this.buttonListarNamespaces = new System.Windows.Forms.Button();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureUsername = new System.Windows.Forms.PictureBox();
            this.PoolLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listBoxNamespaces = new System.Windows.Forms.ListBox();
            this.textBoxNomeAdd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCreateNamespace = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonListarNamespaces
            // 
            this.buttonListarNamespaces.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonListarNamespaces.Location = new System.Drawing.Point(306, 103);
            this.buttonListarNamespaces.Name = "buttonListarNamespaces";
            this.buttonListarNamespaces.Size = new System.Drawing.Size(240, 32);
            this.buttonListarNamespaces.TabIndex = 190;
            this.buttonListarNamespaces.Text = "Listar namespaces";
            this.buttonListarNamespaces.UseVisualStyleBackColor = true;
            this.buttonListarNamespaces.Click += new System.EventHandler(this.buttonListarNamespaces_Click);
            // 
            // textBoxIP
            // 
            this.textBoxIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxIP.Enabled = false;
            this.textBoxIP.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBoxIP.Location = new System.Drawing.Point(1041, 22);
            this.textBoxIP.Multiline = true;
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(154, 22);
            this.textBoxIP.TabIndex = 189;
            this.textBoxIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(37, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 188;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureUsername
            // 
            this.pictureUsername.Image = ((System.Drawing.Image)(resources.GetObject("pictureUsername.Image")));
            this.pictureUsername.Location = new System.Drawing.Point(1200, 11);
            this.pictureUsername.Margin = new System.Windows.Forms.Padding(2);
            this.pictureUsername.Name = "pictureUsername";
            this.pictureUsername.Size = new System.Drawing.Size(39, 41);
            this.pictureUsername.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureUsername.TabIndex = 187;
            this.pictureUsername.TabStop = false;
            // 
            // PoolLabel
            // 
            this.PoolLabel.AutoSize = true;
            this.PoolLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PoolLabel.Font = new System.Drawing.Font("Impact", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PoolLabel.ForeColor = System.Drawing.Color.White;
            this.PoolLabel.Location = new System.Drawing.Point(524, 22);
            this.PoolLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PoolLabel.Name = "PoolLabel";
            this.PoolLabel.Size = new System.Drawing.Size(214, 43);
            this.PoolLabel.TabIndex = 186;
            this.PoolLabel.Text = "Namespaces";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-7, -30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1266, 768);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 185;
            this.pictureBox1.TabStop = false;
            // 
            // listBoxNamespaces
            // 
            this.listBoxNamespaces.FormattingEnabled = true;
            this.listBoxNamespaces.Location = new System.Drawing.Point(48, 141);
            this.listBoxNamespaces.Name = "listBoxNamespaces";
            this.listBoxNamespaces.Size = new System.Drawing.Size(788, 342);
            this.listBoxNamespaces.TabIndex = 191;
            // 
            // textBoxNomeAdd
            // 
            this.textBoxNomeAdd.Location = new System.Drawing.Point(109, 584);
            this.textBoxNomeAdd.Name = "textBoxNomeAdd";
            this.textBoxNomeAdd.Size = new System.Drawing.Size(334, 20);
            this.textBoxNomeAdd.TabIndex = 192;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(44, 581);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 23);
            this.label1.TabIndex = 193;
            this.label1.Text = "Nome:";
            // 
            // buttonCreateNamespace
            // 
            this.buttonCreateNamespace.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreateNamespace.Location = new System.Drawing.Point(147, 530);
            this.buttonCreateNamespace.Name = "buttonCreateNamespace";
            this.buttonCreateNamespace.Size = new System.Drawing.Size(240, 32);
            this.buttonCreateNamespace.TabIndex = 194;
            this.buttonCreateNamespace.Text = "Criar Namespace";
            this.buttonCreateNamespace.UseVisualStyleBackColor = true;
            this.buttonCreateNamespace.Click += new System.EventHandler(this.buttonCreateNamespace_Click);
            // 
            // namespacesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 729);
            this.Controls.Add(this.buttonCreateNamespace);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNomeAdd);
            this.Controls.Add(this.listBoxNamespaces);
            this.Controls.Add(this.buttonListarNamespaces);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureUsername);
            this.Controls.Add(this.PoolLabel);
            this.Controls.Add(this.pictureBox1);
            this.Name = "namespacesForm";
            this.Text = "namespacesForm";
            this.Load += new System.EventHandler(this.namespacesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonListarNamespaces;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureUsername;
        private System.Windows.Forms.Label PoolLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBoxNamespaces;
        private System.Windows.Forms.TextBox textBoxNomeAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCreateNamespace;
    }
}