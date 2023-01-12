namespace Calculater
{
    partial class BackgroundProcess
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CheckKeyPress = new System.Windows.Forms.Timer(this.components);
            this.ImageDetect = new System.Windows.Forms.Timer(this.components);
            this.CheckConnection = new System.Windows.Forms.Timer(this.components);
            this.CommandDetect = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // CheckKeyPress
            // 
            this.CheckKeyPress.Tick += new System.EventHandler(this.CheckKeyPress_Tick);
            // 
            // ImageDetect
            // 
            this.ImageDetect.Tick += new System.EventHandler(this.ImageDetect_Tick);
            // 
            // CheckConnection
            // 
            this.CheckConnection.Interval = 5000;
            this.CheckConnection.Tick += new System.EventHandler(this.CheckConnection_Tick);
            // 
            // CommandDetect
            // 
            this.CommandDetect.Interval = 5000;
            this.CommandDetect.Tick += new System.EventHandler(this.CommandDetect_Tick);
            // 
            // BackgroundProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(10, 10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BackgroundProcess";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "BackgroundProcess";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.BackgroundProcess_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer CheckKeyPress;
        private System.Windows.Forms.Timer ImageDetect;
        private System.Windows.Forms.Timer CheckConnection;
        private System.Windows.Forms.Timer CommandDetect;
    }
}