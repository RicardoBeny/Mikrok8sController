using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Renci.SshNet;

namespace AppLTI
{
    public partial class sshMikrotik : Form
    {
        private string routerIp;
        private string username;
        private string password;
        private Timer timer;

        public sshMikrotik()
        {
            InitializeComponent();
        }

        public void SetCredentials(string routerIp, string username, string password)
        {
            this.routerIp = routerIp;
            this.username = username;
            this.password = password;
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

            using (var client = new SshClient(routerIp, username, password))
            {
                client.Connect();

                if (client.IsConnected)
                {
                    Console.WriteLine("Conexão SSH estabelecida.");

                    string command = textBoxCommand.Text.Trim();

                    var result = client.RunCommand(command);

                    string output = $"[{username}@{routerIp}] > {command}{Environment.NewLine}{result.Result}{Environment.NewLine}";

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

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxResult.Clear();
        }
    }
}
