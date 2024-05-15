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
            this.checkBoxGuardarCredencias = new System.Windows.Forms.CheckBox();
            this.buttonSeePassword = new System.Windows.Forms.Button();
            this.buttonHidePassword = new System.Windows.Forms.Button();
            this.textBoxPortoSSH = new System.Windows.Forms.TextBox();
            this.textBoxPortoAPI = new System.Windows.Forms.TextBox();
            this.labelIP = new System.Windows.Forms.Label();
            this.labelSSH = new System.Windows.Forms.Label();
            this.labelAPI = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.textBoxRouterIP.Location = new System.Drawing.Point(194, 206);
            this.textBoxRouterIP.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxRouterIP.Name = "textBoxRouterIP";
            this.textBoxRouterIP.Size = new System.Drawing.Size(236, 23);
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
            this.textBoxUsername.Location = new System.Drawing.Point(461, 310);
            this.textBoxUsername.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(236, 23);
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
            this.textBoxPassword.Location = new System.Drawing.Point(461, 352);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '•';
            this.textBoxPassword.Size = new System.Drawing.Size(211, 23);
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
            this.btnLogin.Location = new System.Drawing.Point(496, 446);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(163, 41);
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
            this.comboBoxRoutersIP.Location = new System.Drawing.Point(496, 245);
            this.comboBoxRoutersIP.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxRoutersIP.Name = "comboBoxRoutersIP";
            this.comboBoxRoutersIP.Size = new System.Drawing.Size(163, 25);
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
            this.checkBoxGuardarCredencias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBoxGuardarCredencias.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxGuardarCredencias.ForeColor = System.Drawing.Color.White;
            this.checkBoxGuardarCredencias.Location = new System.Drawing.Point(496, 399);
            this.checkBoxGuardarCredencias.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxGuardarCredencias.Name = "checkBoxGuardarCredencias";
            this.checkBoxGuardarCredencias.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxGuardarCredencias.Size = new System.Drawing.Size(163, 24);
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
            this.buttonSeePassword.Location = new System.Drawing.Point(675, 353);
            this.buttonSeePassword.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSeePassword.Name = "buttonSeePassword";
            this.buttonSeePassword.Size = new System.Drawing.Size(22, 22);
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
            this.buttonHidePassword.Location = new System.Drawing.Point(676, 353);
            this.buttonHidePassword.Margin = new System.Windows.Forms.Padding(2);
            this.buttonHidePassword.Name = "buttonHidePassword";
            this.buttonHidePassword.Size = new System.Drawing.Size(21, 22);
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
            this.textBoxPortoSSH.Location = new System.Drawing.Point(461, 206);
            this.textBoxPortoSSH.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPortoSSH.Name = "textBoxPortoSSH";
            this.textBoxPortoSSH.Size = new System.Drawing.Size(236, 23);
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
            this.textBoxPortoAPI.Location = new System.Drawing.Point(737, 206);
            this.textBoxPortoAPI.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPortoAPI.Name = "textBoxPortoAPI";
            this.textBoxPortoAPI.Size = new System.Drawing.Size(236, 23);
            this.textBoxPortoAPI.TabIndex = 22;
            this.textBoxPortoAPI.Text = "6443";
            this.textBoxPortoAPI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIP.ForeColor = System.Drawing.Color.White;
            this.labelIP.Location = new System.Drawing.Point(258, 160);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(116, 23);
            this.labelIP.TabIndex = 23;
            this.labelIP.Text = "IP do servidor";
            // 
            // labelSSH
            // 
            this.labelSSH.AutoSize = true;
            this.labelSSH.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSSH.ForeColor = System.Drawing.Color.White;
            this.labelSSH.Location = new System.Drawing.Point(534, 160);
            this.labelSSH.Name = "labelSSH";
            this.labelSSH.Size = new System.Drawing.Size(87, 23);
            this.labelSSH.TabIndex = 24;
            this.labelSSH.Text = "Porto SSH";
            // 
            // labelAPI
            // 
            this.labelAPI.AutoSize = true;
            this.labelAPI.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAPI.ForeColor = System.Drawing.Color.White;
            this.labelAPI.Location = new System.Drawing.Point(814, 160);
            this.labelAPI.Name = "labelAPI";
            this.labelAPI.Size = new System.Drawing.Size(80, 23);
            this.labelAPI.TabIndex = 25;
            this.labelAPI.Text = "Porto API";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.ForeColor = System.Drawing.Color.White;
            this.labelUsername.Location = new System.Drawing.Point(361, 310);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(95, 23);
            this.labelUsername.TabIndex = 26;
            this.labelUsername.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(364, 352);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 23);
            this.label2.TabIndex = 27;
            this.label2.Text = "Password:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1155, 687);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.labelAPI);
            this.Controls.Add(this.labelSSH);
            this.Controls.Add(this.labelIP);
            this.Controls.Add(this.textBoxPortoAPI);
            this.Controls.Add(this.textBoxPortoSSH);
            this.Controls.Add(this.buttonSeePassword);
            this.Controls.Add(this.checkBoxGuardarCredencias);
            this.Controls.Add(this.comboBoxRoutersIP);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.textBoxRouterIP);
            this.Controls.Add(this.buttonHidePassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "loginForm";
            this.Text = "SDNController - MikroTik";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxRouterIP;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.ComboBox comboBoxRoutersIP;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.CheckBox checkBoxGuardarCredencias;
        private System.Windows.Forms.Button buttonSeePassword;
        private System.Windows.Forms.Button buttonHidePassword;
        private System.Windows.Forms.TextBox textBoxPortoSSH;
        private System.Windows.Forms.TextBox textBoxPortoAPI;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.Label labelSSH;
        private System.Windows.Forms.Label labelAPI;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

