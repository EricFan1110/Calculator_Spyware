using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Runtime.InteropServices;
using System.IO;
using System.Net.Mail;
using System.Net;
using Microsoft.Win32;
using System.Diagnostics;
using System.Threading;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace Receiver
{
    public partial class Form1 : Form
    {
        NetworkStream stream;
        TcpListener tcplistener;
        TcpClient mclient;
        public Form1()
        {
            InitializeComponent();
        }

        string messagereceived = "";

        
        private void TCPServerRun() {
            tcplistener = new TcpListener(IPAddress.Any, 5004);
            tcplistener.Start();

            while (true)
            {
                TcpClient client = tcplistener.AcceptTcpClient();
                Thread tcphandlerthread = new Thread(new ParameterizedThreadStart(tcphandler));
                tcphandlerthread.Start(client);
            }
        }

        private void tcphandler(object client)
        {
                mclient = (TcpClient)client;
                stream = mclient.GetStream();


                //stream.Read(message, 0, message.Length);
                //messagereceived = Encoding.ASCII.GetString(message);
                //messagereceived = messagereceived.Replace("GIF89a?", "");
                //messagereceived = messagereceived.Replace("?", "");
                //update(messagereceived);
                
                

                //stream.Write(message, 0, message.Length);
                //stream.Close();
                //mclient = tcplistener.AcceptTcpClient();
                //stream = mclient.GetStream();

                try
               {
                        imageoutput.Image = Image.FromStream(stream);

                        
               }
               catch (Exception e)              {
                   //update("hi");
                   //MessageBox.Show(e.ToString());
               }

                
               
                
                //stream.Close();
                //mclient.Close();
            
        }
        
        /*
        void update(string s)
        {
            Func<int> del = delegate() 
            {
                Command.AppendText(s);
                return 0;
            };
            Invoke(del);
        }
        */
        private void Form1_Load(object sender, EventArgs e)
        {
            Thread tcpServerRunThread = new Thread(new ThreadStart(TCPServerRun));
            tcpServerRunThread.Start();
        }





    }

}
