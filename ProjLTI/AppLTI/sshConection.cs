using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Renci.SshNet;

namespace AppLTI
{
    public partial class sshConection : Form
    {
        private string routerIp;
        private string username;
        private string password;
        private string portoSSH;
        private string portoAPI;
        private string authKey;

        public sshConection()
        {
            InitializeComponent();
        }

        public void SetCredentials(string routerIp, string username, string password, string portoSSH, string portoAPI, string authKey)
        {
            this.routerIp = routerIp;
            this.username = username;
            this.password = password;
            this.portoSSH = portoSSH;
            this.portoAPI = portoAPI;
            this.authKey = authKey;
        }

        private void btnSensCommand_Click(object sender, EventArgs e)
        {
            SendCommand();
        }

        private void textBoxCommand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;

                SendCommand();
            }
        }

        private void SendCommand()
        {
            if (string.IsNullOrWhiteSpace(textBoxCommand.Text))
            {
                MessageBox.Show("Input deve ser preenchido.");
                return;
            }

            using (var client = new SshClient(routerIp, int.Parse(portoSSH), username, password))
            {
                client.Connect();

                if (client.IsConnected)
                {
                    Console.WriteLine("Conexão SSH estabelecida.");

                    string command = textBoxCommand.Text.Trim();

                    var result = client.RunCommand(command);

                    string output = $"{username}@{username}:$ {command}{Environment.NewLine}{result.Result}{Environment.NewLine}";

                    textBoxResult.AppendText(output);

                    textBoxResult.SelectionStart = textBoxResult.Text.Length;
                    textBoxResult.ScrollToCaret();

                    client.Disconnect();
                    Console.WriteLine("Conexão SSH desconectada.");
                }
                else
                {
                    Console.WriteLine("Falha ao estabelecer a conexão SSH.");
                }
            }
        }

        private void sshMikrotik_Load(object sender, EventArgs e)
        {
            textBoxIP.Text = username + " - " + routerIp + ":" + portoSSH;
            textBoxCommand.KeyPress += textBoxCommand_KeyPress;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxResult.Clear();
        }

        private void buttonPods_Click(object sender, EventArgs e)
        {
            podsForm podsForm = new podsForm();
            podsForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            podsForm.Show();
            this.Dispose();
        }

        private void buttonDeployments_Click(object sender, EventArgs e)
        {
            deploymentsForm deploymentsForm = new deploymentsForm();
            deploymentsForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            deploymentsForm.Show();
            this.Dispose();
        }

        private void buttonServices_Click(object sender, EventArgs e)
        {

        }

        private void buttonNameSpaces_Click(object sender, EventArgs e)
        {
            namespacesForm namespacesForm = new namespacesForm();
            namespacesForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            namespacesForm.Show();
            this.Dispose();
        }

        private void buttonNodes_Click(object sender, EventArgs e)
        {
            nodesForm nodesForm = new nodesForm();
            nodesForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            nodesForm.Show();
            this.Dispose();
        }
    }
}
