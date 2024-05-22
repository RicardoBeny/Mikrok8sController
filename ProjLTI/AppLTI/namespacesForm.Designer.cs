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
            this.listBoxNamespaces = new System.Windows.Forms.ListBox();
            this.textBoxNomeAdd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCreateNamespace = new System.Windows.Forms.Button();
            this.buttonDeleteNamespace = new System.Windows.Forms.Button();
            this.comboBoxNamespaces = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelDashboard = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.pictureUsername = new System.Windows.Forms.PictureBox();
            this.buttonServices = new System.Windows.Forms.Label();
            this.labelService = new System.Windows.Forms.Label();
            this.labelWorkloads = new System.Windows.Forms.Label();
            this.labelCluster = new System.Windows.Forms.Label();
            this.buttonDeployments = new System.Windows.Forms.Label();
            this.buttonNameSpaces = new System.Windows.Forms.Label();
            this.buttonPods = new System.Windows.Forms.Label();
            this.buttonNodes = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonIngress = new System.Windows.Forms.Label();
            this.btnTerminal = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUsername)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonListarNamespaces
            // 
            this.buttonListarNamespaces.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonListarNamespaces.Location = new System.Drawing.Point(520, 20);
            this.buttonListarNamespaces.Margin = new System.Windows.Forms.Padding(4);
            this.buttonListarNamespaces.Name = "buttonListarNamespaces";
            this.buttonListarNamespaces.Size = new System.Drawing.Size(320, 39);
            this.buttonListarNamespaces.TabIndex = 190;
            this.buttonListarNamespaces.Text = "Listar namespaces";
            this.buttonListarNamespaces.UseVisualStyleBackColor = true;
            this.buttonListarNamespaces.Click += new System.EventHandler(this.buttonListarNamespaces_Click);
            // 
            // listBoxNamespaces
            // 
            this.listBoxNamespaces.FormattingEnabled = true;
            this.listBoxNamespaces.ItemHeight = 16;
            this.listBoxNamespaces.Location = new System.Drawing.Point(60, 66);
            this.listBoxNamespaces.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxNamespaces.Name = "listBoxNamespaces";
            this.listBoxNamespaces.ScrollAlwaysVisible = true;
            this.listBoxNamespaces.Size = new System.Drawing.Size(1280, 308);
            this.listBoxNamespaces.TabIndex = 191;
            // 
            // textBoxNomeAdd
            // 
            this.textBoxNomeAdd.Location = new System.Drawing.Point(141, 498);
            this.textBoxNomeAdd.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxNomeAdd.Name = "textBoxNomeAdd";
            this.textBoxNomeAdd.Size = new System.Drawing.Size(444, 22);
            this.textBoxNomeAdd.TabIndex = 192;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(55, 495);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 29);
            this.label1.TabIndex = 193;
            this.label1.Text = "Nome:";
            // 
            // buttonCreateNamespace
            // 
            this.buttonCreateNamespace.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreateNamespace.Location = new System.Drawing.Point(192, 432);
            this.buttonCreateNamespace.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCreateNamespace.Name = "buttonCreateNamespace";
            this.buttonCreateNamespace.Size = new System.Drawing.Size(320, 39);
            this.buttonCreateNamespace.TabIndex = 194;
            this.buttonCreateNamespace.Text = "Criar Namespace";
            this.buttonCreateNamespace.UseVisualStyleBackColor = true;
            this.buttonCreateNamespace.Click += new System.EventHandler(this.buttonCreateNamespace_Click);
            // 
            // buttonDeleteNamespace
            // 
            this.buttonDeleteNamespace.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteNamespace.Location = new System.Drawing.Point(875, 432);
            this.buttonDeleteNamespace.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDeleteNamespace.Name = "buttonDeleteNamespace";
            this.buttonDeleteNamespace.Size = new System.Drawing.Size(320, 39);
            this.buttonDeleteNamespace.TabIndex = 195;
            this.buttonDeleteNamespace.Text = "Apagar Namespace";
            this.buttonDeleteNamespace.UseVisualStyleBackColor = true;
            this.buttonDeleteNamespace.Click += new System.EventHandler(this.buttonDeleteNamespace_Click);
            // 
            // comboBoxNamespaces
            // 
            this.comboBoxNamespaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNamespaces.FormattingEnabled = true;
            this.comboBoxNamespaces.Location = new System.Drawing.Point(812, 495);
            this.comboBoxNamespaces.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxNamespaces.Name = "comboBoxNamespaces";
            this.comboBoxNamespaces.Size = new System.Drawing.Size(444, 24);
            this.comboBoxNamespaces.TabIndex = 196;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(16, 14);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(127, 98);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 29;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.labelDashboard);
            this.panel1.Controls.Add(this.textBoxIP);
            this.panel1.Controls.Add(this.pictureUsername);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1668, 124);
            this.panel1.TabIndex = 197;
            // 
            // labelDashboard
            // 
            this.labelDashboard.AutoSize = true;
            this.labelDashboard.Font = new System.Drawing.Font("Impact", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDashboard.ForeColor = System.Drawing.Color.White;
            this.labelDashboard.Location = new System.Drawing.Point(768, 26);
            this.labelDashboard.Name = "labelDashboard";
            this.labelDashboard.Size = new System.Drawing.Size(266, 54);
            this.labelDashboard.TabIndex = 1;
            this.labelDashboard.Text = "Namespaces";
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
            this.labelCluster.Location = new System.Drawing.Point(15, 296);
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
            this.buttonNameSpaces.Location = new System.Drawing.Point(39, 337);
            this.buttonNameSpaces.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.buttonNameSpaces.Name = "buttonNameSpaces";
            this.buttonNameSpaces.Size = new System.Drawing.Size(139, 29);
            this.buttonNameSpaces.TabIndex = 137;
            this.buttonNameSpaces.Text = "Namespaces";
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
            this.buttonNodes.Location = new System.Drawing.Point(39, 378);
            this.buttonNodes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.buttonNodes.Name = "buttonNodes";
            this.buttonNodes.Size = new System.Drawing.Size(73, 29);
            this.buttonNodes.TabIndex = 139;
            this.buttonNodes.Text = "Nodes";
            this.buttonNodes.Click += new System.EventHandler(this.buttonNodes_Click);
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
            this.panel3.TabIndex = 198;
            // 
            // buttonIngress
            // 
            this.buttonIngress.AutoSize = true;
            this.buttonIngress.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIngress.ForeColor = System.Drawing.Color.White;
            this.buttonIngress.Location = new System.Drawing.Point(39, 249);
            this.buttonIngress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.buttonIngress.Name = "buttonIngress";
            this.buttonIngress.Size = new System.Drawing.Size(88, 29);
            this.buttonIngress.TabIndex = 149;
            this.buttonIngress.Text = "Ingress";
            this.buttonIngress.Click += new System.EventHandler(this.buttonIngress_Click);
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
            this.panel4.Controls.Add(this.buttonListarNamespaces);
            this.panel4.Controls.Add(this.textBoxNomeAdd);
            this.panel4.Controls.Add(this.comboBoxNamespaces);
            this.panel4.Controls.Add(this.listBoxNamespaces);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.buttonDeleteNamespace);
            this.panel4.Controls.Add(this.buttonCreateNamespace);
            this.panel4.Location = new System.Drawing.Point(237, 32);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1391, 711);
            this.panel4.TabIndex = 147;
            // 
            // namespacesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1667, 897);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "namespacesForm";
            this.Text = "namespacesForm";
            this.Load += new System.EventHandler(this.namespacesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUsername)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonListarNamespaces;
        private System.Windows.Forms.ListBox listBoxNamespaces;
        private System.Windows.Forms.TextBox textBoxNomeAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCreateNamespace;
        private System.Windows.Forms.Button buttonDeleteNamespace;
        private System.Windows.Forms.ComboBox comboBoxNamespaces;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelDashboard;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.PictureBox pictureUsername;
        private System.Windows.Forms.Label buttonServices;
        private System.Windows.Forms.Label labelService;
        private System.Windows.Forms.Label labelWorkloads;
        private System.Windows.Forms.Label labelCluster;
        private System.Windows.Forms.Label buttonDeployments;
        private System.Windows.Forms.Label buttonNameSpaces;
        private System.Windows.Forms.Label buttonPods;
        private System.Windows.Forms.Label buttonNodes;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label btnTerminal;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label buttonIngress;
    }
}