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
    public partial class ingressForm : Form
    {
        private string routerIp;
        private string username;
        private string password;
        private string portoSSH;
        private string portoAPI;
        private string authKey;
        public ingressForm()
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

        private void buttonDeployments_Click(object sender, EventArgs e)
        {
            deploymentsForm deploymentsForm = new deploymentsForm();
            deploymentsForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey, deploymentsForm);
            deploymentsForm.Show();
            this.Dispose();
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

            await LoadIngress(routerIp, portoAPI, authKey, namespacename);
        }

        public async Task LoadIngress(string routerIp, string portoAPI, string authToken, string namespacename)
        {
            try
            {
                string url;
                listBoxIngress.Items.Clear();
                comboBoxDeployments.Items.Clear();

                if (namespacename == "Todos")
                {
                    url = $"https://{routerIp}:{portoAPI}/apis/networking.k8s.io/v1/ingresses";
                }
                else
                {
                    url = $"https://{routerIp}:{portoAPI}/apis/networking.k8s.io/v1/namespaces/{namespacename}/ingresses";
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

                        JObject ingressData = JObject.Parse(responseBody);
                        JArray ingressArray = (JArray)ingressData["items"];

                        if (ingressArray.Count == 0)
                        {
                            listBoxIngress.Items.Add("Não existe nenhum ingress");
                            return;
                        }

                        int maxNameLength = 0;
                        foreach (JObject ingressObject in ingressArray)
                        {
                            string name = (string)ingressObject["metadata"]["name"];
                            maxNameLength = Math.Max(maxNameLength, name.Length);
                        }

                        string nameHeader = "Ingress Name".PadRight(maxNameLength);
                        string hostHeader = "Host";
                        string pathHeader = "Path";
                        string createdHeader = "Age";

                        listBoxIngress.Items.Add($"{nameHeader}\t\t{hostHeader}\t\t\t{pathHeader}\t\t{createdHeader}");

                        foreach (JObject ingressObject in ingressArray)
                        {
                            string name = (string)ingressObject["metadata"]["name"];
                            JArray rulesArray = (JArray)ingressObject["spec"]["rules"];

                            string created = (string)ingressObject["metadata"]["creationTimestamp"];
                            DateTime creationDateTime = DateTime.ParseExact(created, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                            TimeSpan timeSinceCreation = DateTime.Now - creationDateTime;
                            string timeAgo = $"{(int)timeSinceCreation.TotalDays} d, {(int)timeSinceCreation.Hours} h, {(int)timeSinceCreation.Minutes} m ago";

                            foreach (JObject rule in rulesArray)
                            {
                                string host = (string)rule["host"];
                                JArray pathsArray = (JArray)rule["http"]["paths"];

                                foreach (JObject pathObject in pathsArray)
                                {
                                    string path = (string)pathObject["path"];
                                    listBoxIngress.Items.Add($"{name.PadRight(maxNameLength)}\t\t{host}\t\t{path}\t\t{timeAgo}");
                                }
                            }

                            comboBoxDeployments.Items.Add($"Nome: {name}");
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Failed to load Ingresses. Error message: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading Ingresses: " + ex.Message);
            }
        }

        private async void ingressForm_Load(object sender, EventArgs e)
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

        private void buttonServices_Click(object sender, EventArgs e)
        {
            servicesForm servicesForm = new servicesForm();
            servicesForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            servicesForm.Show();
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

        private void buttonCreateDeployments_Click(object sender, EventArgs e)
        {

        }

        private void buttonDeleteDeployments_Click(object sender, EventArgs e)
        {

        }
    }
}
