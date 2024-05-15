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
using System.Xml.Linq;

namespace AppLTI
{
    public partial class podsForm : Form
    {
        private string routerIp;
        private string username;
        private string password;
        private string portoSSH;
        private string portoAPI;
        private string authKey;

        public podsForm()
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
        private async void buttonDeletePods_Click(object sender, EventArgs e)
        {
            if (comboBoxNamespaces.SelectedIndex == -1 || (string)comboBoxNamespaces.SelectedItem == "Todos")
            {
                MessageBox.Show("Por favor selecione um namespace.");
                return;
            }

            string selectedItemText = comboBoxNamespaces.Items[comboBoxNamespaces.SelectedIndex].ToString();
            string namespacename = selectedItemText.Trim();

            if (comboBoxPods.SelectedIndex == -1)
            {
                MessageBox.Show("Pod tem de ser selecionado.");
                return;
            }

            string selectedItemText1 = comboBoxPods.Items[comboBoxPods.SelectedIndex].ToString();
            string podname = selectedItemText1.Substring(selectedItemText1.IndexOf("Nome:") + 5).Split(';')[0].Trim();
            await DeletePods(routerIp, portoAPI, authKey, namespacename, podname);
        }

        private async Task DeletePods(string routerIp, string portoAPI, string authToken, string namespaceName, string podname)
        {
            try
            {
                string url = $"https://{routerIp}:{portoAPI}/api/v1/namespaces/{namespaceName}/pods/{podname}";

                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                    HttpResponseMessage response = await client.DeleteAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Pod eliminado com sucesso.");
                        await LoadPods(routerIp, portoAPI, authToken, namespaceName);
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao eliminar o Pod. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao eliminar o Pod: " + ex.Message);
            }
        }

