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
    public partial class serviceNameForm : Form
    {
        private string routerIp;
        private string portoAPI;
        private string authKey;
        private string label;
        private string namespacename;
        private string portoDeployment;
        public serviceNameForm()
        {
            InitializeComponent();
        }

        public void SetCredentials(string routerIp, string portoAPI, string authKey,string label, string namespacename, string portoDeployment)
        {
            this.routerIp = routerIp;
            this.portoAPI = portoAPI;
            this.authKey = authKey;
            this.label = label;
            this.namespacename = namespacename;
            this.portoDeployment = portoDeployment;
        }

        private async void pictureBox2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNome.Text))
            {
                MessageBox.Show("Campo nome tem de ser preenchido.");
                return;
            }

            bool deploymentExists = await LoadServices(routerIp, portoAPI, authKey, namespacename, textBoxNome.Text);

            if (deploymentExists)
            {
                MessageBox.Show("O serviço já existe nesse namaspace.");
            }
            else
            {
                servicePortForm servicePortForm = new servicePortForm();
                servicePortForm.SetCredentials(routerIp, portoAPI, authKey, label, textBoxNome.Text, namespacename, portoDeployment);
                servicePortForm.Show();
                this.Dispose();
            }
        }

        private async Task<bool> LoadServices(string routerIp, string portoAPI, string authToken, string namespacename, string deploymentname)
        {
            try
            {
                string url = $"https://{routerIp}:{portoAPI}/api/v1/namespaces/{namespacename}/services";

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
                            string name = (string)deploymentObject["metadata"]["name"];

                            if (name == deploymentname)
                            {
                                return true;
                            }
                        }

                        return false;
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Failed to load services. Error message: " + errorMessage);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading services: " + ex.Message);
                return false;
            }
        }
    }
}
