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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            mainPage mainPage = new mainPage();
            mainPage.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            mainPage.Show();
            this.Dispose();
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

                        listBoxNamespaces.Items.Add("Name\t\tPhase\t\tCreated");

                        foreach (JObject namespaceObject in namespacesArray)
                        {
                            string name = (string)namespaceObject["metadata"]["name"];
                            string phase = (string)namespaceObject["status"]["phase"];
                            string created = (string)namespaceObject["metadata"]["creationTimestamp"];

                            DateTime creationDateTime = DateTime.ParseExact(created, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                            TimeSpan timeSinceCreation = DateTime.Now - creationDateTime;
                            string timeAgo = $"{(int)timeSinceCreation.TotalDays} d, {(int)timeSinceCreation.Hours} h, {(int)timeSinceCreation.Minutes} m ago";

                            int nameColumn = name.Length;

                            if (nameColumn > 8)
                            {
                                listBoxNamespaces.Items.Add($"{name}\t{phase}\t\t{timeAgo}");
                            }
                            else
                            {
                                listBoxNamespaces.Items.Add($"{name}\t\t{phase}\t\t{timeAgo}");
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
    }
}
