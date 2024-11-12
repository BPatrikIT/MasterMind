namespace MasterMind
{
    partial class loseScreen
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
            this.buttonLose = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.buttonLose)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLose
            // 
            this.buttonLose.BackColor = System.Drawing.Color.Transparent;
            this.buttonLose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLose.Location = new System.Drawing.Point(0, 0);
            this.buttonLose.Name = "buttonLose";
            this.buttonLose.Size = new System.Drawing.Size(1727, 1024);
            this.buttonLose.TabIndex = 0;
            this.buttonLose.TabStop = false;
            this.buttonLose.Click += new System.EventHandler(this.buttonLose_Click);
            // 
            // loseScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MasterMind.Properties.Resources.loseScreen;
            this.ClientSize = new System.Drawing.Size(1711, 1041);
            this.Controls.Add(this.buttonLose);
            this.Name = "loseScreen";
            this.Text = "loseScreen";
            ((System.ComponentModel.ISupportInitialize)(this.buttonLose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox buttonLose;
    }
}