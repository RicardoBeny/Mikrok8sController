namespace AppLTI
{
    partial class ingressForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ingressForm));
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonIngress = new System.Windows.Forms.Label();
            this.btnTerminal = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.listBoxIngress = new System.Windows.Forms.ListBox();
            this.buttonCreateDeployments = new System.Windows.Forms.Button();
            this.buttonDeleteDeployments = new System.Windows.Forms.Button();
            this.comboBoxDeployments = new System.Windows.Forms.ComboBox();
            this.buttonServices = new System.Windows.Forms.Label();
            this.labelService = new System.Windows.Forms.Label();
            this.labelWorkloads = new System.Windows.Forms.Label();
            this.labelCluster = new System.Windows.Forms.Label();
            this.buttonDeployments = new System.Windows.Forms.Label();
            this.buttonNameSpaces = new System.Windows.Forms.Label();
            this.buttonPods = new System.Windows.Forms.Label();
            this.buttonNodes = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelDashboard = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.pictureUsername = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxNamespaces = new System.Windows.Forms.ComboBox();
            this.comboBoxNamespaceCriar = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Controls.Add(this.buttonIngress);
            this.panel3.Controls.Add(this.btnTerminal);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.buttonServices);
            this.panel3.Controls.Add(this.labelService);
            this.panel3.Controls.Add(this.labelWorkloads);
            this.panel3.Controls.Add(this.labelCluster);
            this.panel3.Controls.Add(this.buttonDeployments);
            this.panel3.Controls.Add(this.buttonNameSpaces);
            this.panel3.Controls.Add(this.buttonPods);
            this.panel3.Controls.Add(this.buttonNodes);
            this.panel3.Location = new System.Drawing.Point(0, 118);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1668, 783);
            this.panel3.TabIndex = 241;
            // 
            // buttonIngress
            // 
            this.buttonIngress.AutoSize = true;
            this.buttonIngress.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIngress.ForeColor = System.Drawing.Color.White;
            this.buttonIngress.Location = new System.Drawing.Point(39, 248);
            this.buttonIngress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.buttonIngress.Name = "buttonIngress";
            this.buttonIngress.Size = new System.Drawing.Size(88, 29);
            this.buttonIngress.TabIndex = 148;
            this.buttonIngress.Text = "Ingress";
            // 
            // btnTerminal
            // 
            this.btnTerminal.AutoSize = true;
            this.btnTerminal.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerminal.ForeColor = System.Drawing.Color.White;
            this.btnTerminal.Location = new System.Drawing.Point(15, 715);
            this.btnTerminal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnTerminal.Name = "btnTerminal";
            this.btnTerminal.Size = new System.Drawing.Size(100, 29);
            this.btnTerminal.TabIndex = 138;
            this.btnTerminal.Text = "Terminal";
            this.btnTerminal.Click += new System.EventHandler(this.btnTerminal_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel4.Controls.Add(this.comboBoxNamespaceCriar);
            this.panel4.Controls.Add(this.listBoxIngress);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.buttonCreateDeployments);
            this.panel4.Controls.Add(this.buttonDeleteDeployments);
            this.panel4.Controls.Add(this.comboBoxDeployments);
            this.panel4.Location = new System.Drawing.Point(237, 32);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1391, 711);
            this.panel4.TabIndex = 147;
            // 
            // listBoxIngress
            // 
            this.listBoxIngress.FormattingEnabled = true;
            this.listBoxIngress.ItemHeight = 16;
            this.listBoxIngress.Location = new System.Drawing.Point(49, 43);
            this.listBoxIngress.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxIngress.Name = "listBoxIngress";
            this.listBoxIngress.ScrollAlwaysVisible = true;
            this.listBoxIngress.Size = new System.Drawing.Size(1291, 356);
            this.listBoxIngress.TabIndex = 216;
            // 
            // buttonCreateDeployments
            // 
            this.buttonCreateDeployments.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreateDeployments.Location = new System.Drawing.Point(171, 411);
            this.buttonCreateDeployments.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCreateDeployments.Name = "buttonCreateDeployments";
            this.buttonCreateDeployments.Size = new System.Drawing.Size(320, 39);
            this.buttonCreateDeployments.TabIndex = 219;
            this.buttonCreateDeployments.Text = "Criar Ingress";
            this.buttonCreateDeployments.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteDeployments
            // 
            this.buttonDeleteDeployments.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteDeployments.Location = new System.Drawing.Point(847, 411);
            this.buttonDeleteDeployments.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDeleteDeployments.Name = "buttonDeleteDeployments";
            this.buttonDeleteDeployments.Size = new System.Drawing.Size(320, 39);
            this.buttonDeleteDeployments.TabIndex = 220;
            this.buttonDeleteDeployments.Text = "Apagar Ingress";
            this.buttonDeleteDeployments.UseVisualStyleBackColor = true;
            // 
            // comboBoxDeployments
            // 
            this.comboBoxDeployments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDeployments.FormattingEnabled = true;
            this.comboBoxDeployments.Location = new System.Drawing.Point(781, 454);
            this.comboBoxDeployments.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxDeployments.Name = "comboBoxDeployments";
            this.comboBoxDeployments.Size = new System.Drawing.Size(444, 24);
            this.comboBoxDeployments.TabIndex = 221;
            // 
            // buttonServices
            // 
            this.buttonServices.AutoSize = true;
            this.buttonServices.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonServices.ForeColor = System.Drawing.Color.White;
            this.buttonServices.Location = new System.Drawing.Point(39, 210);
            this.buttonServices.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.buttonServices.Name = "buttonServices";
            this.buttonServices.Size = new System.Drawing.Size(98, 29);
            this.buttonServices.TabIndex = 0;
            this.buttonServices.Text = "Services";
            this.buttonServices.Click += new System.EventHandler(this.buttonServices_Click);
            // 
            // labelService
            // 
            this.labelService.AutoSize = true;
            this.labelService.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelService.ForeColor = System.Drawing.Color.White;
            this.labelService.Location = new System.Drawing.Point(15, 169);
            this.labelService.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelService.Name = "labelService";
            this.labelService.Size = new System.Drawing.Size(94, 29);
            this.labelService.TabIndex = 146;
            this.labelService.Text = "Service";
            // 
            // labelWorkloads
            // 
            this.labelWorkloads.AutoSize = true;
            this.labelWorkloads.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWorkloads.ForeColor = System.Drawing.Color.White;
            this.labelWorkloads.Location = new System.Drawing.Point(15, 32);
            this.labelWorkloads.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWorkloads.Name = "labelWorkloads";
            this.labelWorkloads.Size = new System.Drawing.Size(127, 29);
            this.labelWorkloads.TabIndex = 145;
            this.labelWorkloads.Text = "Workloads";
            // 
            // labelCluster
            // 
            this.labelCluster.AutoSize = true;
            this.labelCluster.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCluster.ForeColor = System.Drawing.Color.White;
            this.labelCluster.Location = new System.Drawing.Point(15, 293);
            this.labelCluster.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCluster.Name = "labelCluster";
            this.labelCluster.Size = new System.Drawing.Size(91, 29);
            this.labelCluster.TabIndex = 144;
            this.labelCluster.Text = "Cluster";
            // 
            // buttonDeployments
            // 
            this.buttonDeployments.AutoSize = true;
            this.buttonDeployments.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeployments.ForeColor = System.Drawing.Color.White;
            this.buttonDeployments.Location = new System.Drawing.Point(39, 117);
            this.buttonDeployments.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.buttonDeployments.Name = "buttonDeployments";
            this.buttonDeployments.Size = new System.Drawing.Size(141, 29);
            this.buttonDeployments.TabIndex = 141;
            this.buttonDeployments.Text = "Deployments";
            this.buttonDeployments.Click += new System.EventHandler(this.buttonDeployments_Click);
            // 
            // buttonNameSpaces
            // 
            this.buttonNameSpaces.AutoSize = true;
            this.buttonNameSpaces.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNameSpaces.ForeColor = System.Drawing.Color.White;
            this.buttonNameSpaces.Location = new System.Drawing.Point(39, 334);
            this.buttonNameSpaces.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.buttonNameSpaces.Name = "buttonNameSpaces";
            this.buttonNameSpaces.Size = new System.Drawing.Size(139, 29);
            this.buttonNameSpaces.TabIndex = 137;
            this.buttonNameSpaces.Text = "Namespaces";
            this.buttonNameSpaces.Click += new System.EventHandler(this.buttonNameSpaces_Click);
            // 
            // buttonPods
            // 
            this.buttonPods.AutoSize = true;
            this.buttonPods.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPods.ForeColor = System.Drawing.Color.White;
            this.buttonPods.Location = new System.Drawing.Point(39, 75);
            this.buttonPods.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.buttonPods.Name = "buttonPods";
            this.buttonPods.Size = new System.Drawing.Size(60, 29);
            this.buttonPods.TabIndex = 140;
            this.buttonPods.Text = "Pods";
            this.buttonPods.Click += new System.EventHandler(this.buttonPods_Click);
            // 
            // buttonNodes
            // 
            this.buttonNodes.AutoSize = true;
            this.buttonNodes.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNodes.ForeColor = System.Drawing.Color.White;
            this.buttonNodes.Location = new System.Drawing.Point(39, 375);
            this.buttonNodes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.buttonNodes.Name = "buttonNodes";
            this.buttonNodes.Size = new System.Drawing.Size(73, 29);
            this.buttonNodes.TabIndex = 139;
            this.buttonNodes.Text = "Nodes";
            this.buttonNodes.Click += new System.EventHandler(this.buttonNodes_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.labelDashboard);
            this.panel1.Controls.Add(this.textBoxIP);
            this.panel1.Controls.Add(this.pictureUsername);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboBoxNamespaces);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1668, 124);
            this.panel1.TabIndex = 240;
            // 
            // labelDashboard
            // 
            this.labelDashboard.AutoSize = true;
            this.labelDashboard.Font = new System.Drawing.Font("Impact", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDashboard.ForeColor = System.Drawing.Color.White;
            this.labelDashboard.Location = new System.Drawing.Point(739, 25);
            this.labelDashboard.Name = "labelDashboard";
            this.labelDashboard.Size = new System.Drawing.Size(168, 54);
            this.labelDashboard.TabIndex = 1;
            this.labelDashboard.Text = "Ingress";
            // 
            // textBoxIP
            // 
            this.textBoxIP.BackColor = System.Drawing.Color.DodgerBlue;
            this.textBoxIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxIP.Enabled = false;
            this.textBoxIP.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIP.ForeColor = System.Drawing.Color.White;
            this.textBoxIP.Location = new System.Drawing.Point(1033, 37);
            this.textBoxIP.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxIP.Multiline = true;
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(545, 27);
            this.textBoxIP.TabIndex = 129;
            this.textBoxIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pictureUsername
            // 
            this.pictureUsername.Image = ((System.Drawing.Image)(resources.GetObject("pictureUsername.Image")));
            this.pictureUsername.Location = new System.Drawing.Point(1585, 14);
            this.pictureUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureUsername.Name = "pictureUsername";
            this.pictureUsername.Size = new System.Drawing.Size(67, 65);
            this.pictureUsername.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureUsername.TabIndex = 131;
            this.pictureUsername.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 98);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DodgerBlue;
            this.label4.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(232, 86);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 29);
            this.label4.TabIndex = 227;
            this.label4.Text = "Namespaces";
            // 
            // comboBoxNamespaces
            // 
            this.comboBoxNamespaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNamespaces.FormattingEnabled = true;
            this.comboBoxNamespaces.Items.AddRange(new object[] {
            "Todos"});
            this.comboBoxNamespaces.Location = new System.Drawing.Point(408, 86);
            this.comboBoxNamespaces.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxNamespaces.Name = "comboBoxNamespaces";
            this.comboBoxNamespaces.Size = new System.Drawing.Size(392, 24);
            this.comboBoxNamespaces.TabIndex = 226;
            this.comboBoxNamespaces.SelectedIndexChanged += new System.EventHandler(this.comboBoxNamespaces_SelectedIndexChanged);
            // 
            // comboBoxNamespaceCriar
            // 
            this.comboBoxNamespaceCriar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNamespaceCriar.FormattingEnabled = true;
            this.comboBoxNamespaceCriar.Items.AddRange(new object[] {
            "Todos"});
            this.comboBoxNamespaceCriar.Location = new System.Drawing.Point(201, 469);
            this.comboBoxNamespaceCriar.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxNamespaceCriar.Name = "comboBoxNamespaceCriar";
            this.comboBoxNamespaceCriar.Size = new System.Drawing.Size(392, 24);
            this.comboBoxNamespaceCriar.TabIndex = 242;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(44, 469);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 29);
            this.label2.TabIndex = 243;
            this.label2.Text = "Namespaces:";
            // 
            // ingressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1667, 897);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "ingressForm";
            this.Text = "ingressForm";
            this.Load += new System.EventHandler(this.ingressForm_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label buttonIngress;
        private System.Windows.Forms.Label btnTerminal;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ListBox listBoxIngress;
        private System.Windows.Forms.Button buttonCreateDeployments;
        private System.Windows.Forms.Button buttonDeleteDeployments;
        private System.Windows.Forms.ComboBox comboBoxDeployments;
        private System.Windows.Forms.Label buttonServices;
        private System.Windows.Forms.Label labelService;
        private System.Windows.Forms.Label labelWorkloads;
        private System.Windows.Forms.Label labelCluster;
        private System.Windows.Forms.Label buttonDeployments;
        private System.Windows.Forms.Label buttonNameSpaces;
        private System.Windows.Forms.Label buttonPods;
        private System.Windows.Forms.Label buttonNodes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelDashboard;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.PictureBox pictureUsername;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxNamespaces;
        private System.Windows.Forms.ComboBox comboBoxNamespaceCriar;
        private System.Windows.Forms.Label label2;
    }
}