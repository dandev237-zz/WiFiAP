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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.label2.Text = wc.getStatus();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // StopAP button
        private void button2_Click(object sender, EventArgs e)
        {
            this.button2.Enabled = false;
            this.label3.Text = wc.StopAP();
            this.label2.Text = wc.getStatus();
            this.button2.Enabled = true;
        }

        // StartAP button
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            this.label3.Text = wc.StartAP();
            this.label2.Text = wc.getStatus();
            this.button1.Enabled = true;
        }
    }
}
