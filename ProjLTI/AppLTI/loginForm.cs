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
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;
using Renci.SshNet;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Net.Http.Headers;
using OpenQA.Selenium;
using System.Web.Routing;

namespace AppLTI
{
    public partial class loginForm : Form
    {
        private List<Credential> credentials;

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

        private async Task<bool> VerifyAPI(string maquinaIP, string portoAPI, string authToken)
        {
            try
            {
                string url = $"https://{maquinaIP}:{portoAPI}/api";

                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            #pragma warning disable CS0168
            catch (Exception ex)
            {
                return false;
            }
            #pragma warning restore CS0168
        }

        private async Task sshConnection(string routerIp, string portoSSH, string username, string password, string portoAPI)
        {
            try
            {
                using (var client = new SshClient(routerIp, int.Parse(portoSSH), username, password))
                {
                    try
                    {
                        client.Connect();
                        if (client.IsConnected)
                        {
                            var tokenCommand = $"echo '{password}' | sudo -S kubectl -n kube-system  create token admin-user";
                            var tokenResult = client.RunCommand(tokenCommand);

                            if (tokenResult.ExitStatus != 0)
                            {
                                //Console.WriteLine("Falha na execução do comando para guardar o token.");
                                MessageBox.Show("Erro a obter o token - Login falhou.");
                                return;
                            }

                            var authToken = tokenResult.Result.Trim();

                            client.Disconnect();

                            bool flagVerifyAPI = await VerifyAPI(routerIp, portoAPI, authToken);

                            if (flagVerifyAPI)
                            {

                                bool flagPassword = checkBoxGuardarPassword.Checked;

                                Credential credential = new Credential
                                {
                                    Ip = routerIp,
                                    Username = username,
                                    Password = flagPassword ? Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password)) : null,
                                    Porto_ssh = portoSSH,
                                    Porto_api = portoAPI,
                                };

                                var request = new RestRequest("api/credentials", Method.Post);
                                request.RequestFormat = DataFormat.Json;
                                request.AddObject(credential);

                                var responseRequest = restClient.Execute(request);

                                if (responseRequest.StatusCode != HttpStatusCode.OK)
                                {
                                    MessageBox.Show("Erro Interno - Login Falhou.");
                                    return;
                                }

                                mainPage mainPageForm = new mainPage();
                                checkBoxGuardarPassword.Checked = false;
                                clearTextBoxes();
                                mainPageForm.SetCredentials(routerIp.Trim(), username, password, portoSSH, portoAPI, authToken);
                                mainPageForm.Show();
                                MessageBox.Show("Login efetuado com sucesso!");
                                listCredentials();
                            }
                            else
                            {
                                MessageBox.Show("Porto API incorreto - Login falhou.");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Verifique as credenciais - Login falhou.");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Credenciais incorretas - Login falhou.");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro - Login falhou");
                return;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Login(textBoxRouterIP.Text, textBoxUsername.Text, textBoxPassword.Text, textBoxPortoSSH.Text, textBoxPortoAPI.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
            }
        }

        private async void Login(string routerIp, string username, string password, string portoSSH, string portoAPI)
        {
            if (routerIp == "")
            {
                MessageBox.Show("Preencha o ip do server.");
                return;
            }

            string pattern = @"^(0|[1-9]\d{0,3}|[1-5]\d{4}|6[0-4]\d{3}|65[0-4]\d{2}|655[0-2]\d|6553[0-5])$";

            if (portoSSH == "")
            {
                MessageBox.Show("Preencha o porto SSH do ip do server.");
                return;

            }else if(!Regex.IsMatch(portoSSH, pattern))
            {
                MessageBox.Show("O porto SSH tem o formato incorreto.");
                return;
            }

            if (portoAPI == "")
            {
                MessageBox.Show("Preencha o porto API do ip do server.");
                return;

            }
            else if (!Regex.IsMatch(portoAPI, pattern))
            {
                MessageBox.Show("O porto API tem o formato incorreto.");
                return;
            }

            if (username == "")
            {
                MessageBox.Show("Preencha o username.");
                return;
            }

            if (password == "")
            {
                MessageBox.Show("Preencha a password.");
                return;
            }

            await sshConnection(routerIp, portoSSH, username, password, portoAPI);
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
            textBoxPortoSSH.Clear();
            textBoxPortoAPI.Clear();
        }

    }
}
