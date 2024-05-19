namespace AppLTI
{
    partial class deploymentDetailsForm
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
            this.labelDe = new System.Windows.Forms.Label();
            this.labelDeploymentName = new System.Windows.Forms.Label();
            this.containerNamesListBox = new System.Windows.Forms.ListBox();
            this.envNamesListBox = new System.Windows.Forms.ListBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelnome = new System.Windows.Forms.Label();
            this.labelnamespace = new System.Windows.Forms.Label();
            this.labelnamespacename = new System.Windows.Forms.Label();
            this.managerlabel = new System.Windows.Forms.Label();
            this.labelmanager = new System.Windows.Forms.Label();
            this.labelrestartpolicy = new System.Windows.Forms.Label();
            this.labelrestart = new System.Windows.Forms.Label();
            this.labelgraceperiod = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labeldnspolicy = new System.Windows.Forms.Label();
            this.labeldns = new System.Windows.Forms.Label();
            this.availableReplicaslabel = new System.Windows.Forms.Label();
            this.labelAvailableReplicas = new System.Windows.Forms.Label();
            this.readyReplicaslabel = new System.Windows.Forms.Label();
            this.labelReadyReplicas = new System.Windows.Forms.Label();
            this.updatedReplicaslabel = new System.Windows.Forms.Label();
            this.labelUpdatedReplicas = new System.Windows.Forms.Label();
            this.replicaslabel = new System.Windows.Forms.Label();
            this.labelReplicas = new System.Windows.Forms.Label();
            this.observedGenerationlabel = new System.Windows.Forms.Label();
            this.labelObservedGeneration = new System.Windows.Forms.Label();
            this.labelcontainerNamesListBox = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTimeAgo = new System.Windows.Forms.Label();
            this.labeltempodeCriacao = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelDe
            // 
            this.labelDe.AutoSize = true;
            this.labelDe.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDe.ForeColor = System.Drawing.Color.White;
            this.labelDe.Location = new System.Drawing.Point(8, 12);
            this.labelDe.Name = "labelDe";
            this.labelDe.Size = new System.Drawing.Size(113, 23);
            this.labelDe.TabIndex = 1;
            this.labelDe.Text = "Deployment: ";
            // 
            // labelDeploymentName
            // 
            this.labelDeploymentName.AutoSize = true;
            this.labelDeploymentName.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDeploymentName.ForeColor = System.Drawing.Color.White;
            this.labelDeploymentName.Location = new System.Drawing.Point(117, 12);
            this.labelDeploymentName.Name = "labelDeploymentName";
            this.labelDeploymentName.Size = new System.Drawing.Size(105, 23);
            this.labelDeploymentName.TabIndex = 2;
            this.labelDeploymentName.Text = "deployment";
            this.labelDeploymentName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // containerNamesListBox
            // 
            this.containerNamesListBox.FormattingEnabled = true;
            this.containerNamesListBox.Location = new System.Drawing.Point(13, 433);
            this.containerNamesListBox.Name = "containerNamesListBox";
            this.containerNamesListBox.ScrollAlwaysVisible = true;
            this.containerNamesListBox.Size = new System.Drawing.Size(556, 95);
            this.containerNamesListBox.TabIndex = 3;
            // 
            // envNamesListBox
            // 
            this.envNamesListBox.FormattingEnabled = true;
            this.envNamesListBox.Location = new System.Drawing.Point(14, 556);
            this.envNamesListBox.Name = "envNamesListBox";
            this.envNamesListBox.ScrollAlwaysVisible = true;
            this.envNamesListBox.Size = new System.Drawing.Size(555, 95);
            this.envNamesListBox.TabIndex = 4;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(9, 64);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(55, 20);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "Nome:";
            // 
            // labelnome
            // 
            this.labelnome.AutoSize = true;
            this.labelnome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelnome.Location = new System.Drawing.Point(64, 64);
            this.labelnome.Name = "labelnome";
            this.labelnome.Size = new System.Drawing.Size(49, 20);
            this.labelnome.TabIndex = 6;
            this.labelnome.Text = "nome";
            // 
            // labelnamespace
            // 
            this.labelnamespace.AutoSize = true;
            this.labelnamespace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelnamespace.Location = new System.Drawing.Point(9, 93);
            this.labelnamespace.Name = "labelnamespace";
            this.labelnamespace.Size = new System.Drawing.Size(98, 20);
            this.labelnamespace.TabIndex = 7;
            this.labelnamespace.Text = "Namespace:";
            // 
            // labelnamespacename
            // 
            this.labelnamespacename.AutoSize = true;
            this.labelnamespacename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelnamespacename.Location = new System.Drawing.Point(106, 93);
            this.labelnamespacename.Name = "labelnamespacename";
            this.labelnamespacename.Size = new System.Drawing.Size(132, 20);
            this.labelnamespacename.TabIndex = 8;
            this.labelnamespacename.Text = "namespacename";
            // 
            // managerlabel
            // 
            this.managerlabel.AutoSize = true;
            this.managerlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managerlabel.Location = new System.Drawing.Point(85, 122);
            this.managerlabel.Name = "managerlabel";
            this.managerlabel.Size = new System.Drawing.Size(72, 20);
            this.managerlabel.TabIndex = 10;
            this.managerlabel.Text = "manager";
            // 
            // labelmanager
            // 
            this.labelmanager.AutoSize = true;
            this.labelmanager.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelmanager.Location = new System.Drawing.Point(9, 122);
            this.labelmanager.Name = "labelmanager";
            this.labelmanager.Size = new System.Drawing.Size(76, 20);
            this.labelmanager.TabIndex = 9;
            this.labelmanager.Text = "Manager:";
            // 
            // labelrestartpolicy
            // 
            this.labelrestartpolicy.AutoSize = true;
            this.labelrestartpolicy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelrestartpolicy.Location = new System.Drawing.Point(118, 151);
            this.labelrestartpolicy.Name = "labelrestartpolicy";
            this.labelrestartpolicy.Size = new System.Drawing.Size(94, 20);
            this.labelrestartpolicy.TabIndex = 12;
            this.labelrestartpolicy.Text = "restartpolicy";
            // 
            // labelrestart
            // 
            this.labelrestart.AutoSize = true;
            this.labelrestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelrestart.Location = new System.Drawing.Point(9, 151);
            this.labelrestart.Name = "labelrestart";
            this.labelrestart.Size = new System.Drawing.Size(110, 20);
            this.labelrestart.TabIndex = 11;
            this.labelrestart.Text = "Restart Policy:";
            // 
            // labelgraceperiod
            // 
            this.labelgraceperiod.AutoSize = true;
            this.labelgraceperiod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelgraceperiod.Location = new System.Drawing.Point(208, 180);
            this.labelgraceperiod.Name = "labelgraceperiod";
            this.labelgraceperiod.Size = new System.Drawing.Size(93, 20);
            this.labelgraceperiod.TabIndex = 14;
            this.labelgraceperiod.Text = "graceperiod";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Termination Grace Period:";
            // 
            // labeldnspolicy
            // 
            this.labeldnspolicy.AutoSize = true;
            this.labeldnspolicy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeldnspolicy.Location = new System.Drawing.Point(101, 209);
            this.labeldnspolicy.Name = "labeldnspolicy";
            this.labeldnspolicy.Size = new System.Drawing.Size(74, 20);
            this.labeldnspolicy.TabIndex = 16;
            this.labeldnspolicy.Text = "dnspolicy";
            // 
            // labeldns
            // 
            this.labeldns.AutoSize = true;
            this.labeldns.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeldns.Location = new System.Drawing.Point(9, 209);
            this.labeldns.Name = "labeldns";
            this.labeldns.Size = new System.Drawing.Size(91, 20);
            this.labeldns.TabIndex = 15;
            this.labeldns.Text = "DNS Policy:";
            // 
            // availableReplicaslabel
            // 
            this.availableReplicaslabel.AutoSize = true;
            this.availableReplicaslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.availableReplicaslabel.Location = new System.Drawing.Point(151, 238);
            this.availableReplicaslabel.Name = "availableReplicaslabel";
            this.availableReplicaslabel.Size = new System.Drawing.Size(131, 20);
            this.availableReplicaslabel.TabIndex = 18;
            this.availableReplicaslabel.Text = "availableReplicas";
            // 
            // labelAvailableReplicas
            // 
            this.labelAvailableReplicas.AutoSize = true;
            this.labelAvailableReplicas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAvailableReplicas.Location = new System.Drawing.Point(9, 238);
            this.labelAvailableReplicas.Name = "labelAvailableReplicas";
            this.labelAvailableReplicas.Size = new System.Drawing.Size(141, 20);
            this.labelAvailableReplicas.TabIndex = 17;
            this.labelAvailableReplicas.Text = "Available Replicas:";
            // 
            // readyReplicaslabel
            // 
            this.readyReplicaslabel.AutoSize = true;
            this.readyReplicaslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.readyReplicaslabel.Location = new System.Drawing.Point(129, 267);
            this.readyReplicaslabel.Name = "readyReplicaslabel";
            this.readyReplicaslabel.Size = new System.Drawing.Size(109, 20);
            this.readyReplicaslabel.TabIndex = 20;
            this.readyReplicaslabel.Text = "readyReplicas";
            // 
            // labelReadyReplicas
            // 
            this.labelReadyReplicas.AutoSize = true;
            this.labelReadyReplicas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReadyReplicas.Location = new System.Drawing.Point(9, 267);
            this.labelReadyReplicas.Name = "labelReadyReplicas";
            this.labelReadyReplicas.Size = new System.Drawing.Size(124, 20);
            this.labelReadyReplicas.TabIndex = 19;
            this.labelReadyReplicas.Text = "Ready Replicas:";
            // 
            // updatedReplicaslabel
            // 
            this.updatedReplicaslabel.AutoSize = true;
            this.updatedReplicaslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updatedReplicaslabel.Location = new System.Drawing.Point(151, 296);
            this.updatedReplicaslabel.Name = "updatedReplicaslabel";
            this.updatedReplicaslabel.Size = new System.Drawing.Size(129, 20);
            this.updatedReplicaslabel.TabIndex = 22;
            this.updatedReplicaslabel.Text = "updatedReplicas";
            // 
            // labelUpdatedReplicas
            // 
            this.labelUpdatedReplicas.AutoSize = true;
            this.labelUpdatedReplicas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUpdatedReplicas.Location = new System.Drawing.Point(9, 296);
            this.labelUpdatedReplicas.Name = "labelUpdatedReplicas";
            this.labelUpdatedReplicas.Size = new System.Drawing.Size(140, 20);
            this.labelUpdatedReplicas.TabIndex = 21;
            this.labelUpdatedReplicas.Text = "Updated Replicas:";
            // 
            // replicaslabel
            // 
            this.replicaslabel.AutoSize = true;
            this.replicaslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.replicaslabel.Location = new System.Drawing.Point(85, 325);
            this.replicaslabel.Name = "replicaslabel";
            this.replicaslabel.Size = new System.Drawing.Size(63, 20);
            this.replicaslabel.TabIndex = 24;
            this.replicaslabel.Text = "replicas";
            // 
            // labelReplicas
            // 
            this.labelReplicas.AutoSize = true;
            this.labelReplicas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReplicas.Location = new System.Drawing.Point(9, 325);
            this.labelReplicas.Name = "labelReplicas";
            this.labelReplicas.Size = new System.Drawing.Size(74, 20);
            this.labelReplicas.TabIndex = 23;
            this.labelReplicas.Text = "Replicas:";
            // 
            // observedGenerationlabel
            // 
            this.observedGenerationlabel.AutoSize = true;
            this.observedGenerationlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.observedGenerationlabel.Location = new System.Drawing.Point(180, 354);
            this.observedGenerationlabel.Name = "observedGenerationlabel";
            this.observedGenerationlabel.Size = new System.Drawing.Size(154, 20);
            this.observedGenerationlabel.TabIndex = 26;
            this.observedGenerationlabel.Text = "observedGeneration";
            // 
            // labelObservedGeneration
            // 
            this.labelObservedGeneration.AutoSize = true;
            this.labelObservedGeneration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelObservedGeneration.Location = new System.Drawing.Point(9, 354);
            this.labelObservedGeneration.Name = "labelObservedGeneration";
            this.labelObservedGeneration.Size = new System.Drawing.Size(165, 20);
            this.labelObservedGeneration.TabIndex = 25;
            this.labelObservedGeneration.Text = "Observed Generation:";
            // 
            // labelcontainerNamesListBox
            // 
            this.labelcontainerNamesListBox.AutoSize = true;
            this.labelcontainerNamesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelcontainerNamesListBox.Location = new System.Drawing.Point(10, 410);
            this.labelcontainerNamesListBox.Name = "labelcontainerNamesListBox";
            this.labelcontainerNamesListBox.Size = new System.Drawing.Size(147, 20);
            this.labelcontainerNamesListBox.TabIndex = 27;
            this.labelcontainerNamesListBox.Text = "Lista de containers:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 533);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 28;
            this.label1.Text = "Lista de envs:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.labelDe);
            this.panel1.Controls.Add(this.labelDeploymentName);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 49);
            this.panel1.TabIndex = 29;
            // 
            // labelTimeAgo
            // 
            this.labelTimeAgo.AutoSize = true;
            this.labelTimeAgo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimeAgo.Location = new System.Drawing.Point(169, 381);
            this.labelTimeAgo.Name = "labelTimeAgo";
            this.labelTimeAgo.Size = new System.Drawing.Size(66, 20);
            this.labelTimeAgo.TabIndex = 31;
            this.labelTimeAgo.Text = "timeago";
            // 
            // labeltempodeCriacao
            // 
            this.labeltempodeCriacao.AutoSize = true;
            this.labeltempodeCriacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeltempodeCriacao.Location = new System.Drawing.Point(9, 381);
            this.labeltempodeCriacao.Name = "labeltempodeCriacao";
            this.labeltempodeCriacao.Size = new System.Drawing.Size(158, 20);
            this.labeltempodeCriacao.TabIndex = 30;
            this.labeltempodeCriacao.Text = "Tempo de existência:";
            // 
            // deploymentDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(584, 661);
            this.Controls.Add(this.labelTimeAgo);
            this.Controls.Add(this.labeltempodeCriacao);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelcontainerNamesListBox);
            this.Controls.Add(this.observedGenerationlabel);
            this.Controls.Add(this.labelObservedGeneration);
            this.Controls.Add(this.replicaslabel);
            this.Controls.Add(this.labelReplicas);
            this.Controls.Add(this.updatedReplicaslabel);
            this.Controls.Add(this.labelUpdatedReplicas);
            this.Controls.Add(this.readyReplicaslabel);
            this.Controls.Add(this.labelReadyReplicas);
            this.Controls.Add(this.availableReplicaslabel);
            this.Controls.Add(this.labelAvailableReplicas);
            this.Controls.Add(this.labeldnspolicy);
            this.Controls.Add(this.labeldns);
            this.Controls.Add(this.labelgraceperiod);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelrestartpolicy);
            this.Controls.Add(this.labelrestart);
            this.Controls.Add(this.managerlabel);
            this.Controls.Add(this.labelmanager);
            this.Controls.Add(this.labelnamespacename);
            this.Controls.Add(this.labelnamespace);
            this.Controls.Add(this.labelnome);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.envNamesListBox);
            this.Controls.Add(this.containerNamesListBox);
            this.Name = "deploymentDetailsForm";
            this.Text = "deploymentDetailsForm";
            this.Load += new System.EventHandler(this.deploymentDetailsForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDe;
        private System.Windows.Forms.Label labelDeploymentName;
        private System.Windows.Forms.ListBox containerNamesListBox;
        private System.Windows.Forms.ListBox envNamesListBox;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelnome;
        private System.Windows.Forms.Label labelnamespace;
        private System.Windows.Forms.Label labelnamespacename;
        private System.Windows.Forms.Label managerlabel;
        private System.Windows.Forms.Label labelmanager;
        private System.Windows.Forms.Label labelrestartpolicy;
        private System.Windows.Forms.Label labelrestart;
        private System.Windows.Forms.Label labelgraceperiod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labeldnspolicy;
        private System.Windows.Forms.Label labeldns;
        private System.Windows.Forms.Label availableReplicaslabel;
        private System.Windows.Forms.Label labelAvailableReplicas;
        private System.Windows.Forms.Label readyReplicaslabel;
        private System.Windows.Forms.Label labelReadyReplicas;
        private System.Windows.Forms.Label updatedReplicaslabel;
        private System.Windows.Forms.Label labelUpdatedReplicas;
        private System.Windows.Forms.Label replicaslabel;
        private System.Windows.Forms.Label labelReplicas;
        private System.Windows.Forms.Label observedGenerationlabel;
        private System.Windows.Forms.Label labelObservedGeneration;
        private System.Windows.Forms.Label labelcontainerNamesListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTimeAgo;
        private System.Windows.Forms.Label labeltempodeCriacao;
    }
}