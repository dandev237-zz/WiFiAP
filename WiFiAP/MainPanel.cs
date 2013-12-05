using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WiFiAP
{
    public partial class MainPanel : Form
    {
        public MainPanel()
        {
            wc = new WifiController();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            this.button2.Enabled = false;
            this.label4.Text = wc.StartAP();
            this.label1.Text = wc.getStatus().ToUpper();
            this.button1.Enabled = true;
            this.button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.button2.Enabled = false;
            this.button1.Enabled = false;
            this.label4.Text = wc.StopAP();
            this.label1.Text = wc.getStatus().ToUpper();
            this.button2.Enabled = true;
            this.button1.Enabled = true;
        }

        private void MainPanel_Load(object sender, EventArgs e)
        {
            this.label1.Text = wc.getStatus().ToUpper();
            this.label3.Text = wc.getSSID();
        }

    }
}
