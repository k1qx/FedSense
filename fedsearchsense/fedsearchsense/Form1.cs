using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fedsearchsense
{

    // ik this code is shit but it works xddd

    public partial class Form1 : SkeetUI.skeetForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void skeetButton2_Click(object sender, EventArgs e)
        {
            Random bobuxman = new Random();
            MessageBox.Show($"Poggers! You just generated {bobuxman.Next(0, 69696969)} Bobux", "FedSense");
        }

        private void skeetButton1_Click(object sender, EventArgs e)
        {

        }

        private async void skeetButton1_Click_1Async(object sender, EventArgs e)
        {
            var Headers = new Dictionary<string, string>
            {
                { "search", skeetTextBox1.Text },
                { "key", "FuckingRetardNiggerMonkey" }  
            };
            var content = new FormUrlEncodedContent(Headers);


            HttpClient client = new HttpClient();
            var response = await client.PostAsync("http://www.example.com/recepticle.aspx", content);

            var responseString = await response.Content.ReadAsStringAsync();

            /*
            var webbobuxdeliverer = new WebClient();

            webbobuxdeliverer.Headers.Add("search", skeetTextBox1.Text);
            webbobuxdeliverer.Headers.Add("key", "FuckingRetardNiggerMonkey");

            string result = webbobuxdeliverer.DownloadString("https://fedsearch.cf/API/search_api.php");
            richTextBox1.Text = result;
            */
        }

        private void skeetButton1_Load(object sender, EventArgs e)
        {
            this.Text = "FedSense";
        }

        private async void skeetButton1_Click_1(object sender, EventArgs e)
        {
            if (skeetTextBox1.Text == string.Empty)
            {
                MessageBox.Show("You need to provide a Search!");
            }
            if (skeetTextBox2.Text == string.Empty)
            {
                MessageBox.Show("You need to provide a API Key!");
            }
            else
            {
                var Headers = new Dictionary<string, string>
            {
                { "search", skeetTextBox1.Text },
                { "key", skeetTextBox2.Text }
            };
                var content = new FormUrlEncodedContent(Headers);


                HttpClient client = new HttpClient();
                var response = await client.PostAsync("https://fedsearch.cf/API/search_api.php", content);

                var responseString = await response.Content.ReadAsStringAsync();


                richTextBox1.Text = responseString;
            }
        }
    }
}   
