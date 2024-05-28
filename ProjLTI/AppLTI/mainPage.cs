using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

            panelDashboard.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelDashboard.Width, panelDashboard.Height, 30, 30));
            panelMainPage.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelMainPage.Width, panelMainPage.Height, 30, 30));

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
                    choices.Add(new string[] { "pods", "nodes", "terminal", "namespaces", "deployments", "services", "ingress", "web page"});
                    GrammarBuilder gb = new GrammarBuilder();
                    gb.Append(choices);
                    gb.Culture = recognizer.RecognizerInfo.Culture;
                    Grammar g = new Grammar(gb);

                    recognizer.LoadGrammar(g);
                    recognizer.RecognizeAsync(RecognizeMode.Multiple);

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
                speech.SpeakAsync("Redirecting to" + result);

                Invoke(new Action(() =>
                {
                    if (result == "pods")
                    {
                        podsForm podsForm = new podsForm();
                        podsForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
                        podsForm.Show();
                        this.Hide();
                    }
                    else if (result == "nodes")
                    {
                        nodesForm nodesForm = new nodesForm();
                        nodesForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
                        nodesForm.Show();
                        this.Hide();
                    }
                    else if (result == "terminal")
                    {
                        sshConection sshConection = new sshConection();
                        sshConection.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
                        sshConection.Show();
                        this.Hide();
                    }
                    else if (result == "namespaces")
                    {
                        namespacesForm namespacesForm = new namespacesForm();
                        namespacesForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
                        namespacesForm.Show();
                        this.Hide();
                    }
                    else if (result == "deployments")
                    {
                        deploymentsForm deploymentsForm = new deploymentsForm();
                        deploymentsForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey, deploymentsForm);
                        deploymentsForm.Show();
                        this.Hide();
                    }
                    else if (result == "services")
                    {
                        servicesForm servicesForm = new servicesForm();
                        servicesForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
                        servicesForm.Show();
                        this.Hide();
                    }
                    else if (result == "ingress")
                    {
                        ingressForm ingressForm = new ingressForm();
                        ingressForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
                        ingressForm.Show();
                        this.Hide();
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

        private void mainPage_Load(object sender, EventArgs e)
        {
            textBoxIP.Text = username + " - " + routerIp + ":" + portoSSH;
        }

        private void buttonPods_Click_1(object sender, EventArgs e)
        {
            podsForm podsForm = new podsForm();
            podsForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            podsForm.Show();
            this.Dispose();
        }

        private void buttonNodes_Click_1(object sender, EventArgs e)
        {
            nodesForm nodesForm = new nodesForm();
            nodesForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            nodesForm.Show();
            this.Dispose();
        }

        private void btnTerminal_Click_1(object sender, EventArgs e)
        {
            sshConection sshConection = new sshConection();
            sshConection.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            sshConection.Show();
            this.Dispose();
        }

        private void buttonNameSpaces_Click_1(object sender, EventArgs e)
        {
            namespacesForm namespacesForm = new namespacesForm();
            namespacesForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey);
            namespacesForm.Show();
            this.Dispose();
        }

        private void buttonDeployments_Click_1(object sender, EventArgs e)
        {
            deploymentsForm deploymentsForm = new deploymentsForm();
            deploymentsForm.SetCredentials(routerIp, username, password, portoSSH, portoAPI, authKey, deploymentsForm);
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

        private void buttonActivateMic_Click(object sender, EventArgs e)
        {
            buttonMutMic.BringToFront();
        }

        private void buttonMutMic_Click(object sender, EventArgs e)
        {
            buttonActivateMic.BringToFront();
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

        private void OpenRouterPage(string routerIp,string porto, string authkey)
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

    }
}
