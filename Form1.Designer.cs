namespace shooting_01
{
    partial class MoleShooter
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
            this.timerGameLoop = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerGameLoop
            // 
            this.timerGameLoop.Tick += new System.EventHandler(this.TimerGameLoop_Tick);
            // 
            // MoleShooter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::shooting_01.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Enabled = false;
            this.Name = "MoleShooter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CMole Shooter";
            this.Load += new System.EventHandler(this.MoleShooter_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MoleShooter_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoleShooter_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerGameLoop;
    }
}

