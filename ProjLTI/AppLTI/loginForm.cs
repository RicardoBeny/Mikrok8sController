using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;
using Newtonsoft.Json;
using Renci.SshNet;

namespace AppLTI
{
    public partial class loginForm : Form
    {
        private List<Router> credentials;

        string baseURI = @"http://localhost:11755";
        RestClient restClient = null;
        public loginForm()
        {
            InitializeComponent();
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;

            var request = new RestRequest("/api/credentials", Method.Get);
            request.RequestFormat = DataFormat.Json;

            restClient = new RestClient(baseURI);

            //popular a dropdown com os 10 ip's mais recentes
            listCredentials();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Login(textBoxRouterIP.Text, textBoxUsername.Text, textBoxPassword.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
            }
        }

        private async void Login(string routerIp, string username, string password)
        {
            if (routerIp == "" || username == "" || password == "")
            {
                return;
            }

            using (var client = new SshClient(routerIp, 1022, username, password))
            {
                client.Connect();

                if (client.IsConnected)
                {
                    Console.WriteLine("SSH Connection established.");

                    var shellStream = client.CreateShellStream("xterm", 80, 24, 800, 600, 1024);

                    WaitShellPrompt(shellStream);

                    shellStream.WriteLine("sudo -S -p ''");
                    WaitShellPrompt(shellStream);

                    shellStream.WriteLine(password);
                    WaitShellPrompt(shellStream);

                    string tokenCommand = "token=$(microk8s kubectl -n kube-system get secret | grep default-token | cut -d \" \" -f1); " +
                                          "microk8s kubectl -n kube-system describe secret $token | awk '/^token:/ {print $2}'";
                    shellStream.WriteLine(tokenCommand);
                    WaitShellPrompt(shellStream);

                    string output = shellStream.Read();
                    MessageBox.Show(output);

                    client.Disconnect();
                    Console.WriteLine("SSH Connection disconnected.");
                }
                else
                {
                    Console.WriteLine("Failed to establish SSH connection.");
                }
            }

        }

        private void WaitShellPrompt(ShellStream shellStream)
        {
            string prompt = "";
            while (!prompt.Trim().EndsWith("$") && !prompt.Trim().EndsWith("#"))
            {
                prompt += (char)shellStream.ReadByte();
            }
        }

        private void buttonSeePassword_Click(object sender, EventArgs e)
        {

            if (textBoxPassword.PasswordChar == '•')
            {
                buttonHidePassword.BringToFront();
                textBoxPassword.PasswordChar = '\0';
            }
        }

        private void buttonHidePassword_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.PasswordChar == '\0')
            {
                buttonSeePassword.BringToFront();
                textBoxPassword.PasswordChar = '•';
            }
        }

        private void listCredentials()
        {
            var requestCredentials = new RestRequest("api/credentials", Method.Get);
            requestCredentials.RequestFormat = DataFormat.Json;
            requestCredentials.AddHeader("Accept", "application/json");

            var responseCredentials = restClient.Execute(requestCredentials);

            if (responseCredentials.IsSuccessful)
            {
                comboBoxRoutersIP.Items.Clear();

                credentials = JsonConvert.DeserializeObject<List<Router>>(responseCredentials.Content);

                foreach (var router in credentials)
                {
                    comboBoxRoutersIP.Items.Add(router.Username + " - " + router.Ip + " (" + router.Id + ")");
                }
            }
        }

        private void comboBoxRoutersIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBoxRoutersIP.SelectedItem.ToString();

            if (selectedItem == "")
            {
                clearTextBoxes();
                return;
            }

            Router selectedRouter = credentials.FirstOrDefault(r => r.Username + " - " + r.Ip + " (" + r.Id + ")" == selectedItem);

            if (selectedRouter != null)
            {
                //textBoxRouterIP.Text = selectedRouter.Ip;
                textBoxRouterIP.Text = selectedRouter.Ip;
                textBoxUsername.Text = selectedRouter.Username;
                textBoxPassword.Text = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(selectedRouter.Password));
            }
        }

        private void clearTextBoxes()
        {
            textBoxRouterIP.Clear();
            textBoxUsername.Clear();
            textBoxPassword.Clear();
        }

    }
}
