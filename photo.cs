using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace UnlimiTG
{
    public partial class photo : Form
    {

        public string TOKEN { get; set; }
        public string CHAT { get; set; }

        public photo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Form1 f1 = new Form1();
                WebClient wc = new WebClient();
                String type = textBox4.Text;
                String api = "https://api.telegram.org/bot" + textBox2.Text + "/send" + type + "?chat_id=" + textBox3.Text + "&" + type + "=" + textBox1.Text;
                wc.DownloadString(api);
            }
            catch (Exception lmao)
            {
                MessageBox.Show("An error has occured, please check that the group id and the token are right", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void photo_Load(object sender, EventArgs e)
        {
            if (File.Exists("ultoken.txt"))
            {
                textBox2.Text = File.ReadAllText("ultoken.txt");
            }
        }

    }
}
