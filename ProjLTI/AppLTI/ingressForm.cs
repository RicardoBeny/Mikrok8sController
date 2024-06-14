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
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Renci.SshNet;
using System.IO;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Runtime.InteropServices;

namespace AppLTI
{
    public partial class ingressForm : Form
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
        private bool waitForName = false;
        private bool waitForUrl = false;
        private bool waitForPort = false;
        private bool waitForNamespace = false;
        private bool waitForService = false;
        private bool waitForOwner = false;
        private bool waitForPurpose = false;
        private List<string> dynamicChoices = new List<string>();

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
        public ingressForm()
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
            buttonCreateDeployments.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonCreateDeployments.Width, buttonCreateDeployments.Height, 5, 5));
            buttonDeleteDeployments.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonDeleteDeployments.Width, buttonDeleteDeployments.Height, 5, 5));
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
                    UpdateSpeechRecognitionChoices();
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

        private void UpdateSpeechRecognitionChoices()
        {
            Choices choices = new Choices();
            choices.Add(new string[] { "create ingress", "name", "ingressname", "examplename", "nameexample","url","namespaces", "namespace", "service name", "port","80","presentationurl.comm","22","443","owner","purpose" });
            choices.Add(dynamicChoices.ToArray());

            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(choices);
            gb.Culture = recognizer.RecognizerInfo.Culture;
            Grammar g = new Grammar(gb);

            recognizer.UnloadAllGrammars();
            recognizer.LoadGrammar(g);
        }

        private void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string result = e.Result.Text;

            Task.Run(() =>
            {
                Invoke(new Action(() =>
                {
                    if (waitForName)
                    {
                        textBoxNomeAdd.Text  = result;
                        waitForName = false;
                    }else if (waitForUrl)
                    {
                        textBoxHost.Text = result; 
                        waitForUrl = false;
                    }
                    else if (waitForPort)
                    {
                        textBoxPortaServico.Text = result;
                        waitForPort = false;
                    }
                    else if (waitForNamespace)
                    {
                        comboBoxNamespaceCriar.SelectedItem = result;
                        waitForNamespace = false;
                    }
                    else if (waitForService)
                    {
                        comboBoxNomeDoServico.SelectedItem = result;
                        waitForService = false;
                    }
                    else if (waitForOwner)
                    {
                        textBoxOwner.Text = result;
                        waitForOwner = false;
                    }
                    else if (waitForPurpose)
                    {
                        textBoxproposito.Text = result;
                        waitForPurpose = false;
                    }
                    else
                    {
                        if (result == "create ingress")
                        {
                            buttonCreateDeployments_Click(buttonCreateDeployments, EventArgs.Empty);
                        }
                        else if (result == "name")
                        {
                            waitForName = true;
                        }
                        else if (result == "url")
                        {
                            waitForUrl = true;
                        }
                        else if (result == "port")
                        {
                            waitForPort = true;
                        }
                        else if ((result == "namespaces") || (result == "namespace"))
                        {
                            waitForNamespace = true;
                        }
                        else if (result == "service name")
                        {
                            waitForService = true;
                        }
                        else if (result == "owner")
                        {
                            waitForOwner = true;
                        }
                        else if (result == "purpose")
                        {
                            waitForPurpose = true;
                        }
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

        private void buttonDeployments_Click(object sender, EventArgs e)
        {
            StopMicrophone();
            deploymentsForm deploymentsForm = new deploymentsForm();
            deploymentsForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            deploymentsForm.Show();
            this.Dispose();
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

            await LoadIngress(routerIp, portoAPI, authKey, namespacename);
        }

        public async Task LoadIngress(string routerIp, string portoAPI, string authToken, string namespacename)
        {
            try
            {
                string url;
                listBoxIngress.Items.Clear();
                comboBoxIngresses.Items.Clear();

                if (namespacename == "Todos")
                {
                    url = $"https://{routerIp}:{portoAPI}/apis/networking.k8s.io/v1/ingresses";
                }
                else
                {
                    url = $"https://{routerIp}:{portoAPI}/apis/networking.k8s.io/v1/namespaces/{namespacename}/ingresses";
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

                        JObject ingressData = JObject.Parse(responseBody);
                        JArray ingressArray = (JArray)ingressData["items"];

                        if (ingressArray.Count == 0)
                        {
                            listBoxIngress.Items.Add("Não existe nenhum ingress");
                            return;
                        }

                        int maxNameLength = 0;
                        foreach (JObject ingressObject in ingressArray)
                        {
                            string name = (string)ingressObject["metadata"]["name"];
                            maxNameLength = Math.Max(maxNameLength, name.Length);
                        }

                        string nameHeader = "Ingress Name".PadRight(maxNameLength);
                        string hostHeader = "Host";
                        string pathHeader = "Path";
                        string createdHeader = "Age";

                        listBoxIngress.Items.Add($"{nameHeader}\t\t{hostHeader}\t\t\t{pathHeader}\t\t{createdHeader}");

                        foreach (JObject ingressObject in ingressArray)
                        {
                            string name = (string)ingressObject["metadata"]["name"];
                            JArray rulesArray = (JArray)ingressObject["spec"]["rules"];

                            string created = (string)ingressObject["metadata"]["creationTimestamp"];
                            DateTime creationDateTime = DateTime.ParseExact(created, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                            TimeSpan timeSinceCreation = DateTime.Now - creationDateTime;
                            string timeAgo = $"{(int)timeSinceCreation.TotalDays} d, {(int)timeSinceCreation.Hours} h, {(int)timeSinceCreation.Minutes} m ago";

                            foreach (JObject rule in rulesArray)
                            {
                                string host = (string)rule["host"];
                                JArray pathsArray = (JArray)rule["http"]["paths"];

                                foreach (JObject pathObject in pathsArray)
                                {
                                    string path = (string)pathObject["path"];
                                    listBoxIngress.Items.Add($"{name.PadRight(maxNameLength)}\t\t{host}\t\t{path}\t\t{timeAgo}");
                                }
                            }

                            comboBoxIngresses.Items.Add($"Nome: {name}");
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Failed to load Ingresses. Error message: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading Ingresses: " + ex.Message);
            }
        }

        private async void ingressForm_Load(object sender, EventArgs e)
        {
            textBoxIP.Text = username + " - " + routerIp + ":" + portoSSH;

            await LoadNamespaces(routerIp, portoAPI, authKey);
            await LoadServices(routerIp, portoAPI, authKey);
            await LoadIngress(routerIp, portoAPI, authKey, "Todos");
        }

        private async Task LoadServices(string routerIp, string portoAPI, string authToken)
        {
            try
            {
                string url;
                comboBoxNomeDoServico.Items.Clear();

                url = $"https://{routerIp}:{portoAPI}/api/v1/services";
                
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

                        foreach (JObject serviceObject in servicesArray)
                        {
                            string name = (string)serviceObject["metadata"]["name"];

                            comboBoxNomeDoServico.Items.Add($"{name}");
                            dynamicChoices.Add($"{name}");
                        }
                        UpdateSpeechRecognitionChoices();
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
                            dynamicChoices.Add($"{name}");
                        }
                        UpdateSpeechRecognitionChoices();
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
            StopMicrophone();
            podsForm podsForm = new podsForm();
            podsForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            podsForm.Show();
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

        private void buttonNameSpaces_Click(object sender, EventArgs e)
        {
            StopMicrophone();
            namespacesForm namespacesForm = new namespacesForm();
            namespacesForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            namespacesForm.Show();
            this.Dispose();
        }

        private void buttonNodes_Click(object sender, EventArgs e)
        {
            StopMicrophone();
            nodesForm nodesForm = new nodesForm();
            nodesForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            nodesForm.Show();
            this.Dispose();
        }

        private void btnTerminal_Click(object sender, EventArgs e)
        {
            StopMicrophone();
            sshConection sshConection = new sshConection();
            sshConection.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            sshConection.Show();
            this.Dispose();
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

            if (string.IsNullOrWhiteSpace(textBoxHost.Text))
            {
                MessageBox.Show("Campo URL tem de ser preenchido.");
                return;
            }

            if (comboBoxNomeDoServico.SelectedIndex == -1)
            {
                MessageBox.Show("Namespace tem de ser selecionada.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxPortaServico.Text))
            {
                MessageBox.Show("Campo porta do serviço tem de ser preenchido.");
                return;
            }


            string selectedItemText = comboBoxNamespaceCriar.Items[comboBoxNamespaceCriar.SelectedIndex].ToString();
            string namespacename = selectedItemText.Trim();

            await CreateIngress(routerIp, portoAPI, authKey, namespacename);
        }

        private async Task CreateIngress(string routerIp, string portoAPI, string authToken, string namespacename)
        {
            string selectedItemText1 = comboBoxNomeDoServico.Items[comboBoxNomeDoServico.SelectedIndex].ToString();
            string servicename = selectedItemText1.Trim();

            string proposito = null, owner = null;

            int portaservico = int.Parse(textBoxPortaServico.Text);

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
                ["annotations"] = new JObject
                {
                    ["nginx.ingress.kubernetes.io/rewrite-target"] = "/"
                }
            };

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
                ["apiVersion"] = "networking.k8s.io/v1",
                ["kind"] = "Ingress",
                ["metadata"] = metadata,
                ["spec"] = new JObject
                {
                    ["rules"] = new JArray
            {
                new JObject
                {
                    ["host"] = textBoxHost.Text,
                    ["http"] = new JObject
                    {
                        ["paths"] = new JArray
                        {
                            new JObject
                            {
                                ["path"] = "/",
                                ["pathType"] = "Prefix",
                                ["backend"] = new JObject
                                {
                                    ["service"] = new JObject
                                    {
                                        ["name"] = servicename,
                                        ["port"] = new JObject
                                        {
                                            ["number"] = portaservico
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
                }
            };
            try
            {
                string url = $"https://{routerIp}:{portoAPI}/apis/networking.k8s.io/v1/namespaces/{namespacename}/ingresses";

                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                    var content = new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Ingress created successfully.");
                        escreverNoHosts(textBoxHost.Text,routerIp);
                        await LoadIngress(routerIp, portoAPI, authToken, namespacename);
                        ClearFormFields();
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Failed to create Ingress. Error message: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while creating Ingress: " + ex.Message);
            }
        }

        private void ClearFormFields()
        {
            comboBoxNamespaceCriar.SelectedIndex = -1;
            comboBoxNamespaceCriar.Text = "";
            textBoxNomeAdd.Clear();
            textBoxHost.Clear();
            comboBoxNomeDoServico.SelectedIndex = -1;
            comboBoxNomeDoServico.Text = "";
            textBoxPortaServico.Clear();
            textBoxproposito.Clear();
            textBoxOwner.Clear();
        }


        private void escreverNoHosts(string host, string routerIp)
        {
            string hostsFilePath = @"C:\Windows\System32\drivers\etc\hosts";
            string newEntry = $"\n{routerIp}\t{host}";
            try
            {
                if (!IsAdministrator())
                {
                    MessageBox.Show("This operation requires administrative privileges. Please run the application as an administrator.");
                    return;
                }
                using (StreamWriter sw = File.AppendText(hostsFilePath))
                {
                    sw.WriteLine(newEntry);
                }

                MessageBox.Show("Entry added to hosts file successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while writing to the hosts file: " + ex.Message);
            }
        }

        private bool IsAdministrator()
        {
            var identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            var principal = new System.Security.Principal.WindowsPrincipal(identity);
            return principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
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

            if (comboBoxIngresses.SelectedIndex == -1)
            {
                MessageBox.Show("Deployment tem de ser selecionado.");
                return;
            }

            string selectedItemText1 = comboBoxIngresses.Items[comboBoxIngresses.SelectedIndex].ToString();
            string ingressname = selectedItemText1.Substring(selectedItemText1.IndexOf("Nome:") + 5).Split(';')[0].Trim();
            await DeleteIngress(routerIp, portoAPI, authKey, namespacename, ingressname);
        }

        private async Task DeleteIngress(string routerIp, string portoAPI, string authToken, string namespaceName, string ingressName)
        {
            try
            {
                string url = $"https://{routerIp}:{portoAPI}/apis/networking.k8s.io/v1/namespaces/{namespaceName}/ingresses/{ingressName}";

                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                    HttpResponseMessage response = await client.DeleteAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Ingress eliminado com sucesso.");
                        await LoadIngress(routerIp, portoAPI, authToken, namespaceName);
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao eliminar o Ingress. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao eliminar o Ingress: " + ex.Message);
            }
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

        private void listBoxIngress_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxIngress.SelectedIndex != -1)
            {
                string selectedItem = listBoxIngress.SelectedItem.ToString();

                string[] parts = selectedItem.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length > 0)
                {
                    string ingressName = parts[1].Trim();
                    OpenIngressPage(ingressName);
                }
            }
        }

        private void OpenIngressPage(string ingressname)
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

                driver.Navigate().GoToUrl($"https://{ingressname}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void labelDashboard_Click(object sender, EventArgs e)
        {
            StopMicrophone();
            mainPage mainPage = new mainPage();
            mainPage.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            mainPage.Show();
            this.Dispose();
        }

        private void panelDashboard_click(object sender, MouseEventArgs e)
        {
            StopMicrophone();
            mainPage mainPage = new mainPage();
            mainPage.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            mainPage.Show();
            this.Dispose();
        }

        private void panelPods_click(object sender, MouseEventArgs e)
        {
            StopMicrophone();
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
            StopMicrophone();
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
            StopMicrophone();
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

        private void panelNamespaces_MouseClick(object sender, MouseEventArgs e)
        {
            StopMicrophone();
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
            StopMicrophone();
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
            StopMicrophone();
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
            StopMicrophone();
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
