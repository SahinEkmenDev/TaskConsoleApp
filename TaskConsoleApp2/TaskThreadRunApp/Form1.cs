﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskThreadRunApp
{
    public partial class Form1 : Form
    {

        public static int counter { get; set; } = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
          var atask = Go(progressBar1);
           var btask= Go(progressBar2);

            await Task.WhenAll( atask, btask);


        }

        public async Task Go(ProgressBar pb)
        {
           await    Task.Run(() => {

                Enumerable.Range(1, 100).ToList().ForEach(i =>
                {

                    Thread.Sleep(100);
                    pb.Invoke((MethodInvoker)delegate {pb.Value = i; });    


                });

            });
           
        }

        private void BtnCounter_Click(object sender, EventArgs e)
        {
            BtnCounter.Text = counter++.ToString();
        }
    }
}
