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



    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("ultoken.txt"))
            {
                textBox1.Text = File.ReadAllText("ultoken.txt");
            }
            photo ph = new photo();
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sendMessage(textBox1.Text, textBox2.Text, textBox3.Text);

            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                File.WriteAllText("ultoken.txt", textBox1.Text);
            }
        }

        private void sendMessage(String token, String group, String text)
        {
            try
            {
                if (!String.IsNullOrEmpty(text) && !String.IsNullOrEmpty(token) && !String.IsNullOrEmpty(group))
                {
                    WebClient wc = new WebClient();
                    String full_api = "https://api.telegram.org/bot" + token + "/sendMessage?text=" + text + "&chat_id=" + group + "&parse_mode=Markdown";
                    wc.DownloadString(full_api);
                }
                else
                {
                    MessageBox.Show("Fill Token,Text,Group please");
                }
            }
            catch (Exception lol)
            {
                MessageBox.Show("An error has occured, please check that the group id and the token are right", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void sendPhotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            photo ph = new photo();
            ph.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            photo ph = new photo();
            ph.TOKEN = textBox1.Text;
            ph.CHAT = textBox2.Text;
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                sendMessage(textBox1.Text, textBox2.Text, textBox3.Text);

                if (!String.IsNullOrEmpty(textBox1.Text))
                {
                    File.WriteAllText("ultoken.txt", textBox1.Text);
                }
            }

            if (e.Control && e.KeyCode == Keys.A)
            {
                textBox3.SelectAll();
            }

        }


    }
}
