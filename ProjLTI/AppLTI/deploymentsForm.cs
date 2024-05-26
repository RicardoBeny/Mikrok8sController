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
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Renci.SshNet;

namespace AppLTI
{
    public partial class deploymentsForm : Form
    {
        private string routerIp;
        private string username;
        private string password;
        private string portoSSH;
        private string portoAPI;
        private string authKey;
        private deploymentsForm parentForm;
        private IWebDriver driver;

        public deploymentsForm()
        {
            InitializeComponent();
        }

        public void SetCredentials(string routerIp, string username, string password, string portoSSH, string portoAPI, string authKey, deploymentsForm parentForm)
        {
            this.routerIp = routerIp;
            this.username = username;
            this.password = password;
            this.portoSSH = portoSSH;
            this.portoAPI = portoAPI;
            this.authKey = authKey;
            this.parentForm = parentForm;
        }
        public deploymentsForm(string routerIp, string username, string password, string portoSSH, string portoAPI, string authKey, deploymentsForm parentForm)
        {
            InitializeComponent();
            SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey, parentForm);
        }

        private async void deploymentsForm_Load(object sender, EventArgs e)
        {
            textBoxIP.Text = username + " - " + routerIp + ":" + portoSSH;

            await LoadNamespaces(routerIp, portoAPI, authKey);
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

            await LoadDeployments(routerIp, portoAPI, authKey, namespacename);
        }

        private async void buttonDeleteDeployments_Click(object sender, EventArgs e)
        {
            if (comboBoxNamespaces.SelectedIndex == -1 || (string)comboBoxNamespaces.SelectedItem == "Todos")
            {
                MessageBox.Show("Por favor selecione um namespace.");
                return;
            }

            string selectedItemText = comboBoxNamespaces.Items[comboBoxNamespaces.SelectedIndex].ToString();
            string namespacename = selectedItemText.Trim();

            if (comboBoxDeployments.SelectedIndex == -1)
            {
                MessageBox.Show("Deployment tem de ser selecionado.");
                return;
            }

            string selectedItemText1 = comboBoxDeployments.Items[comboBoxDeployments.SelectedIndex].ToString();
            string deploymentname = selectedItemText1.Substring(selectedItemText1.IndexOf("Nome:") + 5).Split(';')[0].Trim();
            await DeleteDeployments(routerIp, portoAPI, authKey, namespacename, deploymentname);
        }

