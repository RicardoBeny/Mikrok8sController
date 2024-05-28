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
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace AppLTI
{
    public partial class serviceTypeForm : Form
    {
        private string routerIp;
        private string portoAPI;
        private string authKey;
        private string label;
        private string namespacename;
        private string servicename;
        private string porto;
        private string targetport;
        public serviceTypeForm()
        {
            InitializeComponent();
        }
        public void SetCredentials(string routerIp, string portoAPI, string authKey, string label, string servicename, string namespacename, string port, string targetport)
        {
            this.routerIp = routerIp;
            this.portoAPI = portoAPI;
            this.authKey = authKey;
            this.label = label;
            this.namespacename = namespacename;
            this.servicename = servicename;
            this.porto = port;
            this.targetport = targetport;
        }

        private async void pictureBox2_Click(object sender, EventArgs e)
        {
            if (comboBoxProtocolo.SelectedIndex == -1)
            {
                MessageBox.Show("Protocolo tem de ser selecionada.");
                return;
            }

            if (comboBoxType.SelectedIndex == -1)
            {
                MessageBox.Show("Tipo tem de ser selecionado.");
                return;
            }

            string selectedItemText = comboBoxProtocolo.Items[comboBoxProtocolo.SelectedIndex].ToString();
            string protocolo = selectedItemText.Trim();

            string selectedItemText1 = comboBoxType.Items[comboBoxType.SelectedIndex].ToString();
            string tipo = selectedItemText1.Trim();

            await CreateService(routerIp, portoAPI, authKey, namespacename, protocolo, tipo);

            ingressWizardForm ingressWizardForm = new ingressWizardForm();
            ingressWizardForm.SetCredentials(routerIp, portoAPI, authKey, servicename, namespacename, porto);
            ingressWizardForm.Show();
            this.Dispose();
        }

        private async void buttonFinish_Click(object sender, EventArgs e)
        {
            if (comboBoxProtocolo.SelectedIndex == -1)
            {
                MessageBox.Show("Protocolo tem de ser selecionada.");
                return;
            }

            if (comboBoxType.SelectedIndex == -1)
            {
                MessageBox.Show("Tipo tem de ser selecionado.");
                return;
            }

            string selectedItemText = comboBoxProtocolo.Items[comboBoxProtocolo.SelectedIndex].ToString();
            string protocolo = selectedItemText.Trim(); 

            string selectedItemText1 = comboBoxType.Items[comboBoxType.SelectedIndex].ToString();
            string tipo = selectedItemText1.Trim();

            await CreateService(routerIp, portoAPI, authKey, namespacename, protocolo, tipo);
        }

        private async Task CreateService(string routerIp, string portoAPI, string authToken, string namespacename, string protocolo,string tipo)
        {
            int port = int.Parse(porto);
            int targetPort = int.Parse(targetport);

            var metadata = new JObject
            {
                ["name"] = servicename,
                ["namespace"] = namespacename,
                ["labels"] = new JObject(),
                ["annotations"] = new JObject()
            };

            var requestBody = new JObject
            {
                ["apiVersion"] = "v1",
                ["kind"] = "Service",
                ["metadata"] = metadata,
                ["spec"] = new JObject
                {
                    ["selector"] = new JObject
                    {
                        ["app"] = label
                    },
                    ["ports"] = new JArray
            {
                new JObject
                {
                    ["protocol"] = protocolo,
                    ["port"] = port,
                    ["targetPort"] = targetPort
                }
            },
                    ["type"] = tipo
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            servicePortForm servicePortForm = new servicePortForm();
            servicePortForm.SetCredentials(routerIp, portoAPI, authKey,label, servicename, namespacename, targetport);
            servicePortForm.Show();
            this.Dispose();
        }
    }
}
