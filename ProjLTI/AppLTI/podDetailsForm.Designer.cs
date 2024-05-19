namespace AppLTI
{
    partial class podDetailsForm
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
            this.labelPodName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.labelDe.Size = new System.Drawing.Size(47, 23);
            this.labelDe.TabIndex = 1;
            this.labelDe.Text = "Pod: ";
            // 
            // labelPodName
            // 
            this.labelPodName.AutoSize = true;
            this.labelPodName.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPodName.ForeColor = System.Drawing.Color.White;
            this.labelPodName.Location = new System.Drawing.Point(49, 12);
            this.labelPodName.Name = "labelPodName";
            this.labelPodName.Size = new System.Drawing.Size(40, 23);
            this.labelPodName.TabIndex = 2;
            this.labelPodName.Text = "pod";
            this.labelPodName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.labelDe);
            this.panel1.Controls.Add(this.labelPodName);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 49);
            this.panel1.TabIndex = 30;
            // 
            // podDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(584, 661);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "podDetailsForm";
            this.Text = "podDetailsForm";
            this.Load += new System.EventHandler(this.podDetailsForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelDe;
        private System.Windows.Forms.Label labelPodName;
        private System.Windows.Forms.Panel panel1;
    }
}