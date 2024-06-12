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
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Renci.SshNet;
using System.Runtime.InteropServices;

namespace AppLTI
{
    public partial class servicesForm : Form
    {
        private IWebDriver driver;
        private string routerIp;
        private string username;
        private string password;
        private string portoSSH;
        private string portoAPI;
        private string authKey;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
         (
             int nLeft,
             int nTop,
             int nRight,
             int nBottom,
             int nWidthEllipse,
             int nHeightEllipse
         );

        public servicesForm()
        {
            InitializeComponent();
            panel4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel4.Width, panel4.Height, 30, 30));
            panelDashboard.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelDashboard.Width, panelDashboard.Height, 20, 20));
            panelPods.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelPods.Width, panelPods.Height, 20, 20));
            panelDeployments.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelDeployments.Width, panelDeployments.Height, 20, 20));
            panelServices.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelServices.Width, panelServices.Height, 20, 20));
            panelIngress.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelIngress.Width, panelIngress.Height, 20, 20));
            panelNamespaces.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelNamespaces.Width, panelNamespaces.Height, 20, 20));
            panelNodes.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelNodes.Width, panelNodes.Height, 20, 20));
            panelInterfaceWeb.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelInterfaceWeb.Width, panelInterfaceWeb.Height, 20, 20));
            panelTerminal.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelTerminal.Width, panelTerminal.Height, 20, 20));
            buttonCreateService.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonCreateService.Width, buttonCreateService.Height, 5, 5));
            buttonDeleteService.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonDeleteService.Width, buttonDeleteService.Height, 5, 5));
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

        private async void servicesForm_Load(object sender, EventArgs e)
        {
            textBoxIP.Text = username + " - " + routerIp + ":" + portoSSH;
            await LoadNamespaces(routerIp, portoAPI, authKey);
            await LoadServices(routerIp, portoAPI, authKey, "Todos");
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

        private void buttonDeployments_Click(object sender, EventArgs e)
        {
            deploymentsForm deploymentsForm = new deploymentsForm();
            deploymentsForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            deploymentsForm.Show();
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

        private async void buttonDeleteService_Click(object sender, EventArgs e)
        {
            if (comboBoxNamespaces.SelectedIndex == -1 || (string)comboBoxNamespaces.SelectedItem == "Todos")
            {
                MessageBox.Show("Por favor selecione um namespace.");
                return;
            }

            string selectedItemText = comboBoxNamespaces.Items[comboBoxNamespaces.SelectedIndex].ToString();
            string namespacename = selectedItemText.Trim();

            if (comboBoxService.SelectedIndex == -1)
            {
                MessageBox.Show("Serviço tem de ser selecionado.");
                return;
            }

            string selectedItemText1 = comboBoxService.Items[comboBoxService.SelectedIndex].ToString();
            string deploymentname = selectedItemText1.Substring(selectedItemText1.IndexOf("Nome:") + 5).Split(';')[0].Trim();
            await DeleteService(routerIp, portoAPI, authKey, namespacename, deploymentname);
        }

        private async Task DeleteService(string routerIp, string portoAPI, string authToken, string namespacename, string servicename)
        {
            try
            {
                string url = $"https://{routerIp}:{portoAPI}/api/v1/namespaces/{namespacename}/services/{servicename}";

                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                    HttpResponseMessage response = await client.DeleteAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Service deleted successfully.");
                        await LoadServices(routerIp, portoAPI, authToken, namespacename);
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Failed to delete Service. Error message: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the Service: " + ex.Message);
            }
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

            await LoadServices(routerIp, portoAPI, authKey, namespacename);
        }

        private async Task LoadServices(string routerIp, string portoAPI, string authToken, string namespacename)
        {
            try
            {
                string url;
                listBoxService.Items.Clear();
                comboBoxService.Items.Clear();

                if (namespacename == "Todos")
                {
                    url = $"https://{routerIp}:{portoAPI}/api/v1/services";
                }
                else
                {
                    url = $"https://{routerIp}:{portoAPI}/api/v1/namespaces/{namespacename}/services";
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

                        JObject servicesData = JObject.Parse(responseBody);
                        JArray servicesArray = (JArray)servicesData["items"];

                        int maxNameLength = 0;
                        foreach (JObject serviceObject in servicesArray)
                        {
                            string name = (string)serviceObject["metadata"]["name"];
                            maxNameLength = Math.Max(maxNameLength, name.Length);
                        }

                        string nameHeader = "Service  Name".PadRight(maxNameLength);

                        listBoxService.Items.Add($"{nameHeader}\t\tCluster IP\t\tType\t\tNamespace\t\t\tCreated");

                        foreach (JObject serviceObject in servicesArray)
                        {
                            string name = (string)serviceObject["metadata"]["name"];
                            string clusterIP = (string)serviceObject["spec"]["clusterIP"];
                            string type = (string)serviceObject["spec"]["type"];
                            string namespaceName = (string)serviceObject["metadata"]["namespace"];
                            string creationTimestamp = (string)serviceObject["metadata"]["creationTimestamp"];

                            DateTime creationDateTime = DateTime.ParseExact(creationTimestamp, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                            TimeSpan timeSinceCreation = DateTime.Now - creationDateTime;
                            string timeAgo = $"{(int)timeSinceCreation.TotalDays} d, {(int)timeSinceCreation.Hours} h, {(int)timeSinceCreation.Minutes} m ago";

                            listBoxService.Items.Add($"{name.PadRight(maxNameLength)}\t\t{clusterIP}\t\t{type}\t\t{namespaceName}\t\t{timeAgo}");
                            comboBoxService.Items.Add($"Nome: {name}");
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Failed to load services. Error message: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading services: " + ex.Message);
            }
        }

        private async void buttonCreateService_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNome.Text))
            {
                MessageBox.Show("Campo nome tem de ser preenchido.");
                return;
            }

            if (comboBoxNamespaceCriar.SelectedIndex == -1)
            {
                MessageBox.Show("Namespace tem de ser selecionada.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxLabelApp.Text))
            {
                MessageBox.Show("Campo label app tem de ser preenchido.");
                return;
            }
            
            if (comboBoxType.SelectedIndex == -1)
            {
                MessageBox.Show("Tipo tem de ser selecionado.");
                return;
            }

            if (comboBoxProtocolo.SelectedIndex == -1)
            {
                MessageBox.Show("Protocolo tem de ser selecionada.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxPorto.Text))
            {
                MessageBox.Show("Campo porto tem de ser preenchido.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxTargetPort.Text))
            {
                MessageBox.Show("Campo target port tem de ser preenchido.");
                return;
            }

            string selectedItemText = comboBoxNamespaceCriar.Items[comboBoxNamespaceCriar.SelectedIndex].ToString();
            string namespacename = selectedItemText.Trim();

            await CreateService(routerIp, portoAPI, authKey, namespacename);
        }

        private async Task CreateService(string routerIp, string portoAPI, string authToken, string namespacename)
        {
            int port = int.Parse(textBoxPorto.Text);
            int targetPort = int.Parse(textBoxTargetPort.Text);

            string selectedItemText1 = comboBoxType.Items[comboBoxType.SelectedIndex].ToString();
            string type = selectedItemText1.Trim();

            string selectedItemText2 = comboBoxProtocolo.Items[comboBoxProtocolo.SelectedIndex].ToString();
            string protocol = selectedItemText2.Trim();

            string proposito = null, owner = null, team = null;

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
                ["name"] = textBoxNome.Text,
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
                ["apiVersion"] = "v1",
                ["kind"] = "Service",
                ["metadata"] = metadata,
                ["spec"] = new JObject
                {
                    ["selector"] = new JObject
                    {
                        ["app"] = textBoxLabelApp.Text
                    },
                    ["ports"] = new JArray
            {
                new JObject
                {
                    ["protocol"] = protocol,
                    ["port"] = port,
                    ["targetPort"] = targetPort
                }
            },
                    ["type"] = type
                }
            };

            MessageBox.Show(requestBody.ToString());

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
                        await LoadServices(routerIp, portoAPI, authToken, namespacename);
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

        private void buttonIngress_Click(object sender, EventArgs e)
        {
            ingressForm ingressForm = new ingressForm();
            ingressForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            ingressForm.Show();
            this.Dispose();
        }

        private void btnInterfaceWeb_Click(object sender, EventArgs e)
        {
            RetrievePort();
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

        private void labelDashboard_Click(object sender, EventArgs e)
        {
            mainPage mainPage = new mainPage();
            mainPage.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            mainPage.Show();
            this.Dispose();
        }

        private void panelDashboard_click(object sender, MouseEventArgs e)
        {
            mainPage mainPage = new mainPage();
            mainPage.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            mainPage.Show();
            this.Dispose();
        }

        private void panelPods_click(object sender, MouseEventArgs e)
        {
            podsForm podsForm = new podsForm();
            podsForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            podsForm.Show();
            this.Dispose();
        }

        private void panelDashboard_MouseEnter(object sender, EventArgs e)
        {
            panelDashboard.BackColor = Color.FromArgb(38, 38, 38);
            labelDashboard.ForeColor = Color.FromArgb(64, 132, 204);
            labelDashboard.BackColor = Color.FromArgb(38, 38, 38);
        }

        private void panelDashboard_MouseLeave(object sender, EventArgs e)
        {
            panelDashboard.BackColor = Color.FromArgb(29, 29, 29);
            labelDashboard.ForeColor = Color.White;
            labelDashboard.BackColor = Color.FromArgb(29, 29, 29);
        }

        private void labelDashboard_MouseEnter(object sender, EventArgs e)
        {
            panelDashboard.BackColor = Color.FromArgb(38, 38, 38);
            labelDashboard.ForeColor = Color.FromArgb(64, 132, 204);
            labelDashboard.BackColor = Color.FromArgb(38, 38, 38);
        }

        private void labelDashboard_MouseLeave(object sender, EventArgs e)
        {
            panelDashboard.BackColor = Color.FromArgb(29, 29, 29);
            labelDashboard.ForeColor = Color.White;
            labelDashboard.BackColor = Color.FromArgb(29, 29, 29);
        }

        private void panelPods_MouseEnter(object sender, EventArgs e)
        {
            panelPods.BackColor = Color.FromArgb(38, 38, 38);
            buttonPods.ForeColor = Color.FromArgb(64, 132, 204);
            buttonPods.BackColor = Color.FromArgb(38, 38, 38);
        }

        private void panelPods_MouseLeave(object sender, EventArgs e)
        {
            panelPods.BackColor = Color.FromArgb(29, 29, 29);
            buttonPods.ForeColor = Color.White;
            buttonPods.BackColor = Color.FromArgb(29, 29, 29);
        }

        private void buttonPods_MouseEnter(object sender, EventArgs e)
        {
            panelPods.BackColor = Color.FromArgb(38, 38, 38);
            buttonPods.ForeColor = Color.FromArgb(64, 132, 204);
            buttonPods.BackColor = Color.FromArgb(38, 38, 38);
        }

        private void buttonPods_MouseLeave(object sender, EventArgs e)
        {
            panelPods.BackColor = Color.FromArgb(29, 29, 29);
            buttonPods.ForeColor = Color.White;
            buttonPods.BackColor = Color.FromArgb(29, 29, 29);
        }

        private void panelDeployments_MouseClick(object sender, MouseEventArgs e)
        {
            deploymentsForm deploymentsForm = new deploymentsForm();
            deploymentsForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            deploymentsForm.Show();
            this.Dispose();
        }

        private void panelDeployments_MouseEnter(object sender, EventArgs e)
        {
            panelDeployments.BackColor = Color.FromArgb(38, 38, 38);
            buttonDeployments.ForeColor = Color.FromArgb(64, 132, 204);
            buttonDeployments.BackColor = Color.FromArgb(38, 38, 38);
        }

        private void panelDeployments_MouseLeave(object sender, EventArgs e)
        {
            panelDeployments.BackColor = Color.FromArgb(29, 29, 29);
            buttonDeployments.ForeColor = Color.White;
            buttonDeployments.BackColor = Color.FromArgb(29, 29, 29);
        }

        private void buttonDeployments_MouseEnter(object sender, EventArgs e)
        {
            panelDeployments.BackColor = Color.FromArgb(38, 38, 38);
            buttonDeployments.ForeColor = Color.FromArgb(64, 132, 204);
            buttonDeployments.BackColor = Color.FromArgb(38, 38, 38);
        }

        private void buttonDeployments_MouseLeave(object sender, EventArgs e)
        {
            panelDeployments.BackColor = Color.FromArgb(29, 29, 29);
            buttonDeployments.ForeColor = Color.White;
            buttonDeployments.BackColor = Color.FromArgb(29, 29, 29);
        }


        private void panelIngress_MouseClick(object sender, MouseEventArgs e)
        {
            ingressForm ingressForm = new ingressForm();
            ingressForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            ingressForm.Show();
            this.Dispose();
        }

        private void panelIngress_MouseEnter(object sender, EventArgs e)
        {
            panelIngress.BackColor = Color.FromArgb(38, 38, 38);
            buttonIngress.ForeColor = Color.FromArgb(64, 132, 204);
            buttonIngress.BackColor = Color.FromArgb(38, 38, 38);
        }

        private void panelIngress_MouseLeave(object sender, EventArgs e)
        {
            panelIngress.BackColor = Color.FromArgb(29, 29, 29);
            buttonIngress.ForeColor = Color.White;
            buttonIngress.BackColor = Color.FromArgb(29, 29, 29);
        }

        private void buttonIngress_MouseEnter(object sender, EventArgs e)
        {
            panelIngress.BackColor = Color.FromArgb(38, 38, 38);
            buttonIngress.ForeColor = Color.FromArgb(64, 132, 204);
            buttonIngress.BackColor = Color.FromArgb(38, 38, 38);
        }

        private void buttonIngress_MouseLeave(object sender, EventArgs e)
        {
            panelIngress.BackColor = Color.FromArgb(29, 29, 29);
            buttonIngress.ForeColor = Color.White;
            buttonIngress.BackColor = Color.FromArgb(29, 29, 29);
        }

        private void panelNamespaces_MouseClick(object sender, MouseEventArgs e)
        {
            namespacesForm namespacesForm = new namespacesForm();
            namespacesForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            namespacesForm.Show();
            this.Dispose();
        }

        private void panelNamespaces_MouseEnter(object sender, EventArgs e)
        {
            panelNamespaces.BackColor = Color.FromArgb(38, 38, 38);
            buttonNameSpaces.ForeColor = Color.FromArgb(64, 132, 204);
            buttonNameSpaces.BackColor = Color.FromArgb(38, 38, 38);
        }

        private void panelNamespaces_MouseLeave(object sender, EventArgs e)
        {
            panelNamespaces.BackColor = Color.FromArgb(29, 29, 29);
            buttonNameSpaces.ForeColor = Color.White;
            buttonNameSpaces.BackColor = Color.FromArgb(29, 29, 29);
        }

        private void buttonNamespaces_MouseEnter(object sender, EventArgs e)
        {
            panelNamespaces.BackColor = Color.FromArgb(38, 38, 38);
            buttonNameSpaces.ForeColor = Color.FromArgb(64, 132, 204);
            buttonNameSpaces.BackColor = Color.FromArgb(38, 38, 38);
        }

        private void buttonNamespaces_MouseLeave(object sender, EventArgs e)
        {
            panelNamespaces.BackColor = Color.FromArgb(29, 29, 29);
            buttonNameSpaces.ForeColor = Color.White;
            buttonNameSpaces.BackColor = Color.FromArgb(29, 29, 29);
        }

        private void panelNodes_MouseClick(object sender, MouseEventArgs e)
        {
            nodesForm nodesForm = new nodesForm();
            nodesForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            nodesForm.Show();
            this.Dispose();
        }

        private void panelNodes_MouseEnter(object sender, EventArgs e)
        {
            panelNodes.BackColor = Color.FromArgb(38, 38, 38);
            buttonNodes.ForeColor = Color.FromArgb(64, 132, 204);
            buttonNodes.BackColor = Color.FromArgb(38, 38, 38);
        }

        private void panelNodes_MouseLeave(object sender, EventArgs e)
        {
            panelNodes.BackColor = Color.FromArgb(29, 29, 29);
            buttonNodes.ForeColor = Color.White;
            buttonNodes.BackColor = Color.FromArgb(29, 29, 29);
        }

        private void buttonNodes_MouseEnter(object sender, EventArgs e)
        {
            panelNodes.BackColor = Color.FromArgb(38, 38, 38);
            buttonNodes.ForeColor = Color.FromArgb(64, 132, 204);
            buttonNodes.BackColor = Color.FromArgb(38, 38, 38);
        }

        private void buttonNodes_MouseLeave(object sender, EventArgs e)
        {
            panelNodes.BackColor = Color.FromArgb(29, 29, 29);
            buttonNodes.ForeColor = Color.White;
            buttonNodes.BackColor = Color.FromArgb(29, 29, 29);
        }

        private void panelInterfaceWeb_MouseClick(object sender, MouseEventArgs e)
        {
            RetrievePort();
        }

        private void panelInterfaceWeb_MouseEnter(object sender, EventArgs e)
        {
            panelInterfaceWeb.BackColor = Color.FromArgb(38, 38, 38);
            btnInterfaceWeb.ForeColor = Color.FromArgb(64, 132, 204);
            btnInterfaceWeb.BackColor = Color.FromArgb(38, 38, 38);
        }

        private void panelInterfaceWeb_MouseLeave(object sender, EventArgs e)
        {
            panelInterfaceWeb.BackColor = Color.FromArgb(29, 29, 29);
            btnInterfaceWeb.ForeColor = Color.White;
            btnInterfaceWeb.BackColor = Color.FromArgb(29, 29, 29);
        }

        private void btnInterfaceWeb_MouseEnter(object sender, EventArgs e)
        {
            panelInterfaceWeb.BackColor = Color.FromArgb(38, 38, 38);
            btnInterfaceWeb.ForeColor = Color.FromArgb(64, 132, 204);
            btnInterfaceWeb.BackColor = Color.FromArgb(38, 38, 38);
        }

        private void btnInterfaceWeb_MouseLeave(object sender, EventArgs e)
        {
            panelInterfaceWeb.BackColor = Color.FromArgb(29, 29, 29);
            btnInterfaceWeb.ForeColor = Color.White;
            btnInterfaceWeb.BackColor = Color.FromArgb(29, 29, 29);
        }

        private void panelTerminal_MouseClick(object sender, MouseEventArgs e)
        {
            sshConection sshConection = new sshConection();
            sshConection.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            sshConection.Show();
            this.Dispose();
        }

        private void panelTerminal_MouseEnter(object sender, EventArgs e)
        {
            panelTerminal.BackColor = Color.FromArgb(38, 38, 38);
            btnTerminal.ForeColor = Color.FromArgb(64, 132, 204);
            btnTerminal.BackColor = Color.FromArgb(38, 38, 38);
        }

        private void panelTerminal_MouseLeave(object sender, EventArgs e)
        {
            panelTerminal.BackColor = Color.FromArgb(29, 29, 29);
            btnTerminal.ForeColor = Color.White;
            btnTerminal.BackColor = Color.FromArgb(29, 29, 29);
        }

        private void btnTerminal_MouseEnter(object sender, EventArgs e)
        {
            panelTerminal.BackColor = Color.FromArgb(38, 38, 38);
            btnTerminal.ForeColor = Color.FromArgb(64, 132, 204);
            btnTerminal.BackColor = Color.FromArgb(38, 38, 38);
        }

        private void btnTerminal_MouseLeave(object sender, EventArgs e)
        {
            panelTerminal.BackColor = Color.FromArgb(29, 29, 29);
            btnTerminal.ForeColor = Color.White;
            btnTerminal.BackColor = Color.FromArgb(29, 29, 29);
        }
    }
}
