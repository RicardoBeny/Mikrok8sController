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
    public partial class deploymentDetailsForm : Form
    {
        private string routerIp;
        private string username;
        private string password;
        private string portoSSH;
        private string portoAPI;
        private string authKey;
        private string deploymentName;

        public deploymentDetailsForm()
        {
            InitializeComponent();
        }

        public void SetCredentials(string routerIp, string username, string password, string portoSSH, string portoAPI, string authKey, string deploymentName)
        {
            this.routerIp = routerIp;
            this.username = username;
            this.password = password;
            this.portoSSH = portoSSH;
            this.portoAPI = portoAPI;
            this.authKey = authKey;
            this.deploymentName = deploymentName;
        }

        private async void deploymentDetailsForm_Load(object sender, EventArgs e)
        {
            labelDeploymentName.Text = deploymentName;

            await LoadDeployments(routerIp, portoAPI, authKey, deploymentName);
        }

        public async Task LoadDeployments(string routerIp, string portoAPI, string authToken, string deploymentName)
        {
            try
            {
                string url = $"https://{routerIp}:{portoAPI}/apis/apps/v1/deployments";

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

                            if (name == deploymentName)
                            {
                                string namespaceName = (string)deploymentObject["metadata"]["namespace"];
                                string owner = (string)deploymentObject["metadata"]["annotations"]?["owner"];
                                string team = (string)deploymentObject["metadata"]["labels"]?["team"];
                                string purpose = (string)deploymentObject["metadata"]["annotations"]?["purpose"];

                                containerNamesListBox.Items.Clear();
                                envNamesListBox.Items.Clear();
                                containerNamesListBox.Items.Add("Container\t\tImagem");

                                JArray containers = (JArray)deploymentObject["spec"]?["template"]?["spec"]?["containers"];
                                if (containers != null)
                                {
                                    foreach (JObject container in containers)
                                    {

                                        string containerName = (string)container["name"];
                                        if (!string.IsNullOrEmpty(containerName))
                                        {
                                            string containerImage = (string)container["image"];

                                            JArray containerPorts = (JArray)container["ports"];
                                            string containerPortInfo = "";
                                            if (containerPorts != null && containerPorts.Count > 0)
                                            {
                                                foreach (JObject portObj in containerPorts)
                                                {
                                                    string containerPort = (string)portObj["containerPort"];
                                                    if (!string.IsNullOrEmpty(containerPort))
                                                    {
                                                        containerPortInfo += containerPort + ", ";
                                                    }
                                                }
                                                containerPortInfo = containerPortInfo.TrimEnd(' ', ',');
                                            }
                                            containerNamesListBox.Items.Add($"{containerName} ({containerImage}) - Ports: {containerPortInfo}");
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

                                string restartPolicy = (string)deploymentObject["spec"]?["template"]?["spec"]?["restartPolicy"];
                                int? terminationGracePeriodSeconds = (int?)deploymentObject["spec"]?["template"]?["spec"]?["terminationGracePeriodSeconds"];
                                string dnsPolicy = (string)deploymentObject["spec"]?["template"]?["spec"]?["dnsPolicy"];

                                int? availableReplicas = (int?)deploymentObject["status"]?["availableReplicas"];
                                int? readyReplicas = (int?)deploymentObject["status"]?["readyReplicas"];
                                int? updatedReplicas = (int?)deploymentObject["status"]?["updatedReplicas"];
                                int? replicas = (int?)deploymentObject["status"]?["replicas"];
                                int? observedGeneration = (int?)deploymentObject["status"]?["observedGeneration"];
                                string created = (string)deploymentObject["metadata"]["creationTimestamp"];

                                DateTime creationDateTime = DateTime.ParseExact(created, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                                TimeSpan timeSinceCreation = DateTime.Now - creationDateTime;
                                string timeAgo = $"{(int)timeSinceCreation.TotalDays} d, {(int)timeSinceCreation.Hours} h, {(int)timeSinceCreation.Minutes} m";

                                if (!availableReplicas.HasValue && !readyReplicas.HasValue)
                                {
                                    labelAvailableReplicas.Visible = false;
                                    labelReadyReplicas.Visible = false;
                                }

                                if (string.IsNullOrEmpty(owner))
                                {
                                    labelmanager.Visible = false;
                                }

                                if (string.IsNullOrEmpty(team))
                                {
                                    label6.Visible = false;
                                }

                                if (string.IsNullOrEmpty(purpose))
                                {
                                    label3.Visible = false;
                                }

                                labelTimeAgo.Text = timeAgo;
                                labelnome.Text = name;
                                labelnamespacename.Text = namespaceName;
                                ownerlabel.Text = owner;
                                labelteam.Text = team;
                                labelproposito.Text = purpose;
                                labelrestartpolicy.Text = restartPolicy;
                                labelgraceperiod.Text = terminationGracePeriodSeconds?.ToString();
                                labeldnspolicy.Text = dnsPolicy;
                                availableReplicaslabel.Text = availableReplicas?.ToString();
                                readyReplicaslabel.Text = readyReplicas?.ToString();
                                updatedReplicaslabel.Text = updatedReplicas?.ToString();
                                replicaslabel.Text = replicas?.ToString();
                                observedGenerationlabel.Text = observedGeneration?.ToString();
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
