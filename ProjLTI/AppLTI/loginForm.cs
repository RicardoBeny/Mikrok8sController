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

namespace AppLTI
{
    public partial class loginForm : Form
    {
        private List<Credential> credentials;
        private string authToken;

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
                Login(textBoxRouterIP.Text, textBoxUsername.Text, textBoxPassword.Text, textBoxPorto.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
            }
        }

        private async void Login(string routerIp, string username, string password, string porto)
        {
            if (routerIp == "" || username == "" || password == "" || porto == "")
            {
                return;
            }

            try
            {
                using (var client = new SshClient(routerIp, porto, username, password))
                {
                    try
                    {
                        client.Connect();
                        if (client.IsConnected)
                        {
                            // Execute the first command to get the token
                            var tokenCommand = $"echo '{password}' | sudo -S microk8s kubectl -n kube-system get secret | grep default-token | cut -d \" \" -f1";
                            var tokenResult = client.RunCommand(tokenCommand);

                            // Execute the second command using the extracted token
                            var describeCommand = $"echo '{password}' | sudo -S microk8s kubectl -n kube-system describe secret $token | awk '/^token:/ {{print $2}}'";
                            var describeResult = client.RunCommand(describeCommand);

                            // Print the result of the second command
                            authToken = describeResult.Result;

                            // Disconnect from the SSH session
                            client.Disconnect();
                        }
                        else
                        {
                            MessageBox.Show("Login falhou, verifica as Credenciais e tenta de novo.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            mainPage mainPageForm = new mainPage();
            checkBoxGuardarCredencias.Checked = false;
            clearTextBoxes();
            mainPageForm.SetCredentials(routerIp, username, password, porto);
            mainPageForm.Show();
            MessageBox.Show("Login efetuado com sucesso!");
            listCredentials();
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

                credentials = JsonConvert.DeserializeObject<List<Credential>>(responseCredentials.Content);

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

            Credential selectedRouter = credentials.FirstOrDefault(r => r.Username + " - " + r.Ip + " (" + r.Id + ")" == selectedItem);

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
            textBoxPorto.Clear();
        }

    }
}
