using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AppLTI
{
    public partial class nodesForm : Form
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

        public nodesForm()
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
            buttonListarNodes.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonListarNodes.Width, buttonListarNodes.Height, 5, 5));
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
                string nodeInfo;
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
                            "Memory Limits (bytes)\tMemory Capacity (bytes)\tPods \t"
                            + "Created\t\tEndereço");

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
                            string timeAgo = $"{(int)timeSinceCreation.TotalDays} d, {(int)timeSinceCreation.Hours} h, {(int)timeSinceCreation.Minutes} m";

                            if (name.Length > 9)
                            {
                                nodeInfo = $"{name}\t{ready}\t\t{cpuCapacity}\t\t"+
                                $"{memoryLimits}\t\t{memoryCapacity}\t\t{pods}\t{timeAgo}\t{ipAddress}";
                                listBoxNodes.Items.Add(nodeInfo);
                            }
                            else
                            {
                                nodeInfo = $"{name}\t{ready}\t\t{cpuCapacity}\t\t"+
                                $"{memoryLimits}\t\t{memoryCapacity}\t\t{pods}\t{timeAgo}\t{ipAddress}";
                                listBoxNodes.Items.Add(nodeInfo);
                            }
                            


                            
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

        private void nodesForm_Load(object sender, EventArgs e)
        {
            textBoxIP.Text = username + " - " + routerIp + ":" + portoSSH;
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
        
        private void buttonServices_Click(object sender, EventArgs e)
        {
            servicesForm servicesForm = new servicesForm();
            servicesForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            servicesForm.Show();
            this.Dispose();
        }

        private void buttonNameSpaces_Click(object sender, EventArgs e)
        {
            namespacesForm namespacesForm = new namespacesForm();
            namespacesForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            namespacesForm.Show();
            this.Dispose();
        }

        private void btnTerminal_Click(object sender, EventArgs e)
        {
            sshConection sshConection = new sshConection();
            sshConection.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            sshConection.Show();
            this.Dispose();
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

        private void panelServices_MouseClick(object sender, MouseEventArgs e)
        {
            servicesForm servicesForm = new servicesForm();
            servicesForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            servicesForm.Show();
            this.Dispose();
        }

        private void panelServices_MouseEnter(object sender, EventArgs e)
        {
            panelServices.BackColor = Color.FromArgb(38, 38, 38);
            buttonServices.ForeColor = Color.FromArgb(64, 132, 204);
            buttonServices.BackColor = Color.FromArgb(38, 38, 38);
        }

        private void panelServices_MouseLeave(object sender, EventArgs e)
        {
            panelServices.BackColor = Color.FromArgb(29, 29, 29);
            buttonServices.ForeColor = Color.White;
            buttonServices.BackColor = Color.FromArgb(29, 29, 29);
        }

        private void buttonServices_MouseEnter(object sender, EventArgs e)
        {
            panelServices.BackColor = Color.FromArgb(38, 38, 38);
            buttonServices.ForeColor = Color.FromArgb(64, 132, 204);
            buttonServices.BackColor = Color.FromArgb(38, 38, 38);
        }

        private void buttonServices_MouseLeave(object sender, EventArgs e)
        {
            panelServices.BackColor = Color.FromArgb(29, 29, 29);
            buttonServices.ForeColor = Color.White;
            buttonServices.BackColor = Color.FromArgb(29, 29, 29);
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
