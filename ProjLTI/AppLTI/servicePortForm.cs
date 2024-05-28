using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AppLTI
{
    public partial class servicePortForm : Form
    {
        private string routerIp;
        private string portoAPI;
        private string authKey;
        private string label;
        private string namespacename;
        private string servicename;
        private string portoDeployment;

        public servicePortForm()
        {
            InitializeComponent();
        }

        public void SetCredentials(string routerIp, string portoAPI, string authKey, string label, string servicename, string namespacename, string portoDeployment)
        {
            this.routerIp = routerIp;
            this.portoAPI = portoAPI;
            this.authKey = authKey;
            this.label = label;
            this.servicename = servicename;
            this.namespacename = namespacename;
            this.servicename = servicename;
            this.portoDeployment = portoDeployment;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPorto.Text))
            {
                MessageBox.Show("Campo porto tem de ser preenchido.");
                return;
            }

            serviceTypeForm serviceTypeForm = new serviceTypeForm();
            serviceTypeForm.SetCredentials(routerIp, portoAPI, authKey, label, servicename, namespacename, textBoxPorto.Text, portoDeployment);
            serviceTypeForm.Show();
            this.Dispose();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            serviceNameForm serviceNameForm = new serviceNameForm();
            serviceNameForm.SetCredentials(routerIp, portoAPI, authKey, label, namespacename, portoDeployment);
            serviceNameForm.Show();
            this.Dispose();
        }
    }
}
