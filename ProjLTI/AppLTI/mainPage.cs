using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AppLTI
{
    public partial class mainPage : Form
    {
        private string routerIp;
        private string username;
        private string password;
        private string porto;

        public mainPage()
        {
            InitializeComponent();
        }

        public void SetCredentials(string routerIp, string username, string password, string porto)
        {
            this.routerIp = routerIp;
            this.username = username;
            this.password = password;
            this.porto = porto;
        }

        private void mainPage_Load(object sender, EventArgs e)
        {
            textBoxIP.Text = username + " - " + routerIp+":"+porto;
        }

        private void btnTerminal_Click(object sender, EventArgs e)
        {
            sshConection sshConection = new sshConection();
            sshConection.SetCredentials(routerIp, username, password, porto);
            sshConection.Show();
            this.Dispose();
        }
       
    }
}
