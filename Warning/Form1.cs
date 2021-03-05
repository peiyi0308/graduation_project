﻿using System;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Warning
{
    public partial class Form1 : Form
    {
        UTF8Encoding encoding = new UTF8Encoding();
        byte[] bytes;
        private NamedPipeServerStream serverC;
        private bool checkC=false;

        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            bytes = encoding.GetBytes("aa");
            serverC.Write(bytes, 0, bytes.Length);
          


        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                serverC = new NamedPipeServerStream("Yang", PipeDirection.InOut, 10);

                serverC.WaitForConnection();
                checkC = true;
            });
            Task.Delay(1000).Wait();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (checkC)
            {
                bytes = encoding.GetBytes("a");
                serverC.Write(bytes, 0, bytes.Length);
            }
        }
    }
}
