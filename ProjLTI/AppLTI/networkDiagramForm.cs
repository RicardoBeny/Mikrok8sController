using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace AppLTI
{
    public partial class networkDiagramForm : Form
    {
        private string routerIp;
        private string username;
        private string password;
        private string portoSSH;
        private string portoAPI;
        private string authKey;
        private List<string> nodeNames = new List<string>();
        private Dictionary<string, List<string>> nodePods = new Dictionary<string, List<string>>();

        public networkDiagramForm()
        {
            InitializeComponent();
            InitializeGraph();
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

        private void InitializeGraph()
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                Pen pen = new Pen(Color.Black, 2);
                int centerX = pictureBox1.Width / 2;

                int nodeVerticalSpacing = 240;

                if (nodeNames.Count > 0)
                {
                    Point root = new Point(centerX, 50);
                    DrawNode(g, root, nodeNames[0]);
                    DrawPods(g, root, nodeNames[0], pen);

                    int currentY = root.Y + nodeVerticalSpacing;
                    int nodesPerRow = nodeNames.Count - 1;
                    int nodeHorizontalSpacing = pictureBox1.Width / (nodesPerRow + 1);

                    for (int i = 1; i < nodeNames.Count; i++)
                    {
                        int currentX = (i * nodeHorizontalSpacing);

                        Point childPosition = new Point(currentX, currentY);

                        g.DrawLine(pen, root, childPosition);
                        DrawNode(g, childPosition, nodeNames[i]);
                        DrawPods(g, childPosition, nodeNames[i], pen);
                    }
                }
            }

            pictureBox1.Image = bitmap;
        }

        private void DrawNode(Graphics g, Point position, string text)
        {
            int diameter = 100;
            Rectangle rect = new Rectangle(position.X - diameter / 2, position.Y - diameter / 2, diameter, diameter);

            g.FillEllipse(Brushes.LightBlue, rect);
            g.DrawEllipse(Pens.Black, rect);

            float fontSize = 12;
            Font font = new Font("Arial", fontSize, FontStyle.Regular);
            SizeF textSize = g.MeasureString(text, font);

            PointF textPosition = new PointF(
                position.X - textSize.Width / 2,
                position.Y - textSize.Height / 2);

            g.DrawString(text, font, Brushes.Black, textPosition);
            font.Dispose();
        }

        private void DrawPods(Graphics g, Point nodePosition, string nodeName, Pen pen)
        {
            if (nodePods.ContainsKey(nodeName))
            {
                List<string> pods = nodePods[nodeName];
                int diameter = 90;
                int podSpacingX = 80;
                int podSpacingY = 80;

                int startX = nodePosition.X - (pods.Count * podSpacingX) / 2;
                int startY = nodePosition.Y + 60;

                for (int i = 0; i < pods.Count; i++)
                {
                    int x = startX + (i * podSpacingX);
                    int y = startY + (i % 2) * podSpacingY;

                    Rectangle rect = new Rectangle(x - diameter / 2, y - diameter / 2, diameter, diameter);

                    g.FillEllipse(Brushes.LightGreen, rect);
                    g.DrawEllipse(Pens.Black, rect);

                    Font font = new Font("Arial", 9, FontStyle.Regular);
                    SizeF textSize = g.MeasureString(pods[i], font);

                    PointF textPosition = new PointF(
                        x - textSize.Width / 2,
                        y - textSize.Height / 2);

                    g.DrawString(pods[i], font, Brushes.Black, textPosition);
                    font.Dispose();
                    g.DrawLine(pen, nodePosition, new Point(x, y));
                }
            }
        }


        private async Task LoadNodes(string routerIp, string portoAPI, string authToken)
        {
            try
            {
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

                        nodeNames.Clear();
                        string rootNodeName = null;
                        foreach (var item in items)
                        {
                            string name = (string)item["metadata"]["name"];
                            string nodeArgs = (string)item["metadata"]["annotations"]["k3s.io/node-args"];

                            nodeNames.Add(name);

                            if (nodeArgs.Contains("server") && rootNodeName == null)
                            {
                                rootNodeName = name;
                            }
                        }

                        if (rootNodeName != null)
                        {
                            nodeNames.Remove(rootNodeName);
                            nodeNames.Insert(0, rootNodeName);
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

        private async Task LoadPods(string routerIp, string portoAPI, string authToken)
        {
            try
            {
                string url = $"https://{routerIp}:{portoAPI}/api/v1/pods";

                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        JObject podsData = JObject.Parse(responseBody);
                        JArray podsArray = (JArray)podsData["items"];

                        nodePods.Clear();
                        foreach (JObject podObject in podsArray)
                        {
                            string podName = (string)podObject["metadata"]["name"];
                            string nodeName = (string)podObject["spec"]["nodeName"];

                            if (!string.IsNullOrEmpty(podName) && !string.IsNullOrEmpty(nodeName))
                            {
                                if (!nodePods.ContainsKey(nodeName))
                                {
                                    nodePods[nodeName] = new List<string>();
                                }
                                nodePods[nodeName].Add(podName);
                            }
                        }
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Falha ao carregar pods. Mensagem de erro: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar os pods: " + ex.Message);
            }
        }


        private async void networkDiagramForm_Load(object sender, EventArgs e)
        {
            await LoadNodes(routerIp, portoAPI, authKey);
            await LoadPods(routerIp, portoAPI, authKey);
            InitializeGraph();
        }
    }
}
