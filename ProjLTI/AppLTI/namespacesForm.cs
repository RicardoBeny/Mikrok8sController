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
using System.Runtime.InteropServices;

namespace AppLTI
{
    public partial class namespacesForm : Form
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

        public namespacesForm()
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
            buttonListarNamespaces.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonListarNamespaces.Width, buttonListarNamespaces.Height, 5, 5));
            buttonCreateNamespace.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonCreateNamespace.Width, buttonCreateNamespace.Height, 5, 5));
            buttonDeleteNamespace.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonDeleteNamespace.Width, buttonDeleteNamespace.Height, 5, 5));
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

        private async void buttonListarNamespaces_Click(object sender, EventArgs e)
        {
            await LoadNamespaces(routerIp, portoAPI, authKey);
        }

        private async Task LoadNamespaces(string routerIp, string portoAPI, string authToken)
        {
            try
            {
                listBoxNamespaces.Items.Clear();
                comboBoxNamespaces.Items.Clear();

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

                        listBoxNamespaces.Items.Add("Name\t\t\tPhase\t\tCreated");

                        foreach (JObject namespaceObject in namespacesArray)
                        {
                            string name = (string)namespaceObject["metadata"]["name"];
                            string phase = (string)namespaceObject["status"]["phase"];
                            string created = (string)namespaceObject["metadata"]["creationTimestamp"];

                            DateTime creationDateTime = DateTime.ParseExact(created, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                            TimeSpan timeSinceCreation = DateTime.Now - creationDateTime;
                            string timeAgo = $"{(int)timeSinceCreation.TotalDays} d, {(int)timeSinceCreation.Hours} h, {(int)timeSinceCreation.Minutes} m ago";

                            int nameColumn = name.Length;

                            if(nameColumn > 17)
                            {
                                listBoxNamespaces.Items.Add($"{name}\t{phase}\t\t{timeAgo}");
                                comboBoxNamespaces.Items.Add($"Nome: {name}");
                            }
                            else if (nameColumn < 9)
                            {
                                listBoxNamespaces.Items.Add($"{name}\t\t\t{phase}\t\t{timeAgo}");
                                comboBoxNamespaces.Items.Add($"Nome: {name}");
                            }
                            else
                            {
                                listBoxNamespaces.Items.Add($"{name}\t\t{phase}\t\t{timeAgo}");
                                comboBoxNamespaces.Items.Add($"Nome: {name}");
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

        private async void buttonCreateNamespace_Click(object sender, EventArgs e)
        {
            await CreateNamespaces(routerIp, portoAPI, authKey);
        }

        private async Task CreateNamespaces(string routerIp, string portoAPI, string authToken)
        {
            if (string.IsNullOrWhiteSpace(textBoxNomeAdd.Text))
            {
                MessageBox.Show("Campo nome tem de ser preenchido.");
                return;
            }

            var requestBody = new JObject();
            requestBody["apiVersion"] = "v1";
            requestBody["kind"] = "Namespace";

            var metadata = new JObject();
            metadata["name"] = textBoxNomeAdd.Text;
            requestBody["metadata"] = metadata;

            try
            {
                listBoxNamespaces.Items.Clear();

                string url = $"https://{routerIp}:{portoAPI}/api/v1/namespaces";

                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Namespace adicionado com sucesso.");
                        await LoadNamespaces(routerIp, portoAPI, authToken);
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao adicionar namespace . Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao adicionar namespace: " + ex.Message);
            }
        }

        private async void buttonDeleteNamespace_Click(object sender, EventArgs e)
        {
            if (comboBoxNamespaces.SelectedIndex == -1)
            {
                MessageBox.Show("Namespace tem de ser selecionada.");
                return;
            }

            string selectedItemText = comboBoxNamespaces.Items[comboBoxNamespaces.SelectedIndex].ToString();
            string namespacename = selectedItemText.Substring(selectedItemText.IndexOf("Nome:") + 5).Split(';')[0].Trim();

            await DeleteNamespace(routerIp, portoAPI, authKey, namespacename);
        }

        private async Task DeleteNamespace(string routerIp, string portoAPI, string authToken, string namespaceName)
        {
            try
            {
                string url = $"https://{routerIp}:{portoAPI}/api/v1/namespaces/{namespaceName}";

                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                    HttpResponseMessage response = await client.DeleteAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Namespace eliminado com sucesso.");
                        await LoadNamespaces(routerIp, portoAPI, authToken);
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao eliminar namespace. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao eliminar namespace: " + ex.Message);
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
        
        private void buttonServices_Click(object sender, EventArgs e)
        {
            servicesForm servicesForm = new servicesForm();
            servicesForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            servicesForm.Show();
            this.Dispose();
        }

        private void buttonDeployments_Click(object sender, EventArgs e)
        {
            deploymentsForm deploymentsForm = new deploymentsForm();
            deploymentsForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            deploymentsForm.Show();
            this.Dispose();
        }

        private void buttonPods_Click(object sender, EventArgs e)
        {
            podsForm podsForm = new podsForm();
            podsForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            podsForm.Show();
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
