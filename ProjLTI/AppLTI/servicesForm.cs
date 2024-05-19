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
    public partial class servicesForm : Form
    {
        private string routerIp;
        private string username;
        private string password;
        private string portoSSH;
        private string portoAPI;
        private string authKey;

        public servicesForm()
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

        private async void servicesForm_Load(object sender, EventArgs e)
        {
            textBoxIP.Text = username + " - " + routerIp + ":" + portoSSH;
            await LoadNamespaces(routerIp, portoAPI, authKey);
        }

        private async Task LoadNamespaces(string routerIp, string portoAPI, string authToken)
        {
            try
            {
                comboBoxNamespaces.Items.Clear();
                comboBoxNamespaceCriar.Items.Clear();


                string url = $"https://{routerIp}:{portoAPI}/api/v1/namespaces";

                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        JObject namespacesData = JObject.Parse(responseBody);
                        JArray namespacesArray = (JArray)namespacesData["items"];

                        comboBoxNamespaces.Items.Add("Todos");

                        foreach (JObject namespaceObject in namespacesArray)
                        {
                            string name = (string)namespaceObject["metadata"]["name"];
                            comboBoxNamespaces.Items.Add($"{name}");
                            comboBoxNamespaceCriar.Items.Add($"{name}");
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao carregar os namespaces. Erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar os namespaces: " + ex.Message);
            }
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
            deploymentsForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey, deploymentsForm);
            deploymentsForm.Show();
            this.Dispose();
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

        private void btnTerminal_Click(object sender, EventArgs e)
        {
            sshConection sshConection = new sshConection();
            sshConection.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            sshConection.Show();
            this.Dispose();
        }

        private async void buttonDeleteService_Click(object sender, EventArgs e)
        {
            if (comboBoxNamespaces.SelectedIndex == -1 || (string)comboBoxNamespaces.SelectedItem == "Todos")
            {
                MessageBox.Show("Por favor selecione um namespace.");
                return;
            }

            string selectedItemText = comboBoxNamespaces.Items[comboBoxNamespaces.SelectedIndex].ToString();
            string namespacename = selectedItemText.Trim();

            if (comboBoxService.SelectedIndex == -1)
            {
                MessageBox.Show("Serviço tem de ser selecionado.");
                return;
            }

            string selectedItemText1 = comboBoxService.Items[comboBoxService.SelectedIndex].ToString();
            string deploymentname = selectedItemText1.Substring(selectedItemText1.IndexOf("Nome:") + 5).Split(';')[0].Trim();
            await DeleteService(routerIp, portoAPI, authKey, namespacename, deploymentname);
        }

        private async Task DeleteService(string routerIp, string portoAPI, string authToken, string namespacename, string servicename)
        {
            try
            {
                string url = $"https://{routerIp}:{portoAPI}/api/v1/namespaces/{namespacename}/services/{servicename}";

                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                    HttpResponseMessage response = await client.DeleteAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Service deleted successfully.");
                        await LoadServices(routerIp, portoAPI, authToken, namespacename);
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Failed to delete Service. Error message: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the Service: " + ex.Message);
            }
        }


        private async void comboBoxNamespaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxNamespaces.SelectedIndex == -1)
            {
                MessageBox.Show("Namespace tem de ser selecionada.");
                return;
            }

            string selectedItemText = comboBoxNamespaces.Items[comboBoxNamespaces.SelectedIndex].ToString();
            string namespacename = selectedItemText.Trim();

            await LoadServices(routerIp, portoAPI, authKey, namespacename);
        }

        private async Task LoadServices(string routerIp, string portoAPI, string authToken, string namespacename)
        {
            try
            {
                string url;
                listBoxService.Items.Clear();
                comboBoxService.Items.Clear();

                if (namespacename == "Todos")
                {
                    url = $"https://{routerIp}:{portoAPI}/api/v1/services";
                }
                else
                {
                    url = $"https://{routerIp}:{portoAPI}/api/v1/namespaces/{namespacename}/services";
                }
                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        JObject servicesData = JObject.Parse(responseBody);
                        JArray servicesArray = (JArray)servicesData["items"];

                        int maxNameLength = 0;
                        foreach (JObject serviceObject in servicesArray)
                        {
                            string name = (string)serviceObject["metadata"]["name"];
                            maxNameLength = Math.Max(maxNameLength, name.Length);
                        }

                        string nameHeader = "Service  Name".PadRight(maxNameLength);

                        listBoxService.Items.Add($"{nameHeader}\t\tCluster IP\t\tType\t\tNamespace\t\t\tCreated");

                        foreach (JObject serviceObject in servicesArray)
                        {
                            string name = (string)serviceObject["metadata"]["name"];
                            string clusterIP = (string)serviceObject["spec"]["clusterIP"];
                            string type = (string)serviceObject["spec"]["type"];
                            string namespaceName = (string)serviceObject["metadata"]["namespace"];
                            string creationTimestamp = (string)serviceObject["metadata"]["creationTimestamp"];

                            DateTime creationDateTime = DateTime.ParseExact(creationTimestamp, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                            TimeSpan timeSinceCreation = DateTime.Now - creationDateTime;
                            string timeAgo = $"{(int)timeSinceCreation.TotalDays} d, {(int)timeSinceCreation.Hours} h, {(int)timeSinceCreation.Minutes} m ago";

                            listBoxService.Items.Add($"{name.PadRight(maxNameLength)}\t\t{clusterIP}\t\t{type}\t\t{namespaceName}\t\t{timeAgo}");
                            comboBoxService.Items.Add($"Nome: {name}");
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Failed to load services. Error message: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading services: " + ex.Message);
            }
        }

        private async void buttonCreateService_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNome.Text))
            {
                MessageBox.Show("Campo nome tem de ser preenchido.");
                return;
            }

            if (comboBoxNamespaceCriar.SelectedIndex == -1)
            {
                MessageBox.Show("Namespace tem de ser selecionada.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxLabelApp.Text))
            {
                MessageBox.Show("Campo label app tem de ser preenchido.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxTipo.Text))
            {
                MessageBox.Show("Campo tipo tem de ser preenchido.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxProtocolo.Text))
            {
                MessageBox.Show("Campo protocolo tem de ser preenchido.");
                return;
            }
            
            if (string.IsNullOrWhiteSpace(textBoxPorto.Text))
            {
                MessageBox.Show("Campo porto tem de ser preenchido.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxTargetPort.Text))
            {
                MessageBox.Show("Campo target port tem de ser preenchido.");
                return;
            }

            string selectedItemText = comboBoxNamespaceCriar.Items[comboBoxNamespaceCriar.SelectedIndex].ToString();
            string namespacename = selectedItemText.Trim();

            await CreateService(routerIp, portoAPI, authKey, namespacename);
        }

        private async Task CreateService(string routerIp, string portoAPI, string authToken, string namespacename)
        {
            int port = int.Parse(textBoxPorto.Text);
            int targetPort = int.Parse(textBoxTargetPort.Text);

            var requestBody = new JObject
            {
                ["apiVersion"] = "v1",
                ["kind"] = "Service",
                ["metadata"] = new JObject
                {
                    ["name"] = textBoxNome.Text,
                    ["namespace"] = namespacename,
                    ["labels"] = new JObject
                    {
                        ["app"] = textBoxLabelApp.Text
                    }
                },
                ["spec"] = new JObject
                {
                    ["selector"] = new JObject
                    {
                        ["app"] = textBoxLabelApp.Text
                    },
                    ["ports"] = new JArray
            {
                new JObject
                {
                    ["protocol"] = textBoxProtocolo.Text,
                    ["port"] = port,
                    ["targetPort"] = targetPort
                }
            },
                    ["type"] = textBoxTipo.Text
                }
            };

            try
            {
                string url = $"https://{routerIp}:{portoAPI}/api/v1/namespaces/{namespacename}/services";

                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Service created successfully.");
                        await LoadServices(routerIp, portoAPI, authToken, namespacename);
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Failed to create Service. Error message: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while creating Service: " + ex.Message);
            }
        }
    }
}
