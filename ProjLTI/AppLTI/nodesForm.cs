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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        JObject nodesJson = JObject.Parse(responseBody);
                        JArray items = (JArray)nodesJson["items"];

                        listBoxNodes.Items.Add("Name\t\tReady\tCPU Capacity (cores)\t" +
                            "Memory Limits (bytes)\tMemory Capacity (bytes)\tPods\t"
                            +"          "+ "Created\t\tEndereço");

                        foreach (var item in items)
                        {
                            string name = (string)item["metadata"]["name"];
                            string ready = (string)item["status"]["conditions"][3]["status"];
                            string cpuCapacity = (string)item["status"]["capacity"]["cpu"];
                            string memoryLimits = (string)item["status"]["allocatable"]["memory"];
                            string memoryCapacity = (string)item["status"]["capacity"]["memory"];
                            string pods = (string)item["status"]["capacity"]["pods"];
                            string created = (string)item["metadata"]["creationTimestamp"];

                            string ipAddress = "";
                            JArray addressesArray = (JArray)item["status"]["addresses"];
                            foreach (JObject addressObject in addressesArray)
                            {
                                string type = (string)addressObject["type"];
                                if (type == "InternalIP" || type == "Hostname")
                                {
                                    ipAddress = (string)addressObject["address"];
                                    break;
                                }
                            }

                            DateTime creationDateTime = DateTime.ParseExact(created, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                            TimeSpan timeSinceCreation = DateTime.Now - creationDateTime;
                            string timeAgo = $"{(int)timeSinceCreation.TotalDays} d, {(int)timeSinceCreation.Hours} h, {(int)timeSinceCreation.Minutes} m ago";

                            string nodeInfo = $"{name}\t{ready}\t\t{cpuCapacity}\t\t"+"          "+
                                $"{memoryLimits}\t\t\t{memoryCapacity}\t{pods}\t{timeAgo}\t\t{ipAddress}";

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

        private void nodesForm_Load(object sender, EventArgs e)
        {
            textBoxIP.Text = username + " - " + routerIp + ":" + portoSSH;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureUsername_Click(object sender, EventArgs e)
        {

        }

        private void textBoxIP_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
