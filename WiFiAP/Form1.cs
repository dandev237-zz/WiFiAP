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

        // StartAP button
        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = wc.StartAP();
            label2.Text = wc.getStatus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = wc.getStatus();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // StopAP
        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
