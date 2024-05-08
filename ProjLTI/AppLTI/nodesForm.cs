using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppLTI
{
    public partial class nodesForm : Form
    {
        private string routerIp;
        private string username;
        private string password;
        private string portoSSH;
        private string portoAPI;
        private string authKey;

        public nodesForm()
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

        private void mainPage_Load(object sender, EventArgs e)
        {
            textBoxIP.Text = username + " - " + routerIp + ":" + portoSSH;
        }

        private async Task LoadNodes(string routerIp, string portoAPI, string authToken)
        {
            try
            {
                listBoxNodes.Items.Clear();

                string url = $"https://{routerIp}:{portoAPI}/api/v1/nodes";

                MessageBox.Show(url);

                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        // Parse JSON response
                        JObject nodesJson = JObject.Parse(responseBody);
                        JArray items = (JArray)nodesJson["items"];

                        // Add column headers
                        listBoxNodes.Items.Add("Name\tReady\tCPU Requests (cores)\tCPU Limits (cores)\tCPU Capacity (cores)\t" +
                            "Memory Requests (bytes)\tMemory Limits (bytes)\tMemory Capacity (bytes)\tPods\tCreated");

                        foreach (var item in items)
                        {
                            string name = (string)item["metadata"]["name"];
                            string ready = (string)item["status"]["conditions"][4]["status"];
                            string cpuRequests = (string)item["status"]["capacity"]["cpu"];
                            string cpuLimits = (string)item["status"]["allocatable"]["cpu"];
                            string cpuCapacity = (string)item["status"]["capacity"]["cpu"];
                            string memoryRequests = (string)item["status"]["capacity"]["memory"];
                            string memoryLimits = (string)item["status"]["allocatable"]["memory"];
                            string memoryCapacity = (string)item["status"]["capacity"]["memory"];
                            string pods = (string)item["status"]["capacity"]["pods"];
                            string created = (string)item["metadata"]["creationTimestamp"];

                            string nodeInfo = $"{name}\t{ready}\t{cpuRequests}\t{cpuLimits}\t{cpuCapacity}\t" +
                                $"{memoryRequests}\t{memoryLimits}\t{memoryCapacity}\t{pods}\t{created}";

                            listBoxNodes.Items.Add(nodeInfo);
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao carregar as Nodes. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar as Nodes: " + ex.Message);
            }
        }

        private async void buttonListarNodes_Click(object sender, EventArgs e)
        {
            await LoadNodes(routerIp, portoAPI, authKey);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            mainPage mainPage = new mainPage();
            mainPage.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            mainPage.Show();
            this.Dispose();
        }
    }
}
