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
    public partial class podDetailsForm : Form
    {
        private string routerIp;
        private string username;
        private string password;
        private string portoSSH;
        private string portoAPI;
        private string authKey;
        private string podName;
        public podDetailsForm()
        {
            InitializeComponent();
        }

        public void SetCredentials(string routerIp, string username, string password, string portoSSH, string portoAPI, string authKey, string podName)
        {
            this.routerIp = routerIp;
            this.username = username;
            this.password = password;
            this.portoSSH = portoSSH;
            this.portoAPI = portoAPI;
            this.authKey = authKey;
            this.podName = podName;
        }

        private async void podDetailsForm_Load(object sender, EventArgs e)
        {
            labelPodName.Text = podName;

            await LoadPods(routerIp, portoAPI, authKey, podName);
        }

        public async Task LoadPods(string routerIp, string portoAPI, string authToken, string podName)
        {
            try
            {
                string url = $"https://{routerIp}:{portoAPI}/api/v1/pods";

                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        JObject podData = JObject.Parse(responseBody);
                        JArray podArray = (JArray)podData["items"];

                        foreach (JObject podObject in podArray)
                        {
                            string name = (string)podObject["metadata"]?["name"];

                            if (name == podName)
                            {
                                string namespaceName = (string)podObject["metadata"]?["namespace"];
                                string uid = (string)podObject["metadata"]?["uid"];
                                string appLabel = (string)podObject["metadata"]?["labels"]?["app"];
                                string podTemplateHash = (string)podObject["metadata"]?["labels"]?["pod-template-hash"];
                                string manager = (string)podObject["metadata"]?["managedFields"]?.First()?["manager"];

                                JArray containers = (JArray)podObject["spec"]?["containers"];

                                containerNamesListBox.Items.Clear();
                                envNamesListBox.Items.Clear();

                                if (containers != null)
                                {
                                    foreach (JObject container in containers)
                                    {
                                        string containerName = (string)container["name"];
                                        if (!string.IsNullOrEmpty(containerName))
                                        {
                                            containerNamesListBox.Items.Add(containerName);
                                        }

                                        JArray envVars = (JArray)container["env"];
                                        if (envVars != null)
                                        {
                                            foreach (JObject envVar in envVars)
                                            {
                                                string envName = (string)envVar["name"];
                                                if (!string.IsNullOrEmpty(envName))
                                                {
                                                    envNamesListBox.Items.Add(envName);
                                                }
                                            }
                                        }
                                    }
                                }

                                string restartPolicy = (string)podObject["spec"]?["restartPolicy"];
                                int? terminationGracePeriodSeconds = (int?)podObject["spec"]?["terminationGracePeriodSeconds"];
                                string dnsPolicy = (string)podObject["spec"]?["dnsPolicy"];
                                string serviceAccountName = (string)podObject["spec"]?["serviceAccountName"];
                                string priorityClassName = (string)podObject["spec"]?["priorityClassName"];

                                string phase = (string)podObject["status"]?["phase"];
                                string hostIP = (string)podObject["status"]?["hostIP"];
                                string podIP = (string)podObject["status"]?["podIP"];

                                labelnamespacename.Text = namespaceName;
                                uidlabel.Text = uid;
                                labelapplabel.Text = appLabel;
                                labeltemplatehash.Text = podTemplateHash;
                                managerlabel.Text = manager;

                                restartpolicylabel.Text = restartPolicy;
                                terminationGracePeriodSecondslabel.Text = terminationGracePeriodSeconds.ToString();
                                dnsPolicylabel.Text = dnsPolicy;
                                serviceAccountNamelabel.Text = serviceAccountName;
                                phaselabel.Text = phase;
                                hostIPlabel.Text = hostIP;
                                podIPlabel.Text = podIP;
                            }
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Failed to load deployment. Error message: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading deployment: " + ex.Message);
            }
        }
    }
}
