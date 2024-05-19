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
                            string name = (string)podObject["metadata"]["name"];

                            if (name == podName)
                            {
                                string namespaceName = (string)podObject["metadata"]["namespace"];
                                string manager = (string)podObject["metadata"]["managedFields"].First["manager"];

                                containerNamesListBox.Items.Clear();
                                envNamesListBox.Items.Clear();

                                JArray containers = (JArray)podObject["spec"]["template"]["spec"]["containers"];
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

                                string restartPolicy = (string)podObject["spec"]["template"]["spec"]["restartPolicy"];
                                int terminationGracePeriodSeconds = (int)podObject["spec"]["template"]["spec"]["terminationGracePeriodSeconds"];
                                string dnsPolicy = (string)podObject["spec"]["template"]["spec"]["dnsPolicy"];

                                int availableReplicas = (int)podObject["status"]["availableReplicas"];
                                int readyReplicas = (int)podObject["status"]["readyReplicas"];
                                int updatedReplicas = (int)podObject["status"]["updatedReplicas"];
                                int replicas = (int)podObject["status"]["replicas"];
                                int observedGeneration = (int)podObject["status"]["observedGeneration"];
                                string created = (string)podObject["metadata"]["creationTimestamp"];

                                DateTime creationDateTime = DateTime.ParseExact(created, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                                TimeSpan timeSinceCreation = DateTime.Now - creationDateTime;
                                string timeAgo = $"{(int)timeSinceCreation.TotalDays} d, {(int)timeSinceCreation.Hours} h, {(int)timeSinceCreation.Minutes} m";

                                labelTimeAgo.Text = timeAgo;
                                labelnome.Text = name;
                                labelnamespacename.Text = namespaceName;
                                managerlabel.Text = manager;
                                labelrestartpolicy.Text = restartPolicy;
                                labelgraceperiod.Text = terminationGracePeriodSeconds.ToString();
                                labeldnspolicy.Text = dnsPolicy;
                                availableReplicaslabel.Text = availableReplicas.ToString();
                                readyReplicaslabel.Text = readyReplicas.ToString();
                                updatedReplicaslabel.Text = updatedReplicas.ToString();
                                replicaslabel.Text = replicas.ToString();
                                observedGenerationlabel.Text = observedGeneration.ToString();

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
