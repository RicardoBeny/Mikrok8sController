namespace AppLTI
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
            this.textBoxRouterIP = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.comboBoxRoutersIP = new System.Windows.Forms.ComboBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.checkBoxGuardarPassword = new System.Windows.Forms.CheckBox();
            this.buttonHidePassword = new System.Windows.Forms.Button();
            this.textBoxPortoSSH = new System.Windows.Forms.TextBox();
            this.textBoxPortoAPI = new System.Windows.Forms.TextBox();
            this.labelIP = new System.Windows.Forms.Label();
            this.labelSSH = new System.Windows.Forms.Label();
            this.labelAPI = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSeePassword = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            this.textBoxRouterIP.Location = new System.Drawing.Point(165, 184);
            this.textBoxRouterIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxRouterIP.Name = "textBoxRouterIP";
            this.textBoxRouterIP.Size = new System.Drawing.Size(322, 27);
            this.textBoxRouterIP.TabIndex = 5;
            this.textBoxRouterIP.Text = "127.0.0.1";
            this.textBoxRouterIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.textBoxUsername.Location = new System.Drawing.Point(521, 319);
            this.textBoxUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(322, 27);
            this.textBoxUsername.TabIndex = 10;
            this.textBoxUsername.Text = "k3smaster";
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
            this.textBoxPassword.Location = new System.Drawing.Point(521, 370);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '•';
            this.textBoxPassword.Size = new System.Drawing.Size(289, 27);
            this.textBoxPassword.TabIndex = 11;
            this.textBoxPassword.Text = "123";
            this.textBoxPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(125)))), ((int)(((byte)(244)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogin.Font = new System.Drawing.Font("Impact", 18.8F);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(563, 488);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(225, 58);
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
            this.comboBoxRoutersIP.Location = new System.Drawing.Point(572, 248);
            this.comboBoxRoutersIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxRoutersIP.Name = "comboBoxRoutersIP";
            this.comboBoxRoutersIP.Size = new System.Drawing.Size(224, 28);
            this.comboBoxRoutersIP.TabIndex = 13;
            this.comboBoxRoutersIP.Text = "Acessos Recentes";
            this.comboBoxRoutersIP.SelectedIndexChanged += new System.EventHandler(this.comboBoxRoutersIP_SelectedIndexChanged);
            // 
            // checkBoxGuardarPassword
            // 
            this.checkBoxGuardarPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxGuardarPassword.AutoSize = true;
            this.checkBoxGuardarPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBoxGuardarPassword.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxGuardarPassword.ForeColor = System.Drawing.Color.White;
            this.checkBoxGuardarPassword.Location = new System.Drawing.Point(584, 432);
            this.checkBoxGuardarPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxGuardarPassword.Name = "checkBoxGuardarPassword";
            this.checkBoxGuardarPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxGuardarPassword.Size = new System.Drawing.Size(181, 29);
            this.checkBoxGuardarPassword.TabIndex = 14;
            this.checkBoxGuardarPassword.Text = "Guardar Password";
            this.checkBoxGuardarPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxGuardarPassword.UseVisualStyleBackColor = false;
            // 
            // buttonHidePassword
            // 
            this.buttonHidePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonHidePassword.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonHidePassword.BackgroundImage")));
            this.buttonHidePassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonHidePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHidePassword.ForeColor = System.Drawing.Color.White;
            this.buttonHidePassword.Location = new System.Drawing.Point(812, 370);
            this.buttonHidePassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonHidePassword.Name = "buttonHidePassword";
            this.buttonHidePassword.Size = new System.Drawing.Size(28, 27);
            this.buttonHidePassword.TabIndex = 18;
            this.buttonHidePassword.UseVisualStyleBackColor = false;
            this.buttonHidePassword.Click += new System.EventHandler(this.buttonHidePassword_Click);
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
            this.textBoxPortoSSH.Location = new System.Drawing.Point(521, 184);
            this.textBoxPortoSSH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPortoSSH.Name = "textBoxPortoSSH";
            this.textBoxPortoSSH.Size = new System.Drawing.Size(322, 27);
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
            this.textBoxPortoAPI.Location = new System.Drawing.Point(889, 184);
            this.textBoxPortoAPI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPortoAPI.Name = "textBoxPortoAPI";
            this.textBoxPortoAPI.Size = new System.Drawing.Size(322, 27);
            this.textBoxPortoAPI.TabIndex = 22;
            this.textBoxPortoAPI.Text = "6443";
            this.textBoxPortoAPI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIP.ForeColor = System.Drawing.Color.White;
            this.labelIP.Location = new System.Drawing.Point(250, 127);
            this.labelIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(146, 29);
            this.labelIP.TabIndex = 23;
            this.labelIP.Text = "IP do servidor";
            // 
            // labelSSH
            // 
            this.labelSSH.AutoSize = true;
            this.labelSSH.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSSH.ForeColor = System.Drawing.Color.White;
            this.labelSSH.Location = new System.Drawing.Point(626, 127);
            this.labelSSH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSSH.Name = "labelSSH";
            this.labelSSH.Size = new System.Drawing.Size(106, 29);
            this.labelSSH.TabIndex = 24;
            this.labelSSH.Text = "Porto SSH";
            // 
            // labelAPI
            // 
            this.labelAPI.AutoSize = true;
            this.labelAPI.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAPI.ForeColor = System.Drawing.Color.White;
            this.labelAPI.Location = new System.Drawing.Point(994, 127);
            this.labelAPI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAPI.Name = "labelAPI";
            this.labelAPI.Size = new System.Drawing.Size(100, 29);
            this.labelAPI.TabIndex = 25;
            this.labelAPI.Text = "Porto API";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
            this.pictureBox2.Location = new System.Drawing.Point(615, 26);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(305, 93);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 31;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.textBoxRouterIP);
            this.panel1.Controls.Add(this.textBoxUsername);
            this.panel1.Controls.Add(this.labelAPI);
            this.panel1.Controls.Add(this.textBoxPassword);
            this.panel1.Controls.Add(this.labelSSH);
            this.panel1.Controls.Add(this.comboBoxRoutersIP);
            this.panel1.Controls.Add(this.labelIP);
            this.panel1.Controls.Add(this.checkBoxGuardarPassword);
            this.panel1.Controls.Add(this.textBoxPortoAPI);
            this.panel1.Controls.Add(this.buttonSeePassword);
            this.panel1.Controls.Add(this.textBoxPortoSSH);
            this.panel1.Controls.Add(this.buttonHidePassword);
            this.panel1.Location = new System.Drawing.Point(90, 148);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(1362, 569);
            this.panel1.TabIndex = 32;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(125)))), ((int)(((byte)(244)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1362, 82);
            this.panel2.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(125)))), ((int)(((byte)(244)))));
            this.label1.Font = new System.Drawing.Font("Impact", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(617, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "LOGIN";
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
            this.buttonSeePassword.Location = new System.Drawing.Point(813, 370);
            this.buttonSeePassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSeePassword.Name = "buttonSeePassword";
            this.buttonSeePassword.Size = new System.Drawing.Size(27, 27);
            this.buttonSeePassword.TabIndex = 17;
            this.buttonSeePassword.UseVisualStyleBackColor = false;
            this.buttonSeePassword.Click += new System.EventHandler(this.buttonSeePassword_Click);
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1540, 846);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "loginForm";
            this.Text = "SDNController - MikroTik";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxRouterIP;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.ComboBox comboBoxRoutersIP;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.CheckBox checkBoxGuardarPassword;
        private System.Windows.Forms.Button buttonHidePassword;
        private System.Windows.Forms.TextBox textBoxPortoSSH;
        private System.Windows.Forms.TextBox textBoxPortoAPI;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.Label labelSSH;
        private System.Windows.Forms.Label labelAPI;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSeePassword;
    }
}

