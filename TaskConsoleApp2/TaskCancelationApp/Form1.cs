using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskCancelationApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            Task<HttpResponseMessage> mytask;
            mytask= new HttpClient().GetAsync("https://localhost:7059/Privacy", cts.Token);
            await mytask;
            var content = await mytask.Result.Content.ReadAsStringAsync();
            richTextBox1.Text = content;
        }

    }
}
