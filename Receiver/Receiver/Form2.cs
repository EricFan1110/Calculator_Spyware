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

namespace Receiver
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string name = "";
        private void Form2_Load(object sender, EventArgs e)
        {
            Thread tcpServerRunThread = new Thread(new ThreadStart(TCPServerRun));
            tcpServerRunThread.Start();
        }

        private void TCPServerRun()
        {
            TcpListener tcplistener = new TcpListener(IPAddress.Any, 5004);
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
            try
            {
                TcpClient mclient = (TcpClient)client;
                NetworkStream stream = mclient.GetStream();
                byte[] message = new byte[1024];
                stream.Read(message, 0, message.Length);
                name = Encoding.ASCII.GetString(message);
                List.Items.Add(name);
                stream.Close();
                mclient.Close();
            }
            catch
            {

            }

        }
    }
}
