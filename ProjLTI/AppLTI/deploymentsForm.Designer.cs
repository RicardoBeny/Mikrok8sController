﻿namespace AppLTI
{
    partial class deploymentsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(deploymentsForm));
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxNamespaces = new System.Windows.Forms.ComboBox();
            this.textBoxPorto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxImage = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxDeployments = new System.Windows.Forms.ComboBox();
            this.buttonDeleteDeployments = new System.Windows.Forms.Button();
            this.buttonCreateDeployments = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNomeAdd = new System.Windows.Forms.TextBox();
            this.listBoxDeployments = new System.Windows.Forms.ListBox();
            this.DeploymentsLabel = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureUsername = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(54, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 23);
            this.label4.TabIndex = 227;
            this.label4.Text = "Namespaces";
            // 
            // comboBoxNamespaces
            // 
            this.comboBoxNamespaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNamespaces.FormattingEnabled = true;
            this.comboBoxNamespaces.Items.AddRange(new object[] {
            "Todos"});
            this.comboBoxNamespaces.Location = new System.Drawing.Point(172, 140);
            this.comboBoxNamespaces.Name = "comboBoxNamespaces";
            this.comboBoxNamespaces.Size = new System.Drawing.Size(295, 21);
            this.comboBoxNamespaces.TabIndex = 226;
            this.comboBoxNamespaces.SelectedIndexChanged += new System.EventHandler(this.comboBoxNamespaces_SelectedIndexChanged);
            // 
            // textBoxPorto
            // 
            this.textBoxPorto.Location = new System.Drawing.Point(122, 630);
            this.textBoxPorto.Name = "textBoxPorto";
            this.textBoxPorto.Size = new System.Drawing.Size(345, 20);
            this.textBoxPorto.TabIndex = 225;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(54, 627);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 23);
            this.label3.TabIndex = 224;
            this.label3.Text = "Porto:";
            // 
            // comboBoxImage
            // 
            this.comboBoxImage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxImage.FormattingEnabled = true;
            this.comboBoxImage.Location = new System.Drawing.Point(144, 601);
            this.comboBoxImage.Name = "comboBoxImage";
            this.comboBoxImage.Size = new System.Drawing.Size(323, 21);
            this.comboBoxImage.TabIndex = 223;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(54, 599);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 23);
            this.label2.TabIndex = 222;
            this.label2.Text = "Imagem:";
            // 
            // comboBoxDeployments
            // 
            this.comboBoxDeployments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDeployments.FormattingEnabled = true;
            this.comboBoxDeployments.Location = new System.Drawing.Point(549, 573);
            this.comboBoxDeployments.Name = "comboBoxDeployments";
            this.comboBoxDeployments.Size = new System.Drawing.Size(334, 21);
            this.comboBoxDeployments.TabIndex = 221;
            // 
            // buttonDeleteDeployments
            // 
            this.buttonDeleteDeployments.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteDeployments.Location = new System.Drawing.Point(595, 522);
            this.buttonDeleteDeployments.Name = "buttonDeleteDeployments";
            this.buttonDeleteDeployments.Size = new System.Drawing.Size(240, 32);
            this.buttonDeleteDeployments.TabIndex = 220;
            this.buttonDeleteDeployments.Text = "Apagar Deployments";
            this.buttonDeleteDeployments.UseVisualStyleBackColor = true;
            this.buttonDeleteDeployments.Click += new System.EventHandler(this.buttonDeleteDeployments_Click);
            // 
            // buttonCreateDeployments
            // 
            this.buttonCreateDeployments.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreateDeployments.Location = new System.Drawing.Point(129, 522);
            this.buttonCreateDeployments.Name = "buttonCreateDeployments";
            this.buttonCreateDeployments.Size = new System.Drawing.Size(240, 32);
            this.buttonCreateDeployments.TabIndex = 219;
            this.buttonCreateDeployments.Text = "Criar Deployments";
            this.buttonCreateDeployments.UseVisualStyleBackColor = true;
            this.buttonCreateDeployments.Click += new System.EventHandler(this.buttonCreateDeployments_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(54, 573);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 23);
            this.label1.TabIndex = 218;
            this.label1.Text = "Nome:";
            // 
            // textBoxNomeAdd
            // 
            this.textBoxNomeAdd.Location = new System.Drawing.Point(122, 576);
            this.textBoxNomeAdd.Name = "textBoxNomeAdd";
            this.textBoxNomeAdd.Size = new System.Drawing.Size(345, 20);
            this.textBoxNomeAdd.TabIndex = 217;
            // 
            // listBoxDeployments
            // 
            this.listBoxDeployments.FormattingEnabled = true;
            this.listBoxDeployments.Location = new System.Drawing.Point(58, 166);
            this.listBoxDeployments.Name = "listBoxDeployments";
            this.listBoxDeployments.Size = new System.Drawing.Size(1127, 342);
            this.listBoxDeployments.TabIndex = 216;
            // 
            // DeploymentsLabel
            // 
            this.DeploymentsLabel.AutoSize = true;
            this.DeploymentsLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DeploymentsLabel.Font = new System.Drawing.Font("Impact", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeploymentsLabel.ForeColor = System.Drawing.Color.White;
            this.DeploymentsLabel.Location = new System.Drawing.Point(529, 47);
            this.DeploymentsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DeploymentsLabel.Name = "DeploymentsLabel";
            this.DeploymentsLabel.Size = new System.Drawing.Size(218, 43);
            this.DeploymentsLabel.TabIndex = 215;
            this.DeploymentsLabel.Text = "Deployments";
            // 
            // textBoxIP
            // 
            this.textBoxIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxIP.Enabled = false;
            this.textBoxIP.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBoxIP.Location = new System.Drawing.Point(735, 22);
            this.textBoxIP.Multiline = true;
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(460, 22);
            this.textBoxIP.TabIndex = 214;
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
            this.pictureBox2.TabIndex = 213;
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
            this.pictureUsername.TabIndex = 212;
            this.pictureUsername.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-7, -30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1266, 768);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 211;
            this.pictureBox1.TabStop = false;
            // 
            // deploymentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 729);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxNamespaces);
            this.Controls.Add(this.textBoxPorto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxImage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxDeployments);
            this.Controls.Add(this.buttonDeleteDeployments);
            this.Controls.Add(this.buttonCreateDeployments);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNomeAdd);
            this.Controls.Add(this.listBoxDeployments);
            this.Controls.Add(this.DeploymentsLabel);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureUsername);
            this.Controls.Add(this.pictureBox1);
            this.Name = "deploymentsForm";
            this.Text = "deploymentsForm";
            this.Load += new System.EventHandler(this.deploymentsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxNamespaces;
        private System.Windows.Forms.TextBox textBoxPorto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxDeployments;
        private System.Windows.Forms.Button buttonDeleteDeployments;
        private System.Windows.Forms.Button buttonCreateDeployments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNomeAdd;
        private System.Windows.Forms.ListBox listBoxDeployments;
        private System.Windows.Forms.Label DeploymentsLabel;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureUsername;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}