        private async void buttonCreateNamespace_Click(object sender, EventArgs e)
        {
            if (comboBoxNamespaces.SelectedIndex == -1)
            {
                MessageBox.Show("Namespace tem de ser selecionada.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxNomeAdd.Text))
            {
                MessageBox.Show("Campo nome tem de ser preenchido.");
                return;
            }

            if (comboBoxImage.SelectedIndex == -1)
            {
                MessageBox.Show("Imagem tem de ser selecionada.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxPorto.Text))
            {
                MessageBox.Show("Campo porto tem de ser preenchido.");
                return;
            }

            string selectedItemText = comboBoxNamespaces.Items[comboBoxNamespaces.SelectedIndex].ToString();
            string namespacename = selectedItemText.Trim();

            await CreatePods(routerIp, portoAPI, authKey, namespacename);
        }

        private async Task CreatePods(string routerIp, string portoAPI, string authToken, string namespacename)
        {
            var requestBody = new JObject();
            requestBody["apiVersion"] = "v1";
            requestBody["kind"] = "Pod";

            var metadata = new JObject();
            metadata["name"] = textBoxNomeAdd.Text;
            requestBody["metadata"] = metadata;

            var spec = new JObject();

            var containers = new JArray();
            var container = new JObject();
            container["name"] = textBoxContainerName.Text;
            container["image"] = comboBoxImage.SelectedItem.ToString();
            var ports = new JArray();
            var port = new JObject();
            port["containerPort"] = int.Parse(textBoxPorto.Text);
            ports.Add(port);
            container["ports"] = ports;
            containers.Add(container);

            spec["containers"] = containers;

            requestBody["spec"] = spec;

            try
            {
                string url = $"https://{routerIp}:{portoAPI}/api/v1/namespaces/{namespacename}/pods";

                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Pod adicionado com sucesso.");
                        await LoadPods(routerIp, portoAPI, authToken, namespacename);
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao adicionar o Pod . Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao adicionar o Pod: " + ex.Message);
            }
        }

        private async Task LoadPods(string routerIp, string portoAPI, string authToken, string namespacename)
        {
            try
            {
                string url;
                listBoxPods.Items.Clear();
                comboBoxPods.Items.Clear();

                if(namespacename == "Todos")
                {
                    url = $"https://{routerIp}:{portoAPI}/api/v1/pods";
                }
                else
                {
                    url = $"https://{routerIp}:{portoAPI}/api/v1/namespaces/{namespacename}/pods";
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

                        JObject podsData = JObject.Parse(responseBody);
                        JArray podsArray = (JArray)podsData["items"];

                        int maxNameLength = 0;
                        foreach (JObject podObject in podsArray)
                        {
                            string name = (string)podObject["metadata"]["name"];
                            maxNameLength = Math.Max(maxNameLength, name.Length);
                        }

                        string nameHeader = "Pod Name".PadRight(maxNameLength);

                        listBoxPods.Items.Add($"{nameHeader}\t\tPhase\t\tAge\t\tPod IP\t\t\tContainer Image");

                        foreach (JObject podObject in podsArray)
                        {
                            string name = (string)podObject["metadata"]["name"];
                            string phase = (string)podObject["status"]["phase"];
                            string created = (string)podObject["metadata"]["creationTimestamp"];
                            string containerImage = (podObject["status"]["containerStatuses"].FirstOrDefault()?["image"] ?? "").ToString();

                            DateTime creationDateTime = DateTime.ParseExact(created, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                            TimeSpan timeSinceCreation = DateTime.Now - creationDateTime;
                            string timeAgo = $"{(int)timeSinceCreation.TotalDays} d, {(int)timeSinceCreation.Hours} h, {(int)timeSinceCreation.Minutes} m ago";

                            string podIP = (string)podObject["status"]["podIP"];

                            int nameColumn = name.Length;

                            if(nameColumn > 32)
                            {
                                if(phase == "Succeeded")
                                {
                                    listBoxPods.Items.Add($"{name.PadRight(maxNameLength)}\t{phase}\t{timeAgo}\t{podIP}\t\t{containerImage}");
                                    comboBoxPods.Items.Add($"Nome: {name}");
                                }
                                else
                                {
                                    listBoxPods.Items.Add($"{name.PadRight(maxNameLength)}\t{phase}\t\t{timeAgo}\t{podIP}\t\t{containerImage}");
                                    comboBoxPods.Items.Add($"Nome: {name}");
                                }
                                
                            }
                            else
                            {
                                if (phase == "Succeeded")
                                {
                                    listBoxPods.Items.Add($"{name.PadRight(maxNameLength)}\t\t{phase}\t{timeAgo}\t{podIP}\t\t{containerImage}");
                                    comboBoxPods.Items.Add($"Nome: {name}");
                                }
                                else
                                {
                                    listBoxPods.Items.Add($"{name.PadRight(maxNameLength)}\t\t{phase}\t\t{timeAgo}\t{podIP}\t\t{containerImage}");
                                    comboBoxPods.Items.Add($"Nome: {name}");
                                }

                            }
                        }

                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao carregar pods. Error message: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar os pods: " + ex.Message);
            }
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxNamespaces.SelectedIndex == -1)
            {
                MessageBox.Show("Namespace tem de ser selecionada.");
                return;
            }

            string selectedItemText = comboBoxNamespaces.Items[comboBoxNamespaces.SelectedIndex].ToString();
            string namespacename = selectedItemText.Trim();

            await LoadDeployments(routerIp, portoAPI, authKey, namespacename);
            await LoadPods(routerIp, portoAPI, authKey, namespacename);
        }

        private async Task LoadNamespaces(string routerIp, string portoAPI, string authToken)
        {
            try
            {
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

                        comboBoxNamespaces.Items.Add("Todos");
                        comboBoxImage.Items.Add("nginx");

                        foreach (JObject namespaceObject in namespacesArray)
                        {
                            string name = (string)namespaceObject["metadata"]["name"];
                            comboBoxNamespaces.Items.Add($"{name}");
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

        private async void podsForm_Load(object sender, EventArgs e)
        {
            textBoxIP.Text = username + " - " + routerIp + ":" + portoSSH;

            await LoadNamespaces(routerIp, portoAPI, authKey);
        }

        private async Task LoadDeployments(string routerIp, string portoAPI, string authToken, string namespacename)
        {
            try
            {
                string url;
                comboBoxImage.Items.Clear();

                url = $"https://{routerIp}:{portoAPI}/apis/apps/v1/deployments";
                
                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        JObject deploymentsData = JObject.Parse(responseBody);
                        JArray deploymentsArray = (JArray)deploymentsData["items"];

                        foreach (JObject deploymentObject in deploymentsArray)
                        {
                            string containerImage = (string)deploymentObject["spec"]["template"]["spec"]["containers"][0]["image"];

                            comboBoxImage.Items.Add($"{containerImage}");
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Failed to load deployments. Error message: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading deployments: " + ex.Message);
            }
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

        private void btnTerminal_Click(object sender, EventArgs e)
        {
            sshConection sshConection = new sshConection();
            sshConection.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            sshConection.Show();
            this.Dispose();
        }
    }
}
