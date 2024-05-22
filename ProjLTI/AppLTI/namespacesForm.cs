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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AppLTI
{
    public partial class namespacesForm : Form
    {
        private string routerIp;
        private string username;
        private string password;
        private string portoSSH;
        private string portoAPI;
        private string authKey;
        public namespacesForm()
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

        private void namespacesForm_Load(object sender, EventArgs e)
        {
            textBoxIP.Text = username + " - " + routerIp + ":" + portoSSH;
        }

        private async void buttonListarNamespaces_Click(object sender, EventArgs e)
        {
            await LoadNamespaces(routerIp, portoAPI, authKey);
        }

        private async Task LoadNamespaces(string routerIp, string portoAPI, string authToken)
        {
            try
            {
                listBoxNamespaces.Items.Clear();
                comboBoxNamespaces.Items.Clear();

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

                        listBoxNamespaces.Items.Add("Name\t\t\tPhase\t\tCreated");

                        foreach (JObject namespaceObject in namespacesArray)
                        {
                            string name = (string)namespaceObject["metadata"]["name"];
                            string phase = (string)namespaceObject["status"]["phase"];
                            string created = (string)namespaceObject["metadata"]["creationTimestamp"];

                            DateTime creationDateTime = DateTime.ParseExact(created, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                            TimeSpan timeSinceCreation = DateTime.Now - creationDateTime;
                            string timeAgo = $"{(int)timeSinceCreation.TotalDays} d, {(int)timeSinceCreation.Hours} h, {(int)timeSinceCreation.Minutes} m ago";

                            int nameColumn = name.Length;

                            if(nameColumn > 17)
                            {
                                listBoxNamespaces.Items.Add($"{name}\t{phase}\t\t{timeAgo}");
                                comboBoxNamespaces.Items.Add($"Nome: {name}");
                            }
                            else if (nameColumn < 9)
                            {
                                listBoxNamespaces.Items.Add($"{name}\t\t\t{phase}\t\t{timeAgo}");
                                comboBoxNamespaces.Items.Add($"Nome: {name}");
                            }
                            else
                            {
                                listBoxNamespaces.Items.Add($"{name}\t\t{phase}\t\t{timeAgo}");
                                comboBoxNamespaces.Items.Add($"Nome: {name}");
                            }
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Failed to load namespaces. Error message: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading namespaces: " + ex.Message);
            }
        }

        private async void buttonCreateNamespace_Click(object sender, EventArgs e)
        {
            await CreateNamespaces(routerIp, portoAPI, authKey);
        }

        private async Task CreateNamespaces(string routerIp, string portoAPI, string authToken)
        {
            if (string.IsNullOrWhiteSpace(textBoxNomeAdd.Text))
            {
                MessageBox.Show("Campo nome tem de ser preenchido.");
                return;
            }

            var requestBody = new JObject();
            requestBody["apiVersion"] = "v1";
            requestBody["kind"] = "Namespace";

            var metadata = new JObject();
            metadata["name"] = textBoxNomeAdd.Text;
            requestBody["metadata"] = metadata;

            try
            {
                listBoxNamespaces.Items.Clear();

                string url = $"https://{routerIp}:{portoAPI}/api/v1/namespaces";

                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Namespace adicionado com sucesso.");
                        await LoadNamespaces(routerIp, portoAPI, authToken);
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao adicionar namespace . Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao adicionar namespace: " + ex.Message);
            }
        }

        private async void buttonDeleteNamespace_Click(object sender, EventArgs e)
        {
            if (comboBoxNamespaces.SelectedIndex == -1)
            {
                MessageBox.Show("Namespace tem de ser selecionada.");
                return;
            }

            string selectedItemText = comboBoxNamespaces.Items[comboBoxNamespaces.SelectedIndex].ToString();
            string namespacename = selectedItemText.Substring(selectedItemText.IndexOf("Nome:") + 5).Split(';')[0].Trim();

            await DeleteNamespace(routerIp, portoAPI, authKey, namespacename);
        }

        private async Task DeleteNamespace(string routerIp, string portoAPI, string authToken, string namespaceName)
        {
            try
            {
                string url = $"https://{routerIp}:{portoAPI}/api/v1/namespaces/{namespaceName}";

                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                    HttpResponseMessage response = await client.DeleteAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Namespace eliminado com sucesso.");
                        await LoadNamespaces(routerIp, portoAPI, authToken);
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao eliminar namespace. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao eliminar namespace: " + ex.Message);
            }
        }

        private void btnTerminal_Click(object sender, EventArgs e)
        {
            sshConection sshConection = new sshConection();
            sshConection.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            sshConection.Show();
            this.Dispose();
        }

        private void buttonNodes_Click(object sender, EventArgs e)
        {
            nodesForm nodesForm = new nodesForm();
            nodesForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            nodesForm.Show();
            this.Dispose();
        }
        
        private void buttonServices_Click(object sender, EventArgs e)
        {
            servicesForm servicesForm = new servicesForm();
            servicesForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            servicesForm.Show();
            this.Dispose();
        }

        private void buttonDeployments_Click(object sender, EventArgs e)
        {
            deploymentsForm deploymentsForm = new deploymentsForm();
            deploymentsForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey, deploymentsForm);
            deploymentsForm.Show();
            this.Dispose();
        }

        private void buttonPods_Click(object sender, EventArgs e)
        {
            podsForm podsForm = new podsForm();
            podsForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            podsForm.Show();
            this.Dispose();
        }

        private void buttonIngress_Click(object sender, EventArgs e)
        {
            ingressForm ingressForm = new ingressForm();
            ingressForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            ingressForm.Show();
            this.Dispose();
        }
    }
}
