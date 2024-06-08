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
        private bool waitForNextWord = false;
        public ingressForm()
        {
            InitializeComponent();
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
                    choices.Add(new string[] { "finish", "name","ingressname","examplename","nameexample" });
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

        private void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string result = e.Result.Text;

            Task.Run(() =>
            {
                Invoke(new Action(() =>
                {
                    if (waitForNextWord)
                    {
                        textBoxNomeAdd.Text  = result;
                        waitForNextWord = false;
                    }
                    else
                    {
                        if (result == "finish")
                        {
                            buttonActivateMic.BringToFront();
                            StopMicrophone();
                            buttonCreateDeployments_Click(buttonCreateDeployments, EventArgs.Empty);
                        }
                        else if (result == "name")
                        {
                            waitForNextWord = true;
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
            MessageBox.Show(requestBody.ToString());
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
    }
}
