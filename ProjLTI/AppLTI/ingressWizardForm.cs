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
using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace AppLTI
{
    public partial class ingressWizardForm : Form
    {
        private IWebDriver driver;
        private string routerIp;
        private string portoAPI;
        private string authKey;
        private string namespacename;
        private string servicename;
        private string porto;
        public ingressWizardForm()
        {
            InitializeComponent();
        }

        public void SetCredentials(string routerIp, string portoAPI, string authKey, string servicename, string namespacename, string port)
        {
            this.routerIp = routerIp;
            this.portoAPI = portoAPI;
            this.authKey = authKey;
            this.namespacename = namespacename;
            this.servicename = servicename;
            this.porto = port;
        }

        private async void buttonFinish_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNomeAdd.Text))
            {
                MessageBox.Show("Campo nome tem de ser preenchido.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxHost.Text))
            {
                MessageBox.Show("Campo URL tem de ser preenchido.");
                return;
            }

            await CreateIngress(routerIp, portoAPI, authKey, namespacename);
        }

        private async Task CreateIngress(string routerIp, string portoAPI, string authToken, string namespacename)
        {
            int portaservico = int.Parse(porto);

            var metadata = new JObject
            {
                ["name"] = textBoxNomeAdd.Text,
                ["namespace"] = namespacename,
                ["annotations"] = new JObject
                {
                    ["nginx.ingress.kubernetes.io/rewrite-target"] = "/"
                }
            };

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
                        escreverNoHosts(textBoxHost.Text, routerIp);
                        OpenIngressPage(textBoxHost.Text);
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
    }
}
