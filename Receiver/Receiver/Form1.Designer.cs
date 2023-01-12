namespace Receiver
{
    partial class Form1
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
            this.imageoutput = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageoutput)).BeginInit();
            this.SuspendLayout();
            // 
            // imageoutput
            // 
            this.imageoutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageoutput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imageoutput.Location = new System.Drawing.Point(12, 12);
            this.imageoutput.Name = "imageoutput";
            this.imageoutput.Size = new System.Drawing.Size(1010, 510);
            this.imageoutput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageoutput.TabIndex = 0;
            this.imageoutput.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 534);
            this.Controls.Add(this.imageoutput);
            this.Name = "Form1";
            this.Text = "ReceiverForCalculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageoutput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imageoutput;
    }
}

