using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Renci.SshNet;
using RestSharp;


namespace AppLTI
{
    public partial class mainPage : Form
    {
        SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
        SpeechSynthesizer speech = new SpeechSynthesizer();
        private IWebDriver driver;
        private string routerIp;
        private string username;
        private string password;
        private string portoSSH;
        private string portoAPI;
        private string authKey;
        private bool isMicrophoneActive = false;

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

        public mainPage()
        {
            InitializeComponent();
            panelDashboard.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelDashboard.Width, panelDashboard.Height, 20, 20));
            panelMainPage.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelMainPage.Width, panelMainPage.Height, 30, 30));
            panelPods.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelPods.Width, panelPods.Height, 20, 20));
            panelDeployments.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelDeployments.Width, panelDeployments.Height, 20, 20));
            panelServices.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelServices.Width, panelServices.Height, 20, 20));
            panelIngress.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelIngress.Width, panelIngress.Height, 20, 20));
            panelNamespaces.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelNamespaces.Width, panelNamespaces.Height, 20, 20));
            panelNodes.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelNodes.Width, panelNodes.Height, 20, 20));
            panelInterfaceWeb.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelInterfaceWeb.Width, panelInterfaceWeb.Height, 20, 20));
            panelTerminal.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelTerminal.Width, panelTerminal.Height, 20, 20));
            InitializeVoiceRecognition();
        }

        private void InitializeVoiceRecognition()
        {
            try
            {
                if (SpeechRecognitionEngine.InstalledRecognizers().Count > 0)
                {
                    recognizer = new SpeechRecognitionEngine();
                    recognizer.SetInputToDefaultAudioDevice();
                    recognizer.SpeechRecognized += recEngine_SpeechRecognized;

                    Choices choices = new Choices();
                    choices.Add(new string[] { "pods", "nodes", "terminal", "namespaces", "deployments", "services", "ingress", "web page" });
                    GrammarBuilder gb = new GrammarBuilder();
                    gb.Append(choices);
                    gb.Culture = recognizer.RecognizerInfo.Culture;
                    Grammar g = new Grammar(gb);

                    recognizer.LoadGrammar(g);
                    speech.SelectVoiceByHints(VoiceGender.Male);
                }
                else
                {
                    MessageBox.Show("No speech recognizers installed. Please install a speech recognizer.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Voice recognition initialization failed: {ex.Message}");
            }
        }

        private void StartMicrophone()
        {
            try
            {
                recognizer.RecognizeAsync(RecognizeMode.Multiple);
                isMicrophoneActive = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to start microphone: {ex.Message}");
            }
        }

        private void StopMicrophone()
        {
            try
            {
                recognizer.RecognizeAsyncStop();
                isMicrophoneActive = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to stop microphone: {ex.Message}");
            }
        }

        private void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string result = e.Result.Text;

            Task.Run(() =>
            {
                Invoke(new Action(() =>
                {
                    if (result == "pods")
                    {
                        StopMicrophone();
                        podsForm podsForm = new podsForm();
                        podsForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
                        podsForm.Show();
                        this.Dispose();
                    }
                    else if (result == "nodes")
                    {
                        StopMicrophone();
                        nodesForm nodesForm = new nodesForm();
                        nodesForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
                        nodesForm.Show();
                        this.Dispose();
                    }
                    else if (result == "terminal")
                    {
                        StopMicrophone();
                        sshConection sshConection = new sshConection();
                        sshConection.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
                        sshConection.Show();
                        this.Dispose();
                    }
                    else if (result == "namespaces")
                    {
                        StopMicrophone();
                        namespacesForm namespacesForm = new namespacesForm();
                        namespacesForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
                        namespacesForm.Show();
                        this.Dispose();
                    }
                    else if (result == "deployments")
                    {
                        StopMicrophone();
                        deploymentsForm deploymentsForm = new deploymentsForm();
                        deploymentsForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
                        deploymentsForm.Show();
                        this.Dispose();
                    }
                    else if (result == "services")
                    {
                        StopMicrophone();
                        servicesForm servicesForm = new servicesForm();
                        servicesForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
                        servicesForm.Show();
                        this.Dispose();
                    }
                    else if (result == "ingress")
                    {
                        StopMicrophone();
                        ingressForm ingressForm = new ingressForm();
                        ingressForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
                        ingressForm.Show();
                        this.Dispose();
                    }
                    else if (result == "web page")
                    {
                        RetrievePort();
                    }
                }));
            });
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

        private async void mainPage_Load(object sender, EventArgs e)
        {
            textBoxIP.Text = username + " - " + routerIp + ":" + portoSSH;
            await LoadNodes(routerIp, portoAPI, authKey);
            await LoadNamespaces(routerIp, portoAPI, authKey);
            await LoadGraphs(routerIp, portoAPI, authKey, "Todos");
        }

        private async Task LoadNamespaces(string routerIp, string portoAPI, string authToken)
        {
            try
            {
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

                        comboBoxNamespaces.Items.Add("Todos");

                        foreach (JObject namespaceObject in namespacesArray)
                        {
                            string name = (string)namespaceObject["metadata"]["name"];
                            comboBoxNamespaces.Items.Add($"{name}");
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

        private async Task LoadNodes(string routerIp, string portoAPI, string authToken)
        {
            try
            {
                listBoxNodesDashboard.Items.Clear();

                string nodesUrl = $"https://{routerIp}:{portoAPI}/api/v1/nodes";
                string podsUrl = $"https://{routerIp}:{portoAPI}/api/v1/pods";

                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                    HttpResponseMessage nodesResponse = await client.GetAsync(nodesUrl);
                    HttpResponseMessage podsResponse = await client.GetAsync(podsUrl);

                    if (nodesResponse.IsSuccessStatusCode && podsResponse.IsSuccessStatusCode)
                    {
                        string nodesResponseBody = await nodesResponse.Content.ReadAsStringAsync();
                        string podsResponseBody = await podsResponse.Content.ReadAsStringAsync();

                        JObject nodesJson = JObject.Parse(nodesResponseBody);
                        JArray nodesItems = (JArray)nodesJson["items"];

                        JObject podsJson = JObject.Parse(podsResponseBody);
                        JArray podsItems = (JArray)podsJson["items"];

                        Dictionary<string, int> nodePodCounts = new Dictionary<string, int>();

                        foreach (var pod in podsItems)
                        {
                            string nodeName = (string)pod["spec"]["nodeName"];
                            if (!string.IsNullOrEmpty(nodeName))
                            {
                                if (nodePodCounts.ContainsKey(nodeName))
                                {
                                    nodePodCounts[nodeName]++;
                                }
                                else
                                {
                                    nodePodCounts[nodeName] = 1;
                                }
                            }
                        }

                        listBoxNodesDashboard.Items.Add("Name\t\tReady\tCPU Capacity (cores)\t" +
                            "Memory Limits (bytes)\tMemory Capacity (bytes)\tPods\tCreated");

                        foreach (var item in nodesItems)
                        {
                            string name = (string)item["metadata"]["name"];
                            string ready = (string)item["status"]["conditions"][3]["status"];
                            string cpuCapacity = (string)item["status"]["capacity"]["cpu"];
                            string memoryLimits = (string)item["status"]["allocatable"]["memory"];
                            string memoryCapacity = (string)item["status"]["capacity"]["memory"];
                            string created = (string)item["metadata"]["creationTimestamp"];

                            DateTime creationDateTime = DateTime.ParseExact(created, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                            TimeSpan timeSinceCreation = DateTime.Now - creationDateTime;
                            string timeAgo = $"{(int)timeSinceCreation.TotalDays} d, {(int)timeSinceCreation.Hours} h, {(int)timeSinceCreation.Minutes} m ago";

                            int podCount = nodePodCounts.ContainsKey(name) ? nodePodCounts[name] : 0;

                            string nodeInfo = $"{name}\t{ready}\t\t{cpuCapacity}\t\t" +
                                $"{memoryLimits}\t\t{memoryCapacity}\t\t{podCount}\t{timeAgo}";

                            listBoxNodesDashboard.Items.Add(nodeInfo);
                        }
                    }
                    else
                    {
                        string errorMessage = nodesResponse.IsSuccessStatusCode ? await podsResponse.Content.ReadAsStringAsync() : await nodesResponse.Content.ReadAsStringAsync();
                        MessageBox.Show("Failed to load nodes. Error message: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading nodes: " + ex.Message);
            }
        }



        private void buttonPods_Click_1(object sender, EventArgs e)
        {
            StopMicrophone();
            podsForm podsForm = new podsForm();
            podsForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            podsForm.Show();
            this.Dispose();
        }

        private void panelPods_Click_1(object sender, EventArgs e)
        {
            StopMicrophone();
            podsForm podsForm = new podsForm();
            podsForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            podsForm.Show();
            this.Dispose();
        }

        private void buttonNodes_Click_1(object sender, EventArgs e)
        {
            StopMicrophone();
            nodesForm nodesForm = new nodesForm();
            nodesForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            nodesForm.Show();
            this.Dispose();
        }

        private void btnTerminal_Click_1(object sender, EventArgs e)
        {
            StopMicrophone();
            sshConection sshConection = new sshConection();
            sshConection.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            sshConection.Show();
            this.Dispose();
        }

        private void buttonNameSpaces_Click_1(object sender, EventArgs e)
        {
            StopMicrophone();
            namespacesForm namespacesForm = new namespacesForm();
            namespacesForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            namespacesForm.Show();
            this.Dispose();
        }

        private void buttonDeployments_Click_1(object sender, EventArgs e)
        {
            StopMicrophone();
            deploymentsForm deploymentsForm = new deploymentsForm();
            deploymentsForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            deploymentsForm.Show();
            this.Dispose();
        }

        private void buttonServices_Click(object sender, EventArgs e)
        {
            StopMicrophone();
            servicesForm servicesForm = new servicesForm();
            servicesForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            servicesForm.Show();
            this.Dispose();
        }

        private void buttonActivateMic_Click(object sender, EventArgs e)
        {
            StartMicrophone();
            buttonMutMic.BringToFront();
        }

        private void buttonMutMic_Click(object sender, EventArgs e)
        {
            StopMicrophone();
            buttonActivateMic.BringToFront();
        }

        private void buttonIngress_Click(object sender, EventArgs e)
        {
            StopMicrophone();
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

        private async void comboBoxNamespaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxNamespaces.SelectedIndex == -1)
            {
                MessageBox.Show("Namespace tem de ser selecionada.");
                return;
            }

            string selectedItemText = comboBoxNamespaces.Items[comboBoxNamespaces.SelectedIndex].ToString();
            string namespacename = selectedItemText.Trim();

            await LoadGraphs(routerIp, portoAPI, authKey, namespacename);
        }

        public async Task LoadGraphs(string routerIp, string portoAPI, string authToken, string namespacename)
        {
            try
            {
                string urlDeamon;
                string urlDeployments;
                string urlJobs;
                string urlPods;
                string urlReplicaSets;

                if (namespacename == "Todos")
                {
                    urlDeamon = $"https://{routerIp}:{portoAPI}/apis/apps/v1/daemonsets";
                    urlDeployments = $"https://{routerIp}:{portoAPI}/apis/apps/v1/deployments";
                    urlJobs = $"https://{routerIp}:{portoAPI}/apis/batch/v1/jobs";
                    urlPods = $"https://{routerIp}:{portoAPI}/api/v1/pods";
                    urlReplicaSets = $"https://{routerIp}:{portoAPI}/apis/apps/v1/replicasets";
                }
                else
                {
                    urlDeamon = $"https://{routerIp}:{portoAPI}/apis/apps/v1/namespaces/{namespacename}/daemonsets";
                    urlDeployments = $"https://{routerIp}:{portoAPI}/apis/apps/v1/namespaces/{namespacename}/deployments";
                    urlJobs = $"https://{routerIp}:{portoAPI}/apis/batch/v1/namespaces/{namespacename}/jobs";
                    urlPods = $"https://{routerIp}:{portoAPI}/api/v1/namespaces/{namespacename}/pods";
                    urlReplicaSets = $"https://{routerIp}:{portoAPI}/apis/apps/v1/namespaces/{namespacename}/replicasets";
                }

                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                    var daemonSetsData = await GetDataFromApi(client, urlDeamon);
                    var deploymentsData = await GetDataFromApi(client, urlDeployments);
                    var jobsData = await GetDataFromApi(client, urlJobs);
                    var podsData = await GetDataFromApi(client, urlPods);
                    var replicaSetsData = await GetDataFromApi(client, urlReplicaSets);

                    ShowPieChart("Daemon Sets", AnalyzeDaemonSetStatus(daemonSetsData), chartDaemon);
                    ShowPieChart("Deployments", AnalyzeDeploymentStatus(deploymentsData), chartDeployments);
                    ShowPieChart("Jobs", AnalyzeJobStatus(jobsData), chartJobs);
                    ShowPieChart("Pods", AnalyzePodStatus(podsData), chartPods);
                    ShowPieChart("Replica Sets", AnalyzeReplicaSetStatus(replicaSetsData), chartReplicaSets);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading graphs: " + ex.Message);
            }
        }

        private async Task<JObject> GetDataFromApi(HttpClient client, string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return JObject.Parse(responseBody);
            }
            else
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Failed to load data. Error message: " + errorMessage);
                return null;
            }
        }

        private Dictionary<string, int> AnalyzeDaemonSetStatus(JObject data)
        {
            if (data == null) return null;

            var statuses = new Dictionary<string, int>
    {
        { "Running", 0 },
        { "Failed", 0 }
    };

            foreach (var item in data["items"])
            {
                var status = item["status"];
                if (status != null)
                {
                    int currentNumberScheduled = status["currentNumberScheduled"]?.Value<int>() ?? 0;
                    int desiredNumberScheduled = status["desiredNumberScheduled"]?.Value<int>() ?? 0;
                    int numberUnavailable = status["numberUnavailable"]?.Value<int>() ?? 0;

                    if (currentNumberScheduled == desiredNumberScheduled && numberUnavailable == 0)
                    {
                        statuses["Running"]++;
                    }
                    else if (numberUnavailable > 0)
                    {
                        statuses["Failed"]++;
                    }
                }
            }

            return statuses;
        }

        private Dictionary<string, int> AnalyzeDeploymentStatus(JObject data)
        {
            if (data == null) return null;

            var statuses = new Dictionary<string, int>
    {
        { "Running", 0 },
        { "Failed", 0 },
        { "Succeeded", 0 }
    };

            foreach (var item in data["items"])
            {
                var status = item["status"];
                if (status != null)
                {
                    bool isAvailable = false;
                    bool isProgressing = false;
                    bool isFailed = false;

                    var conditions = status["conditions"];
                    if (conditions != null)
                    {
                        foreach (var condition in conditions)
                        {
                            string type = condition["type"]?.Value<string>();
                            string conditionStatus = condition["status"]?.Value<string>();

                            if (type == "Available" && conditionStatus == "True")
                            {
                                isAvailable = true;
                            }
                            else if (type == "Progressing" && conditionStatus == "True")
                            {
                                isProgressing = true;
                            }
                            else if (type == "Available" && conditionStatus == "False")
                            {
                                isFailed = true;
                            }
                        }
                    }

                    if (isAvailable && isProgressing)
                    {
                        statuses["Running"]++;
                    }
                    else if (isFailed)
                    {
                        statuses["Failed"]++;
                    }
                    else if (isAvailable && !isProgressing)
                    {
                        statuses["Succeeded"]++;
                    }
                }
            }

            return statuses;
        }

        private Dictionary<string, int> AnalyzeJobStatus(JObject data)
        {
            if (data == null) return null;

            var statuses = new Dictionary<string, int>
    {
        { "Running", 0 },
        { "Failed", 0 },
        { "Succeeded", 0 }
    };

            foreach (var item in data["items"])
            {
                var status = item["status"];
                if (status != null)
                {
                    int active = status["active"]?.Value<int>() ?? 0;
                    int failed = status["failed"]?.Value<int>() ?? 0;
                    int succeeded = status["succeeded"]?.Value<int>() ?? 0;

                    statuses["Running"] += active;
                    statuses["Failed"] += failed;
                    statuses["Succeeded"] += succeeded;
                }
            }

            return statuses;
        }

        private Dictionary<string, int> AnalyzePodStatus(JObject data)
        {
            if (data == null) return null;

            var statuses = new Dictionary<string, int>
    {
        { "Running", 0 },
        { "Failed", 0 },
        { "Succeeded", 0 }
    };

            foreach (var item in data["items"])
            {
                var status = item["status"];
                if (status != null)
                {
                    string phase = status["phase"]?.Value<string>();

                    if (phase == "Running")
                    {
                        statuses["Running"]++;
                    }
                    else if (phase == "Succeeded")
                    {
                        statuses["Succeeded"]++;
                    }
                    else if (phase == "Failed" || phase == "Unknown" || phase == "Pending")
                    {
                        statuses["Failed"]++;
                    }
                }
            }

            return statuses;
        }

        private Dictionary<string, int> AnalyzeReplicaSetStatus(JObject data)
        {
            if (data == null) return null;

            var statuses = new Dictionary<string, int>
    {
        { "Running", 0 },
        { "Failed", 0 }
    };

            foreach (var item in data["items"])
            {
                var status = item["status"];
                if (status != null)
                {
                    int readyReplicas = status["readyReplicas"]?.Value<int>() ?? 0;
                    int replicas = status["replicas"]?.Value<int>() ?? 0;

                    if (readyReplicas == replicas)
                    {
                        statuses["Running"]++;
                    }
                    else
                    {
                        statuses["Failed"]++;
                    }
                }
            }

            return statuses;
        }


        private void ShowPieChart(string title, Dictionary<string, int> statuses, Chart chart)
        {
            if (statuses == null || statuses.Values.Sum() == 0)
            {
                chart.Visible = false;
                return;
            }

            chart.Visible = true;
            chart.Series.Clear();
            chart.Titles.Clear();

            var series = new Series
            {
                Name = title,
                IsVisibleInLegend = true,
                ChartType = SeriesChartType.Pie
            };

            double total = statuses.Values.Sum();

            foreach (var status in statuses)
            {
                if (status.Value > 0)
                {
                    DataPoint point = new DataPoint
                    {
                        AxisLabel = "",
                        LegendText = status.Key,
                        YValues = new double[] { status.Value },
                        Label = $"{status.Value / total:P0}"
                    };
                    series.Points.Add(point);
                }
            }

            chart.Series.Add(series);

            Title chartTitle = new Title
            {
                Text = title,
                Docking = Docking.Top,
                Font = new Font("Arial", 14, FontStyle.Bold)
            };
            chart.Titles.Add(chartTitle);

            chart.Legends.Clear();
            Legend legend = new Legend
            {
                Docking = Docking.Bottom,
                Alignment = StringAlignment.Center
            };
            chart.Legends.Add(legend);

            foreach (DataPoint point in series.Points)
            {
                point["PieLabelStyle"] = "Inside"; 
                point["PieDrawingStyle"] = "SoftEdge"; 
            }
        }

        private void buttonWizard_Click(object sender, EventArgs e)
        {
            deploymentNameForm deploymentNameForm = new deploymentNameForm();
            deploymentNameForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            deploymentNameForm.Show();
        }
    }
}

