namespace AppLTI
{
    partial class nodesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(nodesForm));
            this.listBoxNodes = new System.Windows.Forms.ListBox();
            this.buttonListarNodes = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelPage = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnInterfaceWeb = new System.Windows.Forms.Label();
            this.buttonIngress = new System.Windows.Forms.Label();
            this.btnTerminal = new System.Windows.Forms.Label();
            this.buttonServices = new System.Windows.Forms.Label();
            this.labelService = new System.Windows.Forms.Label();
            this.labelWorkloads = new System.Windows.Forms.Label();
            this.buttonNodes = new System.Windows.Forms.Label();
            this.labelCluster = new System.Windows.Forms.Label();
            this.buttonPods = new System.Windows.Forms.Label();
            this.buttonDeployments = new System.Windows.Forms.Label();
            this.buttonNameSpaces = new System.Windows.Forms.Label();
            this.panelPods = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panelDeployments = new System.Windows.Forms.Panel();
            this.panelServices = new System.Windows.Forms.Panel();
            this.panelIngress = new System.Windows.Forms.Panel();
            this.panelNamespaces = new System.Windows.Forms.Panel();
            this.panelNodes = new System.Windows.Forms.Panel();
            this.panelInterfaceWeb = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panelTerminal = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panelDashboard = new System.Windows.Forms.Panel();
            this.labelDashboard = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelPods.SuspendLayout();
            this.panelInterfaceWeb.SuspendLayout();
            this.panelTerminal.SuspendLayout();
            this.panelDashboard.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxNodes
            // 
            this.listBoxNodes.BackColor = System.Drawing.Color.White;
            this.listBoxNodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxNodes.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listBoxNodes.FormattingEnabled = true;
            this.listBoxNodes.ItemHeight = 15;
            this.listBoxNodes.Location = new System.Drawing.Point(37, 69);
            this.listBoxNodes.Name = "listBoxNodes";
            this.listBoxNodes.ScrollAlwaysVisible = true;
            this.listBoxNodes.Size = new System.Drawing.Size(948, 469);
            this.listBoxNodes.TabIndex = 183;
            // 
            // buttonListarNodes
            // 
            this.buttonListarNodes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(125)))), ((int)(((byte)(244)))));
            this.buttonListarNodes.FlatAppearance.BorderSize = 0;
            this.buttonListarNodes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonListarNodes.Font = new System.Drawing.Font("Impact", 15F);
            this.buttonListarNodes.ForeColor = System.Drawing.Color.White;
            this.buttonListarNodes.Location = new System.Drawing.Point(409, 18);
            this.buttonListarNodes.Name = "buttonListarNodes";
            this.buttonListarNodes.Size = new System.Drawing.Size(166, 32);
            this.buttonListarNodes.TabIndex = 184;
            this.buttonListarNodes.Text = "Listar nodes";
            this.buttonListarNodes.UseVisualStyleBackColor = false;
            this.buttonListarNodes.Click += new System.EventHandler(this.buttonListarNodes_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel4.Controls.Add(this.buttonListarNodes);
            this.panel4.Controls.Add(this.listBoxNodes);
            this.panel4.Location = new System.Drawing.Point(237, 139);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1001, 578);
            this.panel4.TabIndex = 147;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(125)))), ((int)(((byte)(244)))));
            this.panel1.Controls.Add(this.labelPage);
            this.panel1.Location = new System.Drawing.Point(0, 52);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1251, 58);
            this.panel1.TabIndex = 242;
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPage.ForeColor = System.Drawing.Color.White;
            this.labelPage.Location = new System.Drawing.Point(20, 14);
            this.labelPage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(60, 29);
            this.labelPage.TabIndex = 1;
            this.labelPage.Text = "Pods";
            // 
            // textBoxIP
            // 
            this.textBoxIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.textBoxIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxIP.Enabled = false;
            this.textBoxIP.Font = new System.Drawing.Font("Impact", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIP.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxIP.Location = new System.Drawing.Point(775, 15);
            this.textBoxIP.Multiline = true;
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(400, 22);
            this.textBoxIP.TabIndex = 243;
            this.textBoxIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1180, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 241;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(4, 3);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(170, 43);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 240;
            this.pictureBox2.TabStop = false;
            // 
            // btnInterfaceWeb
            // 
            this.btnInterfaceWeb.AutoSize = true;
            this.btnInterfaceWeb.Font = new System.Drawing.Font("Impact", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInterfaceWeb.ForeColor = System.Drawing.Color.White;
            this.btnInterfaceWeb.Location = new System.Drawing.Point(19, 522);
            this.btnInterfaceWeb.Name = "btnInterfaceWeb";
            this.btnInterfaceWeb.Size = new System.Drawing.Size(127, 25);
            this.btnInterfaceWeb.TabIndex = 250;
            this.btnInterfaceWeb.Text = "Interface Web";
            this.btnInterfaceWeb.Click += new System.EventHandler(this.btnInterfaceWeb_Click);
            this.btnInterfaceWeb.MouseEnter += new System.EventHandler(this.btnInterfaceWeb_MouseEnter);
            this.btnInterfaceWeb.MouseLeave += new System.EventHandler(this.btnInterfaceWeb_MouseLeave);
            // 
            // buttonIngress
            // 
            this.buttonIngress.AutoSize = true;
            this.buttonIngress.Font = new System.Drawing.Font("Impact", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIngress.ForeColor = System.Drawing.Color.White;
            this.buttonIngress.Location = new System.Drawing.Point(37, 365);
            this.buttonIngress.Name = "buttonIngress";
            this.buttonIngress.Size = new System.Drawing.Size(70, 23);
            this.buttonIngress.TabIndex = 249;
            this.buttonIngress.Text = "Ingress";
            this.buttonIngress.Click += new System.EventHandler(this.buttonIngress_Click);
            this.buttonIngress.MouseEnter += new System.EventHandler(this.buttonIngress_MouseEnter);
            this.buttonIngress.MouseLeave += new System.EventHandler(this.buttonIngress_MouseLeave);
            // 
            // btnTerminal
            // 
            this.btnTerminal.AutoSize = true;
            this.btnTerminal.Font = new System.Drawing.Font("Impact", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerminal.ForeColor = System.Drawing.Color.White;
            this.btnTerminal.Location = new System.Drawing.Point(19, 557);
            this.btnTerminal.Name = "btnTerminal";
            this.btnTerminal.Size = new System.Drawing.Size(82, 25);
            this.btnTerminal.TabIndex = 242;
            this.btnTerminal.Text = "Terminal";
            this.btnTerminal.Click += new System.EventHandler(this.btnTerminal_Click);
            this.btnTerminal.MouseEnter += new System.EventHandler(this.btnTerminal_MouseEnter);
            this.btnTerminal.MouseLeave += new System.EventHandler(this.btnTerminal_MouseLeave);
            // 
            // buttonServices
            // 
            this.buttonServices.AutoSize = true;
            this.buttonServices.Font = new System.Drawing.Font("Impact", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonServices.ForeColor = System.Drawing.Color.White;
            this.buttonServices.Location = new System.Drawing.Point(37, 328);
            this.buttonServices.Name = "buttonServices";
            this.buttonServices.Size = new System.Drawing.Size(77, 23);
            this.buttonServices.TabIndex = 240;
            this.buttonServices.Text = "Services";
            this.buttonServices.Click += new System.EventHandler(this.buttonServices_Click);
            this.buttonServices.MouseEnter += new System.EventHandler(this.buttonServices_MouseEnter);
            this.buttonServices.MouseLeave += new System.EventHandler(this.buttonServices_MouseLeave);
            // 
            // labelService
            // 
            this.labelService.AutoSize = true;
            this.labelService.Font = new System.Drawing.Font("Impact", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelService.ForeColor = System.Drawing.Color.White;
            this.labelService.Location = new System.Drawing.Point(19, 288);
            this.labelService.Name = "labelService";
            this.labelService.Size = new System.Drawing.Size(73, 25);
            this.labelService.TabIndex = 248;
            this.labelService.Text = "Service";
            // 
            // labelWorkloads
            // 
            this.labelWorkloads.AutoSize = true;
            this.labelWorkloads.Font = new System.Drawing.Font("Impact", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWorkloads.ForeColor = System.Drawing.Color.White;
            this.labelWorkloads.Location = new System.Drawing.Point(19, 182);
            this.labelWorkloads.Name = "labelWorkloads";
            this.labelWorkloads.Size = new System.Drawing.Size(99, 25);
            this.labelWorkloads.TabIndex = 247;
            this.labelWorkloads.Text = "Workloads";
            // 
            // buttonNodes
            // 
            this.buttonNodes.AutoSize = true;
            this.buttonNodes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.buttonNodes.Font = new System.Drawing.Font("Impact", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNodes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(65)))), ((int)(((byte)(210)))));
            this.buttonNodes.Location = new System.Drawing.Point(37, 479);
            this.buttonNodes.Name = "buttonNodes";
            this.buttonNodes.Size = new System.Drawing.Size(59, 23);
            this.buttonNodes.TabIndex = 243;
            this.buttonNodes.Text = "Nodes";
            // 
            // labelCluster
            // 
            this.labelCluster.AutoSize = true;
            this.labelCluster.Font = new System.Drawing.Font("Impact", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCluster.ForeColor = System.Drawing.Color.White;
            this.labelCluster.Location = new System.Drawing.Point(19, 406);
            this.labelCluster.Name = "labelCluster";
            this.labelCluster.Size = new System.Drawing.Size(70, 25);
            this.labelCluster.TabIndex = 246;
            this.labelCluster.Text = "Cluster";
            // 
            // buttonPods
            // 
            this.buttonPods.AutoSize = true;
            this.buttonPods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.buttonPods.Font = new System.Drawing.Font("Impact", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPods.ForeColor = System.Drawing.Color.White;
            this.buttonPods.Location = new System.Drawing.Point(37, 216);
            this.buttonPods.Name = "buttonPods";
            this.buttonPods.Size = new System.Drawing.Size(49, 23);
            this.buttonPods.TabIndex = 244;
            this.buttonPods.Text = "Pods";
            this.buttonPods.Click += new System.EventHandler(this.buttonPods_Click);
            this.buttonPods.MouseEnter += new System.EventHandler(this.buttonPods_MouseEnter);
            this.buttonPods.MouseLeave += new System.EventHandler(this.buttonPods_MouseLeave);
            // 
            // buttonDeployments
            // 
            this.buttonDeployments.AutoSize = true;
            this.buttonDeployments.Font = new System.Drawing.Font("Impact", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeployments.ForeColor = System.Drawing.Color.White;
            this.buttonDeployments.Location = new System.Drawing.Point(37, 250);
            this.buttonDeployments.Name = "buttonDeployments";
            this.buttonDeployments.Size = new System.Drawing.Size(115, 23);
            this.buttonDeployments.TabIndex = 245;
            this.buttonDeployments.Text = "Deployments";
            this.buttonDeployments.Click += new System.EventHandler(this.buttonDeployments_Click);
            this.buttonDeployments.MouseEnter += new System.EventHandler(this.buttonDeployments_MouseEnter);
            this.buttonDeployments.MouseLeave += new System.EventHandler(this.buttonDeployments_MouseLeave);
            // 
            // buttonNameSpaces
            // 
            this.buttonNameSpaces.AutoSize = true;
            this.buttonNameSpaces.Font = new System.Drawing.Font("Impact", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNameSpaces.ForeColor = System.Drawing.Color.White;
            this.buttonNameSpaces.Location = new System.Drawing.Point(37, 443);
            this.buttonNameSpaces.Name = "buttonNameSpaces";
            this.buttonNameSpaces.Size = new System.Drawing.Size(112, 23);
            this.buttonNameSpaces.TabIndex = 241;
            this.buttonNameSpaces.Text = "Namespaces";
            this.buttonNameSpaces.Click += new System.EventHandler(this.buttonNameSpaces_Click);
            this.buttonNameSpaces.MouseEnter += new System.EventHandler(this.buttonNamespaces_MouseEnter);
            this.buttonNameSpaces.MouseLeave += new System.EventHandler(this.buttonNamespaces_MouseLeave);
            // 
            // panelPods
            // 
            this.panelPods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.panelPods.Controls.Add(this.panel6);
            this.panelPods.Location = new System.Drawing.Point(33, 210);
            this.panelPods.Margin = new System.Windows.Forms.Padding(2);
            this.panelPods.Name = "panelPods";
            this.panelPods.Size = new System.Drawing.Size(164, 34);
            this.panelPods.TabIndex = 251;
            this.panelPods.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelPods_click);
            this.panelPods.MouseEnter += new System.EventHandler(this.panelPods_MouseEnter);
            this.panelPods.MouseLeave += new System.EventHandler(this.panelPods_MouseLeave);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.panel6.Location = new System.Drawing.Point(0, 37);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(180, 34);
            this.panel6.TabIndex = 153;
            // 
            // panelDeployments
            // 
            this.panelDeployments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.panelDeployments.Location = new System.Drawing.Point(33, 245);
            this.panelDeployments.Margin = new System.Windows.Forms.Padding(2);
            this.panelDeployments.Name = "panelDeployments";
            this.panelDeployments.Size = new System.Drawing.Size(164, 34);
            this.panelDeployments.TabIndex = 253;
            this.panelDeployments.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelDeployments_MouseClick);
            this.panelDeployments.MouseEnter += new System.EventHandler(this.panelDeployments_MouseEnter);
            this.panelDeployments.MouseLeave += new System.EventHandler(this.panelDeployments_MouseLeave);
            // 
            // panelServices
            // 
            this.panelServices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.panelServices.Location = new System.Drawing.Point(33, 323);
            this.panelServices.Margin = new System.Windows.Forms.Padding(2);
            this.panelServices.Name = "panelServices";
            this.panelServices.Size = new System.Drawing.Size(164, 34);
            this.panelServices.TabIndex = 255;
            this.panelServices.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelServices_MouseClick);
            this.panelServices.MouseEnter += new System.EventHandler(this.panelServices_MouseEnter);
            this.panelServices.MouseLeave += new System.EventHandler(this.panelServices_MouseLeave);
            // 
            // panelIngress
            // 
            this.panelIngress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.panelIngress.Location = new System.Drawing.Point(33, 360);
            this.panelIngress.Margin = new System.Windows.Forms.Padding(2);
            this.panelIngress.Name = "panelIngress";
            this.panelIngress.Size = new System.Drawing.Size(164, 34);
            this.panelIngress.TabIndex = 256;
            this.panelIngress.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelIngress_MouseClick);
            this.panelIngress.MouseEnter += new System.EventHandler(this.panelIngress_MouseEnter);
            this.panelIngress.MouseLeave += new System.EventHandler(this.panelIngress_MouseLeave);
            // 
            // panelNamespaces
            // 
            this.panelNamespaces.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.panelNamespaces.Location = new System.Drawing.Point(33, 437);
            this.panelNamespaces.Margin = new System.Windows.Forms.Padding(2);
            this.panelNamespaces.Name = "panelNamespaces";
            this.panelNamespaces.Size = new System.Drawing.Size(164, 34);
            this.panelNamespaces.TabIndex = 257;
            this.panelNamespaces.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelNamespaces_MouseClick);
            this.panelNamespaces.MouseEnter += new System.EventHandler(this.panelNamespaces_MouseEnter);
            this.panelNamespaces.MouseLeave += new System.EventHandler(this.panelNamespaces_MouseLeave);
            // 
            // panelNodes
            // 
            this.panelNodes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.panelNodes.Location = new System.Drawing.Point(33, 474);
            this.panelNodes.Margin = new System.Windows.Forms.Padding(2);
            this.panelNodes.Name = "panelNodes";
            this.panelNodes.Size = new System.Drawing.Size(164, 34);
            this.panelNodes.TabIndex = 258;
            // 
            // panelInterfaceWeb
            // 
            this.panelInterfaceWeb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.panelInterfaceWeb.Controls.Add(this.panel12);
            this.panelInterfaceWeb.Location = new System.Drawing.Point(17, 518);
            this.panelInterfaceWeb.Margin = new System.Windows.Forms.Padding(2);
            this.panelInterfaceWeb.Name = "panelInterfaceWeb";
            this.panelInterfaceWeb.Size = new System.Drawing.Size(180, 34);
            this.panelInterfaceWeb.TabIndex = 252;
            this.panelInterfaceWeb.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelInterfaceWeb_MouseClick);
            this.panelInterfaceWeb.MouseEnter += new System.EventHandler(this.panelInterfaceWeb_MouseEnter);
            this.panelInterfaceWeb.MouseLeave += new System.EventHandler(this.panelInterfaceWeb_MouseLeave);
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.panel12.Location = new System.Drawing.Point(0, 37);
            this.panel12.Margin = new System.Windows.Forms.Padding(2);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(180, 34);
            this.panel12.TabIndex = 153;
            // 
            // panelTerminal
            // 
            this.panelTerminal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.panelTerminal.Controls.Add(this.panel13);
            this.panelTerminal.Location = new System.Drawing.Point(17, 556);
            this.panelTerminal.Margin = new System.Windows.Forms.Padding(2);
            this.panelTerminal.Name = "panelTerminal";
            this.panelTerminal.Size = new System.Drawing.Size(180, 34);
            this.panelTerminal.TabIndex = 254;
            this.panelTerminal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelTerminal_MouseClick);
            this.panelTerminal.MouseEnter += new System.EventHandler(this.panelTerminal_MouseEnter);
            this.panelTerminal.MouseLeave += new System.EventHandler(this.panelTerminal_MouseLeave);
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.panel13.Location = new System.Drawing.Point(0, 37);
            this.panel13.Margin = new System.Windows.Forms.Padding(2);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(180, 34);
            this.panel13.TabIndex = 153;
            // 
            // panelDashboard
            // 
            this.panelDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.panelDashboard.Controls.Add(this.labelDashboard);
            this.panelDashboard.Controls.Add(this.panel3);
            this.panelDashboard.Location = new System.Drawing.Point(16, 140);
            this.panelDashboard.Margin = new System.Windows.Forms.Padding(2);
            this.panelDashboard.Name = "panelDashboard";
            this.panelDashboard.Size = new System.Drawing.Size(180, 34);
            this.panelDashboard.TabIndex = 239;
            this.panelDashboard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelDashboard_click);
            this.panelDashboard.MouseEnter += new System.EventHandler(this.panelDashboard_MouseEnter);
            this.panelDashboard.MouseLeave += new System.EventHandler(this.panelDashboard_MouseLeave);
            // 
            // labelDashboard
            // 
            this.labelDashboard.AutoSize = true;
            this.labelDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.labelDashboard.Font = new System.Drawing.Font("Impact", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDashboard.ForeColor = System.Drawing.Color.White;
            this.labelDashboard.Location = new System.Drawing.Point(3, 5);
            this.labelDashboard.Name = "labelDashboard";
            this.labelDashboard.Size = new System.Drawing.Size(99, 25);
            this.labelDashboard.TabIndex = 154;
            this.labelDashboard.Text = "Dashboard";
            this.labelDashboard.Click += new System.EventHandler(this.labelDashboard_Click);
            this.labelDashboard.MouseEnter += new System.EventHandler(this.labelDashboard_MouseEnter);
            this.labelDashboard.MouseLeave += new System.EventHandler(this.labelDashboard_MouseLeave);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.panel3.Location = new System.Drawing.Point(0, 37);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(180, 34);
            this.panel3.TabIndex = 153;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.panel2.Location = new System.Drawing.Point(214, 139);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 578);
            this.panel2.TabIndex = 259;
            // 
            // nodesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(1250, 729);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnInterfaceWeb);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonIngress);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.btnTerminal);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonServices);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.labelService);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.labelWorkloads);
            this.Controls.Add(this.buttonNodes);
            this.Controls.Add(this.panelDashboard);
            this.Controls.Add(this.labelCluster);
            this.Controls.Add(this.panelTerminal);
            this.Controls.Add(this.buttonPods);
            this.Controls.Add(this.panelInterfaceWeb);
            this.Controls.Add(this.buttonDeployments);
            this.Controls.Add(this.panelNodes);
            this.Controls.Add(this.buttonNameSpaces);
            this.Controls.Add(this.panelNamespaces);
            this.Controls.Add(this.panelPods);
            this.Controls.Add(this.panelIngress);
            this.Controls.Add(this.panelServices);
            this.Controls.Add(this.panelDeployments);
            this.Name = "nodesForm";
            this.Text = "nodesForm";
            this.Load += new System.EventHandler(this.nodesForm_Load);
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelPods.ResumeLayout(false);
            this.panelInterfaceWeb.ResumeLayout(false);
            this.panelTerminal.ResumeLayout(false);
            this.panelDashboard.ResumeLayout(false);
            this.panelDashboard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBoxNodes;
        private System.Windows.Forms.Button buttonListarNodes;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label btnInterfaceWeb;
        private System.Windows.Forms.Label buttonIngress;
        private System.Windows.Forms.Label btnTerminal;
        private System.Windows.Forms.Label buttonServices;
        private System.Windows.Forms.Label labelService;
        private System.Windows.Forms.Label labelWorkloads;
        private System.Windows.Forms.Label buttonNodes;
        private System.Windows.Forms.Label labelCluster;
        private System.Windows.Forms.Label buttonPods;
        private System.Windows.Forms.Label buttonDeployments;
        private System.Windows.Forms.Label buttonNameSpaces;
        private System.Windows.Forms.Panel panelPods;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panelDeployments;
        private System.Windows.Forms.Panel panelServices;
        private System.Windows.Forms.Panel panelIngress;
        private System.Windows.Forms.Panel panelNamespaces;
        private System.Windows.Forms.Panel panelNodes;
        private System.Windows.Forms.Panel panelInterfaceWeb;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panelTerminal;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panelDashboard;
        private System.Windows.Forms.Label labelDashboard;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
    }
}