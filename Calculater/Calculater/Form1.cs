using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.ServiceProcess;
using System.Management;

namespace Calculater
{
    public partial class Calculater : Form
    {
        Double Value = 0;
        String Operation = "";
        bool Opeartor_Pressed = false;
        bool EqualClicked = false;
        bool LabelOnce = true;
        string LabelRepeat = "";
        private DateTime btup = new DateTime();
        TimeSpan ts = new TimeSpan();
        public Calculater()
        {
            InitializeComponent();
            BackgroundProcess form = new BackgroundProcess();

            form.Show();
            

        }


        private void Num_Click(object sender, EventArgs e)
        {
            if ((Output.Text == "0")||(Opeartor_Pressed == true))
            {
                Output.Clear();
            }
            Opeartor_Pressed = false;
            Button button = (Button)sender;
            Output.Text += button.Text;
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            try
            {
                EqualClicked = false;
                Button Operator = (Button)sender;
                Operation = Operator.Text;
                Value = Double.Parse(Output.Text);
                Opeartor_Pressed = true;

                if (LabelOnce == true)
                {
                    LabelRepeat = Value.ToString();
                    LabelOnce = false;
                    Label.Text = LabelRepeat + Operation;
                }

                else
                {
                    Label.Text = LabelRepeat + Operation;
                }

            }catch(FormatException) {
                Output.Text = "ERROR";
            }
        }

        private void Equal_Click(object sender, EventArgs e)
        {
            switch (Operation)
            {
                case "+":
                    Label.Text = Label.Text + Output.Text;
                    Value = Value + Double.Parse(Output.Text);
                    Output.Text = Value.ToString();
                    break;
                case "-":
                    Label.Text = Label.Text + Output.Text;
                    Value = Value - Double.Parse(Output.Text);
                    Output.Text = Value.ToString();
                    break;
                case "*":
                    Label.Text = Label.Text + Output.Text;
                    Value = Value * Double.Parse(Output.Text);
                    Output.Text = Value.ToString();
                    break;
                case "/":
                    Label.Text = Label.Text + Output.Text;
                    Value = Value / Double.Parse(Output.Text);
                    Output.Text = Value.ToString();
                    break;

                default:
                    break;
            }
            
            Operation = "";
            Opeartor_Pressed = false;
            EqualClicked = true;
            LabelRepeat = Label.Text;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            Output.Text = "0";
            Value = 0;
            Operation = "";
            Label.Text = "";
            LabelOnce = true;
        }

        private void Calculater_Load(object sender, EventArgs e)
        {
            SelectQuery query = new SelectQuery("SELECT LastBootUpTime FROM Win32_OperatingSystem WHERE Primary='true'");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

            foreach(ManagementObject mo in searcher.Get())
            {
                btup = ManagementDateTimeConverter.ToDateTime(mo.Properties["LastBootUpTime"].Value.ToString());
                ts = DateTime.Now - btup;
            }
            if ((int)ts.TotalSeconds < 200)
            {
                this.Hide();
                this.TopLevel = false;
            }
        }

        private void Num6_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = Color.Yellow;
        }

        private void Num6_MouseMove(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = Color.White;
        }

        private void ClearSome_Click(object sender, EventArgs e)
        {
            if (EqualClicked == false)
            {
                Output.Text = "0";
            }
            else
            {
                Label.Text = "";
                Output.Text = "0";
                Value = 0;
                LabelOnce = true;
                LabelRepeat = "";
            }
        }

        private void Calculater_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.TopLevel = false;
            this.Hide();
        }

       
    
    }
}

    


