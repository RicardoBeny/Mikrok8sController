using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppLTI
{
    public partial class deploymentPortForm : Form
    {
        private string routerIp;
        private string username;
        private string password;
        private string portoSSH;
        private string portoAPI;
        private string authKey;
        private string namespacename;
        private string deploymentName;

        public deploymentPortForm()
        {
            InitializeComponent();
        }

        public void SetCredentials(string routerIp, string username, string password, string portoSSH, string portoAPI, string authKey, string namespacename, string deploymentName)
        {
            this.routerIp = routerIp;
            this.username = username;
            this.password = password;
            this.portoSSH = portoSSH;
            this.portoAPI = portoAPI;
            this.authKey = authKey;
            this.namespacename = namespacename;
            this.deploymentName = deploymentName;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPorto.Text))
            {
                MessageBox.Show("Campo porto tem de ser preenchido.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxReplicas.Text))
            {
                MessageBox.Show("Campo replica tem de ser preenchido.");
                return;
            }

            deploymentImageForm deploymentImageForm = new deploymentImageForm();
            deploymentImageForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey, namespacename, deploymentName, textBoxReplicas.Text, textBoxPorto.Text);
            deploymentImageForm.Show();
            this.Dispose();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            deploymentNameForm deploymentNameForm = new deploymentNameForm();
            deploymentNameForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            deploymentNameForm.Show();
            this.Dispose();
        }
    }
}
