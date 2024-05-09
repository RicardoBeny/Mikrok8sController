﻿namespace AppLTI
{
    partial class loginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginForm));
            this.btnRouterIP = new System.Windows.Forms.Button();
            this.textBoxRouterIP = new System.Windows.Forms.TextBox();
            this.pictureUsername = new System.Windows.Forms.PictureBox();
            this.picturePassword = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.comboBoxRoutersIP = new System.Windows.Forms.ComboBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.checkBoxGuardarCredencias = new System.Windows.Forms.CheckBox();
            this.buttonSeePassword = new System.Windows.Forms.Button();
            this.buttonHidePassword = new System.Windows.Forms.Button();
            this.btnPorto = new System.Windows.Forms.Button();
            this.textBoxPortoSSH = new System.Windows.Forms.TextBox();
            this.textBoxPortoAPI = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRouterIP
            // 
            this.btnRouterIP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRouterIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRouterIP.Enabled = false;
            this.btnRouterIP.Font = new System.Drawing.Font("Impact", 16.8F);
            this.btnRouterIP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnRouterIP.Location = new System.Drawing.Point(685, 185);
            this.btnRouterIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRouterIP.Name = "btnRouterIP";
            this.btnRouterIP.Size = new System.Drawing.Size(171, 47);
            this.btnRouterIP.TabIndex = 3;
            this.btnRouterIP.Text = "Server IP";
            this.btnRouterIP.UseVisualStyleBackColor = false;
            // 
            // textBoxRouterIP
            // 
            this.textBoxRouterIP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRouterIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxRouterIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRouterIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRouterIP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBoxRouterIP.Location = new System.Drawing.Point(613, 249);
            this.textBoxRouterIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxRouterIP.Name = "textBoxRouterIP";
            this.textBoxRouterIP.Size = new System.Drawing.Size(314, 27);
            this.textBoxRouterIP.TabIndex = 5;
            this.textBoxRouterIP.Text = "127.0.0.1";
            this.textBoxRouterIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureUsername
            // 
            this.pictureUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureUsername.Image = ((System.Drawing.Image)(resources.GetObject("pictureUsername.Image")));
            this.pictureUsername.Location = new System.Drawing.Point(757, 462);
            this.pictureUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureUsername.Name = "pictureUsername";
            this.pictureUsername.Size = new System.Drawing.Size(52, 50);
            this.pictureUsername.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureUsername.TabIndex = 6;
            this.pictureUsername.TabStop = false;
            // 
            // picturePassword
            // 
            this.picturePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picturePassword.Image = ((System.Drawing.Image)(resources.GetObject("picturePassword.Image")));
            this.picturePassword.Location = new System.Drawing.Point(757, 567);
            this.picturePassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picturePassword.Name = "picturePassword";
            this.picturePassword.Size = new System.Drawing.Size(52, 50);
            this.picturePassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturePassword.TabIndex = 8;
            this.picturePassword.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-9, -37);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1561, 894);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBoxUsername.Location = new System.Drawing.Point(629, 517);
            this.textBoxUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(314, 27);
            this.textBoxUsername.TabIndex = 10;
            this.textBoxUsername.Text = "k3s";
            this.textBoxUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBoxPassword.Location = new System.Drawing.Point(644, 623);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '•';
            this.textBoxPassword.Size = new System.Drawing.Size(279, 27);
            this.textBoxPassword.TabIndex = 11;
            this.textBoxPassword.Text = "123";
            this.textBoxPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLogin.Font = new System.Drawing.Font("Impact", 18.8F);
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnLogin.Location = new System.Drawing.Point(677, 718);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(215, 50);
            this.btnLogin.TabIndex = 12;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // comboBoxRoutersIP
            // 
            this.comboBoxRoutersIP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxRoutersIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxRoutersIP.FormattingEnabled = true;
            this.comboBoxRoutersIP.Location = new System.Drawing.Point(669, 414);
            this.comboBoxRoutersIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxRoutersIP.Name = "comboBoxRoutersIP";
            this.comboBoxRoutersIP.Size = new System.Drawing.Size(223, 28);
            this.comboBoxRoutersIP.TabIndex = 13;
            this.comboBoxRoutersIP.Text = "Credenciais Recentes";
            this.comboBoxRoutersIP.SelectedIndexChanged += new System.EventHandler(this.comboBoxRoutersIP_SelectedIndexChanged);
            // 
            // checkBoxGuardarCredencias
            // 
            this.checkBoxGuardarCredencias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxGuardarCredencias.AutoSize = true;
            this.checkBoxGuardarCredencias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.checkBoxGuardarCredencias.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxGuardarCredencias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.checkBoxGuardarCredencias.Location = new System.Drawing.Point(685, 673);
            this.checkBoxGuardarCredencias.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxGuardarCredencias.Name = "checkBoxGuardarCredencias";
            this.checkBoxGuardarCredencias.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxGuardarCredencias.Size = new System.Drawing.Size(200, 29);
            this.checkBoxGuardarCredencias.TabIndex = 14;
            this.checkBoxGuardarCredencias.Text = "Guardar Credenciais";
            this.checkBoxGuardarCredencias.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxGuardarCredencias.UseVisualStyleBackColor = false;
            // 
            // buttonSeePassword
            // 
            this.buttonSeePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSeePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonSeePassword.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSeePassword.BackgroundImage")));
            this.buttonSeePassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSeePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSeePassword.ForeColor = System.Drawing.Color.White;
            this.buttonSeePassword.Location = new System.Drawing.Point(929, 623);
            this.buttonSeePassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSeePassword.Name = "buttonSeePassword";
            this.buttonSeePassword.Size = new System.Drawing.Size(28, 27);
            this.buttonSeePassword.TabIndex = 17;
            this.buttonSeePassword.UseVisualStyleBackColor = false;
            this.buttonSeePassword.Click += new System.EventHandler(this.buttonSeePassword_Click);
            // 
            // buttonHidePassword
            // 
            this.buttonHidePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonHidePassword.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonHidePassword.BackgroundImage")));
            this.buttonHidePassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonHidePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHidePassword.ForeColor = System.Drawing.Color.White;
            this.buttonHidePassword.Location = new System.Drawing.Point(915, 623);
            this.buttonHidePassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonHidePassword.Name = "buttonHidePassword";
            this.buttonHidePassword.Size = new System.Drawing.Size(28, 27);
            this.buttonHidePassword.TabIndex = 18;
            this.buttonHidePassword.UseVisualStyleBackColor = false;
            this.buttonHidePassword.Click += new System.EventHandler(this.buttonHidePassword_Click);
            // 
            // btnPorto
            // 
            this.btnPorto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPorto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPorto.Enabled = false;
            this.btnPorto.Font = new System.Drawing.Font("Impact", 16.8F);
            this.btnPorto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnPorto.Location = new System.Drawing.Point(531, 295);
            this.btnPorto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPorto.Name = "btnPorto";
            this.btnPorto.Size = new System.Drawing.Size(171, 47);
            this.btnPorto.TabIndex = 19;
            this.btnPorto.Text = "Porto SSH";
            this.btnPorto.UseVisualStyleBackColor = false;
            // 
            // textBoxPortoSSH
            // 
            this.textBoxPortoSSH.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPortoSSH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxPortoSSH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPortoSSH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPortoSSH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBoxPortoSSH.Location = new System.Drawing.Point(457, 363);
            this.textBoxPortoSSH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPortoSSH.Name = "textBoxPortoSSH";
            this.textBoxPortoSSH.Size = new System.Drawing.Size(314, 27);
            this.textBoxPortoSSH.TabIndex = 20;
            this.textBoxPortoSSH.Text = "1022";
            this.textBoxPortoSSH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPortoAPI
            // 
            this.textBoxPortoAPI.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPortoAPI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxPortoAPI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPortoAPI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPortoAPI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBoxPortoAPI.Location = new System.Drawing.Point(800, 363);
            this.textBoxPortoAPI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPortoAPI.Name = "textBoxPortoAPI";
            this.textBoxPortoAPI.Size = new System.Drawing.Size(314, 27);
            this.textBoxPortoAPI.TabIndex = 22;
            this.textBoxPortoAPI.Text = "6443";
            this.textBoxPortoAPI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Impact", 16.8F);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.button1.Location = new System.Drawing.Point(800, 295);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(264, 47);
            this.button1.TabIndex = 21;
            this.button1.Text = "Porto  API";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1540, 846);
            this.Controls.Add(this.textBoxPortoAPI);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxPortoSSH);
            this.Controls.Add(this.btnPorto);
            this.Controls.Add(this.buttonSeePassword);
            this.Controls.Add(this.checkBoxGuardarCredencias);
            this.Controls.Add(this.comboBoxRoutersIP);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.picturePassword);
            this.Controls.Add(this.pictureUsername);
            this.Controls.Add(this.textBoxRouterIP);
            this.Controls.Add(this.btnRouterIP);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.buttonHidePassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "loginForm";
            this.Text = "SDNController - MikroTik";
            ((System.ComponentModel.ISupportInitialize)(this.pictureUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRouterIP;
        private System.Windows.Forms.TextBox textBoxRouterIP;
        private System.Windows.Forms.PictureBox pictureUsername;
        private System.Windows.Forms.PictureBox picturePassword;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.ComboBox comboBoxRoutersIP;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.CheckBox checkBoxGuardarCredencias;
        private System.Windows.Forms.Button buttonSeePassword;
        private System.Windows.Forms.Button buttonHidePassword;
        private System.Windows.Forms.Button btnPorto;
        private System.Windows.Forms.TextBox textBoxPortoSSH;
        private System.Windows.Forms.TextBox textBoxPortoAPI;
        private System.Windows.Forms.Button button1;
    }
}

