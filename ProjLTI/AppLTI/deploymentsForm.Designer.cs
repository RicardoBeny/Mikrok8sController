namespace AppLTI
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
            this.comboBoxDeployments = new System.Windows.Forms.ComboBox();
            this.buttonDeleteDeployments = new System.Windows.Forms.Button();
            this.buttonCreateDeployments = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNomeAdd = new System.Windows.Forms.TextBox();
            this.listBoxDeployments = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxNamespaceCriar = new System.Windows.Forms.ComboBox();
            this.textBoxContainerName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxLabelApp = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.textBoxReplicas = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            this.btnInterfaceWeb = new System.Windows.Forms.Label();
            this.buttonIngress = new System.Windows.Forms.Label();
            this.btnTerminal = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBoxEquipaMetadata = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxproposito = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxncontainers = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxOwner = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxImage = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUsername)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DodgerBlue;
            this.label4.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(174, 70);
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
            this.comboBoxNamespaces.Location = new System.Drawing.Point(306, 70);
            this.comboBoxNamespaces.Name = "comboBoxNamespaces";
            this.comboBoxNamespaces.Size = new System.Drawing.Size(295, 21);
            this.comboBoxNamespaces.TabIndex = 226;
            this.comboBoxNamespaces.SelectedIndexChanged += new System.EventHandler(this.comboBoxNamespaces_SelectedIndexChanged);
            // 
            // textBoxPorto
            // 
            this.textBoxPorto.Location = new System.Drawing.Point(96, 425);
            this.textBoxPorto.Name = "textBoxPorto";
            this.textBoxPorto.Size = new System.Drawing.Size(350, 20);
            this.textBoxPorto.TabIndex = 225;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(33, 424);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 23);
            this.label3.TabIndex = 224;
            this.label3.Text = "Porto:";
            // 
            // comboBoxDeployments
            // 
            this.comboBoxDeployments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDeployments.FormattingEnabled = true;
            this.comboBoxDeployments.Location = new System.Drawing.Point(771, 373);
            this.comboBoxDeployments.Name = "comboBoxDeployments";
            this.comboBoxDeployments.Size = new System.Drawing.Size(236, 21);
            this.comboBoxDeployments.TabIndex = 221;
            // 
            // buttonDeleteDeployments
            // 
            this.buttonDeleteDeployments.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteDeployments.Location = new System.Drawing.Point(796, 334);
            this.buttonDeleteDeployments.Name = "buttonDeleteDeployments";
            this.buttonDeleteDeployments.Size = new System.Drawing.Size(191, 32);
            this.buttonDeleteDeployments.TabIndex = 220;
            this.buttonDeleteDeployments.Text = "Apagar Deployments";
            this.buttonDeleteDeployments.UseVisualStyleBackColor = true;
            this.buttonDeleteDeployments.Click += new System.EventHandler(this.buttonDeleteDeployments_Click);
            // 
            // buttonCreateDeployments
            // 
            this.buttonCreateDeployments.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreateDeployments.Location = new System.Drawing.Point(128, 334);
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
            this.label1.Location = new System.Drawing.Point(33, 369);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 218;
            this.label1.Text = "Nome*:";
            // 
            // textBoxNomeAdd
            // 
            this.textBoxNomeAdd.Location = new System.Drawing.Point(98, 372);
            this.textBoxNomeAdd.Name = "textBoxNomeAdd";
            this.textBoxNomeAdd.Size = new System.Drawing.Size(348, 20);
            this.textBoxNomeAdd.TabIndex = 217;
            // 
            // listBoxDeployments
            // 
            this.listBoxDeployments.FormattingEnabled = true;
            this.listBoxDeployments.Location = new System.Drawing.Point(37, 35);
            this.listBoxDeployments.Name = "listBoxDeployments";
            this.listBoxDeployments.ScrollAlwaysVisible = true;
            this.listBoxDeployments.Size = new System.Drawing.Size(969, 290);
            this.listBoxDeployments.TabIndex = 216;
            this.listBoxDeployments.SelectedIndexChanged += new System.EventHandler(this.listBoxDeployments_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(33, 398);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 23);
            this.label2.TabIndex = 229;
            this.label2.Text = "Namespaces*:";
            // 
            // comboBoxNamespaceCriar
            // 
            this.comboBoxNamespaceCriar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNamespaceCriar.FormattingEnabled = true;
            this.comboBoxNamespaceCriar.Items.AddRange(new object[] {
            "Todos"});
            this.comboBoxNamespaceCriar.Location = new System.Drawing.Point(151, 398);
            this.comboBoxNamespaceCriar.Name = "comboBoxNamespaceCriar";
            this.comboBoxNamespaceCriar.Size = new System.Drawing.Size(295, 21);
            this.comboBoxNamespaceCriar.TabIndex = 228;
            // 
            // textBoxContainerName
            // 
            this.textBoxContainerName.Location = new System.Drawing.Point(619, 481);
            this.textBoxContainerName.Name = "textBoxContainerName";
            this.textBoxContainerName.Size = new System.Drawing.Size(134, 20);
            this.textBoxContainerName.TabIndex = 231;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(460, 478);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 23);
            this.label5.TabIndex = 230;
            this.label5.Text = "Nome do Container*:";
            // 
            // textBoxLabelApp
            // 
            this.textBoxLabelApp.Location = new System.Drawing.Point(118, 507);
            this.textBoxLabelApp.Name = "textBoxLabelApp";
            this.textBoxLabelApp.Size = new System.Drawing.Size(328, 20);
            this.textBoxLabelApp.TabIndex = 233;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(31, 501);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 23);
            this.label6.TabIndex = 232;
            this.label6.Text = "Label app:";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.Location = new System.Drawing.Point(33, 449);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(69, 23);
            this.label.TabIndex = 234;
            this.label.Text = "Image*:";
            // 
            // textBoxReplicas
            // 
            this.textBoxReplicas.Location = new System.Drawing.Point(112, 478);
            this.textBoxReplicas.Name = "textBoxReplicas";
            this.textBoxReplicas.Size = new System.Drawing.Size(334, 20);
            this.textBoxReplicas.TabIndex = 237;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(31, 472);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 23);
            this.label7.TabIndex = 236;
            this.label7.Text = "Replicas*:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
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
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1251, 101);
            this.panel1.TabIndex = 238;
            // 
            // labelDashboard
            // 
            this.labelDashboard.AutoSize = true;
            this.labelDashboard.Font = new System.Drawing.Font("Impact", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDashboard.ForeColor = System.Drawing.Color.White;
            this.labelDashboard.Location = new System.Drawing.Point(554, 21);
            this.labelDashboard.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDashboard.Name = "labelDashboard";
            this.labelDashboard.Size = new System.Drawing.Size(218, 43);
            this.labelDashboard.TabIndex = 1;
            this.labelDashboard.Text = "Deployments";
            // 
            // textBoxIP
            // 
            this.textBoxIP.BackColor = System.Drawing.Color.DodgerBlue;
            this.textBoxIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxIP.Enabled = false;
            this.textBoxIP.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIP.ForeColor = System.Drawing.Color.White;
            this.textBoxIP.Location = new System.Drawing.Point(775, 30);
            this.textBoxIP.Multiline = true;
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(409, 22);
            this.textBoxIP.TabIndex = 129;
            this.textBoxIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pictureUsername
            // 
            this.pictureUsername.Image = ((System.Drawing.Image)(resources.GetObject("pictureUsername.Image")));
            this.pictureUsername.Location = new System.Drawing.Point(1189, 11);
            this.pictureUsername.Margin = new System.Windows.Forms.Padding(2);
            this.pictureUsername.Name = "pictureUsername";
            this.pictureUsername.Size = new System.Drawing.Size(50, 53);
            this.pictureUsername.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureUsername.TabIndex = 131;
            this.pictureUsername.TabStop = false;
            // 
            // buttonServices
            // 
            this.buttonServices.AutoSize = true;
            this.buttonServices.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonServices.ForeColor = System.Drawing.Color.White;
            this.buttonServices.Location = new System.Drawing.Point(29, 171);
            this.buttonServices.Name = "buttonServices";
            this.buttonServices.Size = new System.Drawing.Size(77, 23);
            this.buttonServices.TabIndex = 0;
            this.buttonServices.Text = "Services";
            this.buttonServices.Click += new System.EventHandler(this.buttonServices_Click);
            // 
            // labelService
            // 
            this.labelService.AutoSize = true;
            this.labelService.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelService.ForeColor = System.Drawing.Color.White;
            this.labelService.Location = new System.Drawing.Point(11, 137);
            this.labelService.Name = "labelService";
            this.labelService.Size = new System.Drawing.Size(75, 23);
            this.labelService.TabIndex = 146;
            this.labelService.Text = "Service";
            // 
            // labelWorkloads
            // 
            this.labelWorkloads.AutoSize = true;
            this.labelWorkloads.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWorkloads.ForeColor = System.Drawing.Color.White;
            this.labelWorkloads.Location = new System.Drawing.Point(11, 26);
            this.labelWorkloads.Name = "labelWorkloads";
            this.labelWorkloads.Size = new System.Drawing.Size(104, 23);
            this.labelWorkloads.TabIndex = 145;
            this.labelWorkloads.Text = "Workloads";
            // 
            // labelCluster
            // 
            this.labelCluster.AutoSize = true;
            this.labelCluster.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCluster.ForeColor = System.Drawing.Color.White;
            this.labelCluster.Location = new System.Drawing.Point(11, 238);
            this.labelCluster.Name = "labelCluster";
            this.labelCluster.Size = new System.Drawing.Size(75, 23);
            this.labelCluster.TabIndex = 144;
            this.labelCluster.Text = "Cluster";
            // 
            // buttonDeployments
            // 
            this.buttonDeployments.AutoSize = true;
            this.buttonDeployments.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeployments.ForeColor = System.Drawing.Color.White;
            this.buttonDeployments.Location = new System.Drawing.Point(29, 95);
            this.buttonDeployments.Name = "buttonDeployments";
            this.buttonDeployments.Size = new System.Drawing.Size(115, 23);
            this.buttonDeployments.TabIndex = 141;
            this.buttonDeployments.Text = "Deployments";
            // 
            // buttonNameSpaces
            // 
            this.buttonNameSpaces.AutoSize = true;
            this.buttonNameSpaces.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNameSpaces.ForeColor = System.Drawing.Color.White;
            this.buttonNameSpaces.Location = new System.Drawing.Point(29, 271);
            this.buttonNameSpaces.Name = "buttonNameSpaces";
            this.buttonNameSpaces.Size = new System.Drawing.Size(112, 23);
            this.buttonNameSpaces.TabIndex = 137;
            this.buttonNameSpaces.Text = "Namespaces";
            this.buttonNameSpaces.Click += new System.EventHandler(this.buttonNameSpaces_Click);
            // 
            // buttonPods
            // 
            this.buttonPods.AutoSize = true;
            this.buttonPods.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPods.ForeColor = System.Drawing.Color.White;
            this.buttonPods.Location = new System.Drawing.Point(29, 61);
            this.buttonPods.Name = "buttonPods";
            this.buttonPods.Size = new System.Drawing.Size(49, 23);
            this.buttonPods.TabIndex = 140;
            this.buttonPods.Text = "Pods";
            this.buttonPods.Click += new System.EventHandler(this.buttonPods_Click);
            // 
            // buttonNodes
            // 
            this.buttonNodes.AutoSize = true;
            this.buttonNodes.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNodes.ForeColor = System.Drawing.Color.White;
            this.buttonNodes.Location = new System.Drawing.Point(29, 305);
            this.buttonNodes.Name = "buttonNodes";
            this.buttonNodes.Size = new System.Drawing.Size(59, 23);
            this.buttonNodes.TabIndex = 139;
            this.buttonNodes.Text = "Nodes";
            this.buttonNodes.Click += new System.EventHandler(this.buttonNodes_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Controls.Add(this.btnInterfaceWeb);
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
            this.panel3.Location = new System.Drawing.Point(0, 96);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1251, 636);
            this.panel3.TabIndex = 239;
            // 
            // btnInterfaceWeb
            // 
            this.btnInterfaceWeb.AutoSize = true;
            this.btnInterfaceWeb.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInterfaceWeb.ForeColor = System.Drawing.Color.White;
            this.btnInterfaceWeb.Location = new System.Drawing.Point(12, 558);
            this.btnInterfaceWeb.Name = "btnInterfaceWeb";
            this.btnInterfaceWeb.Size = new System.Drawing.Size(121, 23);
            this.btnInterfaceWeb.TabIndex = 250;
            this.btnInterfaceWeb.Text = "Interface Web";
            this.btnInterfaceWeb.Click += new System.EventHandler(this.btnInterfaceWeb_Click);
            // 
            // buttonIngress
            // 
            this.buttonIngress.AutoSize = true;
            this.buttonIngress.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIngress.ForeColor = System.Drawing.Color.White;
            this.buttonIngress.Location = new System.Drawing.Point(29, 202);
            this.buttonIngress.Name = "buttonIngress";
            this.buttonIngress.Size = new System.Drawing.Size(70, 23);
            this.buttonIngress.TabIndex = 148;
            this.buttonIngress.Text = "Ingress";
            this.buttonIngress.Click += new System.EventHandler(this.buttonIngress_Click);
            // 
            // btnTerminal
            // 
            this.btnTerminal.AutoSize = true;
            this.btnTerminal.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerminal.ForeColor = System.Drawing.Color.White;
            this.btnTerminal.Location = new System.Drawing.Point(11, 581);
            this.btnTerminal.Name = "btnTerminal";
            this.btnTerminal.Size = new System.Drawing.Size(80, 23);
            this.btnTerminal.TabIndex = 138;
            this.btnTerminal.Text = "Terminal";
            this.btnTerminal.Click += new System.EventHandler(this.btnTerminal_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel4.Controls.Add(this.textBoxEquipaMetadata);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.textBoxproposito);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.textBoxncontainers);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.textBoxOwner);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.comboBoxImage);
            this.panel4.Controls.Add(this.listBoxDeployments);
            this.panel4.Controls.Add(this.buttonCreateDeployments);
            this.panel4.Controls.Add(this.textBoxReplicas);
            this.panel4.Controls.Add(this.textBoxNomeAdd);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.buttonDeleteDeployments);
            this.panel4.Controls.Add(this.label);
            this.panel4.Controls.Add(this.comboBoxDeployments);
            this.panel4.Controls.Add(this.textBoxLabelApp);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.textBoxPorto);
            this.panel4.Controls.Add(this.textBoxContainerName);
            this.panel4.Controls.Add(this.comboBoxNamespaceCriar);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(178, 26);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1043, 578);
            this.panel4.TabIndex = 147;
            // 
            // textBoxEquipaMetadata
            // 
            this.textBoxEquipaMetadata.Location = new System.Drawing.Point(533, 427);
            this.textBoxEquipaMetadata.Name = "textBoxEquipaMetadata";
            this.textBoxEquipaMetadata.Size = new System.Drawing.Size(221, 20);
            this.textBoxEquipaMetadata.TabIndex = 249;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label15.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(460, 424);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 23);
            this.label15.TabIndex = 248;
            this.label15.Text = "Equipa:";
            // 
            // textBoxproposito
            // 
            this.textBoxproposito.Location = new System.Drawing.Point(550, 376);
            this.textBoxproposito.Name = "textBoxproposito";
            this.textBoxproposito.Size = new System.Drawing.Size(204, 20);
            this.textBoxproposito.TabIndex = 247;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(460, 372);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 23);
            this.label12.TabIndex = 246;
            this.label12.Text = "Propósito:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Impact", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(567, 350);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 23);
            this.label11.TabIndex = 245;
            this.label11.Text = "MetaData";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Impact", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(565, 450);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 23);
            this.label10.TabIndex = 244;
            this.label10.Text = "Container";
            // 
            // textBoxncontainers
            // 
            this.textBoxncontainers.Location = new System.Drawing.Point(597, 510);
            this.textBoxncontainers.Name = "textBoxncontainers";
            this.textBoxncontainers.Size = new System.Drawing.Size(156, 20);
            this.textBoxncontainers.TabIndex = 243;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(460, 505);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(142, 23);
            this.label9.TabIndex = 242;
            this.label9.Text = "Nº de containers:";
            // 
            // textBoxOwner
            // 
            this.textBoxOwner.Location = new System.Drawing.Point(526, 402);
            this.textBoxOwner.Name = "textBoxOwner";
            this.textBoxOwner.Size = new System.Drawing.Size(228, 20);
            this.textBoxOwner.TabIndex = 241;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(460, 396);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 23);
            this.label8.TabIndex = 240;
            this.label8.Text = "Owner:";
            // 
            // comboBoxImage
            // 
            this.comboBoxImage.FormattingEnabled = true;
            this.comboBoxImage.Items.AddRange(new object[] {
            "nginx:mainline",
            "httpd:latest",
            "caddy:latest",
            "mysql:latest",
            "mysql:latest",
            "postgres:latest",
            "mongo:latest",
            "redis:latest",
            "mariadb:latest",
            "python:latest",
            "node:latest",
            "ruby:latest",
            "golang:latest",
            "php:latest",
            "busybox:latest",
            "alpine:latest",
            "ubuntu:latest",
            "centos:latest",
            "debian:latest",
            "jenkins/jenkins:latest",
            "gitlab/gitlab-ce:latest",
            "sonarqube:latest",
            "prom/prometheus:latest",
            "grafana/grafana:latest",
            "elasticsearch:latest",
            "kibana:latest",
            "varnish:latest",
            "rabbitmq:latest",
            "wurstmeister/kafka:latest",
            "portainer/portainer-ce:latest"});
            this.comboBoxImage.Location = new System.Drawing.Point(96, 450);
            this.comboBoxImage.Name = "comboBoxImage";
            this.comboBoxImage.Size = new System.Drawing.Size(350, 21);
            this.comboBoxImage.TabIndex = 239;
            // 
            // deploymentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 729);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "deploymentsForm";
            this.Text = "deploymentsForm";
            this.Load += new System.EventHandler(this.deploymentsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxNamespaces;
        private System.Windows.Forms.TextBox textBoxPorto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxDeployments;
        private System.Windows.Forms.Button buttonDeleteDeployments;
        private System.Windows.Forms.Button buttonCreateDeployments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNomeAdd;
        private System.Windows.Forms.ListBox listBoxDeployments;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxNamespaceCriar;
        private System.Windows.Forms.TextBox textBoxContainerName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxLabelApp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox textBoxReplicas;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
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
        private System.Windows.Forms.ComboBox comboBoxImage;
        private System.Windows.Forms.Label buttonIngress;
        private System.Windows.Forms.TextBox textBoxOwner;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxncontainers;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxproposito;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label btnInterfaceWeb;
        private System.Windows.Forms.TextBox textBoxEquipaMetadata;
        private System.Windows.Forms.Label label15;
    }
}