        private async void buttonCreateDeployments_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNomeAdd.Text))
            {
                MessageBox.Show("Campo nome tem de ser preenchido.");
                return;
            }

            if (comboBoxNamespaceCriar.SelectedIndex == -1)
            {
                MessageBox.Show("Namespace tem de ser selecionada.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxContainerName.Text))
            {
                MessageBox.Show("Campo nome do container tem de ser preenchido.");
                return;
            }

            if (comboBoxImage.SelectedIndex == -1)
            {
                MessageBox.Show("Imagem tem de ser selecionada.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxReplicas.Text))
            {
                MessageBox.Show("Campo replicas tem de ser preenchido.");
                return;
            }


            string selectedItemText = comboBoxNamespaceCriar.Items[comboBoxNamespaceCriar.SelectedIndex].ToString();
            string namespacename = selectedItemText.Trim();

            await CreateDeployment(routerIp, portoAPI, authKey, namespacename);
        }
        private async Task CreateDeployment(string routerIp, string portoAPI, string authToken, string namespacename)
        {
            int replicas = int.Parse(textBoxReplicas.Text);
            int nContainers = 1;
            int porto = -1;
            string proposito = null, owner = null, team = null;

            if (!string.IsNullOrEmpty(textBoxPorto.Text))
            {
                porto = int.Parse(textBoxPorto.Text);
            }

            if (!string.IsNullOrEmpty(textBoxncontainers.Text))
            {
                nContainers = int.Parse(textBoxncontainers.Text);
            }

            if (!string.IsNullOrEmpty(textBoxEquipaMetadata.Text))
            {
                team = textBoxEquipaMetadata.Text;
            }

            if (!string.IsNullOrEmpty(textBoxproposito.Text))
            {
                proposito = textBoxproposito.Text;
            }

            if (!string.IsNullOrEmpty(textBoxOwner.Text))
            {
                owner = textBoxOwner.Text;
            }

            var metadata = new JObject
            {
                ["name"] = textBoxNomeAdd.Text,
                ["namespace"] = namespacename,
                ["labels"] = new JObject(),
                ["annotations"] = new JObject()
            };

            if (!string.IsNullOrEmpty(team))
            {
                metadata["labels"]["team"] = team;
            }

            if (!string.IsNullOrEmpty(owner))
            {
                metadata["annotations"]["owner"] = owner;
            }

            if (!string.IsNullOrEmpty(proposito))
            {
                metadata["annotations"]["purpose"] = proposito;
            }

            var requestBody = new JObject
            {
                ["apiVersion"] = "apps/v1",
                ["kind"] = "Deployment",
                ["metadata"] = metadata,
                ["spec"] = new JObject
                {
                    ["replicas"] = replicas,
                    ["selector"] = new JObject
                    {
                        ["matchLabels"] = new JObject
                        {
                            ["app"] = textBoxLabelApp.Text
                        }
                    },
                    ["template"] = new JObject
                    {
                        ["metadata"] = new JObject
                        {
                            ["labels"] = new JObject
                            {
                                ["app"] = textBoxLabelApp.Text
                            }
                        },
                        ["spec"] = new JObject
                        {
                            ["containers"] = GetContainerDefinitions(nContainers, textBoxContainerName.Text, comboBoxImage.SelectedItem.ToString(), porto)
                        }
                    }
                }
            };

            requestBody["metadata"]["managedFields"] = new JArray
            {
                new JObject
                {
                    ["manager"] = owner
                }
            };

            try
            {
                string url = $"https://{routerIp}:{portoAPI}/apis/apps/v1/namespaces/{namespacename}/deployments";

                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Deployment created successfully.");
                        await LoadDeployments(routerIp, portoAPI, authToken, namespacename);
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Failed to create Deployment. Error message: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while creating Deployment: " + ex.Message);
            }
        }

        private JArray GetContainerDefinitions(int? nContainers, string containerNameBase, string image, int containerPort)
        {
            if (!nContainers.HasValue || nContainers <= 0)
            {
                return new JArray();
            }

            var containers = new JArray();
            for (int i = 0; i < nContainers.Value; i++)
            {
                var container = new JObject
                {
                    ["name"] = $"{containerNameBase}{i + 1}",
                    ["image"] = image,
                    ["ports"] = new JArray()
                };

                if (containerPort != -1)
                {
                    var port = new JObject
                    {
                        ["containerPort"] = containerPort
                    };
                    ((JArray)container["ports"]).Add(port);
                }

                containers.Add(container);
            }
            return containers;
        }

        private async Task DeleteDeployments(string routerIp, string portoAPI, string authToken, string namespaceName, string deploymentname)
        {
            try
            {
                string url = $"https://{routerIp}:{portoAPI}/apis/apps/v1/namespaces/{namespaceName}/deployments/{deploymentname}";

                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                    HttpResponseMessage response = await client.DeleteAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Deployment eliminado com sucesso.");
                        await LoadDeployments(routerIp, portoAPI, authToken, namespaceName);
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao eliminar o Deployment. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao eliminar o Deployment: " + ex.Message);
            }
        }

        public async Task LoadDeployments(string routerIp, string portoAPI, string authToken, string namespacename)
        {
            try
            {
                string url;
                listBoxDeployments.Items.Clear();
                comboBoxDeployments.Items.Clear();

                if (namespacename == "Todos")
                {
                    url = $"https://{routerIp}:{portoAPI}/apis/apps/v1/deployments";
                }
                else
                {
                    url = $"https://{routerIp}:{portoAPI}/apis/apps/v1/namespaces/{namespacename}/deployments";
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

                        JObject deploymentsData = JObject.Parse(responseBody);
                        JArray deploymentsArray = (JArray)deploymentsData["items"];

                        int maxNameLength = 0;
                        foreach (JObject deploymentObject in deploymentsArray)
                        {
                            string name = (string)deploymentObject["metadata"]["name"];
                            maxNameLength = Math.Max(maxNameLength, name.Length);
                        }

                        string nameHeader = "Deployment Name".PadRight(maxNameLength);

                        listBoxDeployments.Items.Add($"{nameHeader}\t\tPods\t\tAge\t\tImagem");

                        foreach (JObject deploymentObject in deploymentsArray)
                        {
                            string name = (string)deploymentObject["metadata"]["name"];
                            int replicas = (int)deploymentObject["spec"]["replicas"];
                            string created = (string)deploymentObject["metadata"]["creationTimestamp"];
                            string containerImage = (string)deploymentObject["spec"]["template"]["spec"]["containers"][0]["image"];

                            DateTime creationDateTime = DateTime.ParseExact(created, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                            TimeSpan timeSinceCreation = DateTime.Now - creationDateTime;
                            string timeAgo = $"{(int)timeSinceCreation.TotalDays} d, {(int)timeSinceCreation.Hours} h, {(int)timeSinceCreation.Minutes} m ago";

                            listBoxDeployments.Items.Add($"{name.PadRight(maxNameLength)}\t\t{replicas}\t\t{timeAgo}\t\t{containerImage}");
                            comboBoxDeployments.Items.Add($"Nome: {name}");
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

        private void btnTerminal_Click(object sender, EventArgs e)
        {
            sshConection sshConection = new sshConection();
            sshConection.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            sshConection.Show();
            this.Dispose();
        }

        private void buttonNodes_Click(object sender, EventArgs e)
        {
            nodesForm nodesForm = new nodesForm();
            nodesForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            nodesForm.Show();
            this.Dispose();
        }

        private void buttonNameSpaces_Click(object sender, EventArgs e)
        {
            namespacesForm namespacesForm = new namespacesForm();
            namespacesForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            namespacesForm.Show();
            this.Dispose();
        }

        private void buttonServices_Click(object sender, EventArgs e)
        {
            servicesForm servicesForm = new servicesForm();
            servicesForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            servicesForm.Show();
            this.Dispose();
        }

        private void buttonPods_Click(object sender, EventArgs e)
        {
            podsForm podsForm = new podsForm();
            podsForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            podsForm.Show();
            this.Dispose();
        }

        private void buttonWizardDeployment_Click(object sender, EventArgs e)
        {
            deploymentNameForm deploymentNameForm = new deploymentNameForm();
            deploymentNameForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey, parentForm);
            deploymentNameForm.Show();
        }

        private void listBoxDeployments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxDeployments.SelectedIndex != -1)
            {
                string selectedItem = listBoxDeployments.SelectedItem.ToString();

                string[] parts = selectedItem.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length > 0)
                {
                    string deploymentName = parts[0].Trim();
                    deploymentDetailsForm deploymentDetailsForm = new deploymentDetailsForm();
                    deploymentDetailsForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey, deploymentName);
                    deploymentDetailsForm.Show();
                }
            }
        }

        private void buttonIngress_Click(object sender, EventArgs e)
        {
            ingressForm ingressForm = new ingressForm();
            ingressForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            ingressForm.Show();
            this.Dispose();
        }

        private void RetrievePort()
        {
            try
            {
                using (var client = new SshClient(routerIp, int.Parse(portoSSH), username, password))
                {
                    try
                    {
                        client.Connect();
                        if (client.IsConnected)
                        {
                            var portCommand = $"echo '{password}' | sudo -S kubectl get svc kubernetes-dashboard -n kubernetes-dashboard -o jsonpath='{{.spec.ports[0].nodePort}}'";
                            var portResult = client.RunCommand(portCommand);

                            if (portResult.ExitStatus != 0)
                            {
                                MessageBox.Show("Erro a obter o port da API.");
                                return;
                            }

                            var port = portResult.Result.Trim();

                            client.Disconnect();

                            OpenRouterPage(routerIp, port, authKey);
                        }
                        else
                        {
                            MessageBox.Show("Verifique as credenciais - Login falhou.");
                            return;
                        }
                    }
                    catch
                    {
                        MessageBox.Show($"Credenciais incorretas - Login falhou.");
                        return;
                    }
                }
            }
            catch
            {
                MessageBox.Show($"Erro - Login falhou");
                return;
            }
        }

        private void OpenRouterPage(string routerIp, string porto, string authkey)
        {

            try
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("start-maximized");
                options.AddArgument("disable-infobars");
                options.AddArgument("disable-extensions");
                options.AddArgument("disable-notifications");
                options.AddArgument("--ignore-certificate-errors");

                ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                service.HideCommandPromptWindow = true;

                driver = new ChromeDriver(service, options);

                driver.Navigate().GoToUrl($"https://{routerIp}:{porto}");


                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement tokenField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("token")));
                tokenField.SendKeys(authkey);

                var loginButton = driver.FindElement(By.CssSelector("button[type='submit']"));
                loginButton.Click();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInterfaceWeb_Click(object sender, EventArgs e)
        {
            RetrievePort();
        }
    }
}
