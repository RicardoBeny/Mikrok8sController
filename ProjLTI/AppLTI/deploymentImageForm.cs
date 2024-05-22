using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppLTI
{
    public partial class deploymentImageForm : Form
    {
        private string routerIp;
        private string username;
        private string password;
        private string portoSSH;
        private string portoAPI;
        private string authKey;
        private string namespacename;
        private string deploymentName;
        private string replicas;
        private string porto;
        private deploymentsForm parentForm;

        public deploymentImageForm()
        {
            InitializeComponent();
        }

        public void SetCredentials(string routerIp, string username, string password, string portoSSH, string portoAPI, string authKey, string namespacename, string deploymentName, string replicas, string porto, deploymentsForm parentForm)
        {
            this.routerIp = routerIp;
            this.username = username;
            this.password = password;
            this.portoSSH = portoSSH;
            this.portoAPI = portoAPI;
            this.authKey = authKey;
            this.namespacename = namespacename;
            this.deploymentName = deploymentName;
            this.replicas = replicas;
            this.porto = porto;
            this.parentForm = parentForm;
        }

        private async void buttonFinish_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxContainerName.Text))
            {
                MessageBox.Show("Campo container name tem de ser preenchido.");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxLabelApp.Text))
            {
                MessageBox.Show("Campo label app tem de ser preenchido.");
                return;
            }
            if (comboBoxImage.SelectedIndex == -1)
            {
                MessageBox.Show("Imagem tem de ser selecionada.");
                return;
            }

            await CreateDeployment(routerIp, portoAPI, authKey, namespacename, deploymentName, replicas, porto);
        }
        private async Task CreateDeployment(string routerIp, string portoAPI, string authToken, string namespacename, string deploymentName, string replicas, string porto)
        {
            int portonovo = int.Parse(porto);
            int replicasnova = int.Parse(replicas);

            var requestBody = new JObject
            {
                ["apiVersion"] = "apps/v1",
                ["kind"] = "Deployment",
                ["metadata"] = new JObject
                {
                    ["name"] = deploymentName,
                    ["namespace"] = namespacename
                },
                ["spec"] = new JObject
                {
                    ["replicas"] = replicasnova,
                    ["selector"] = new JObject
                    {
                        ["matchLabels"] = new JObject
                        {
                            ["app"] = textBoxLabelApp.Text
                        }
                    },
                    ["template"] = new JObject
                    {
                        ["metadata"] = new JObject
                        {
                            ["labels"] = new JObject
                            {
                                ["app"] = textBoxLabelApp.Text
                            }
                        },
                        ["spec"] = new JObject
                        {
                            ["containers"] = new JArray
                        {
                            new JObject
                            {
                                ["name"] = textBoxContainerName.Text,
                                ["image"] = comboBoxImage.SelectedItem.ToString(),
                                ["ports"] = new JArray
                                {
                                    new JObject
                                    {
                                        ["containerPort"] = portonovo
                                    }
                                }
                            }
                        }
                        }
                    }
                }
            };

            try
            {
                string url = $"https://{routerIp}:{portoAPI}/apis/apps/v1/namespaces/{namespacename}/deployments";

                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Deployment created successfully.");
                        await parentForm.LoadDeployments(routerIp, portoAPI, authToken, namespacename);
                        this.Dispose();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Failed to create Deployment. Error message: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while creating Deployment: " + ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            deploymentPortForm deploymentPortForm = new deploymentPortForm();
            deploymentPortForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey, namespacename, deploymentName, parentForm);
            deploymentPortForm.Show();
            this.Dispose();
        }
    }
}
