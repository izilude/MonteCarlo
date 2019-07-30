namespace MonteCarloSimulator
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
            this.runSimulationButton = new System.Windows.Forms.Button();
            this.mySimulationBoxControl1 = new MonteCarloSimulator.MySimulationBoxControl();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // runSimulationButton
            // 
            this.runSimulationButton.Location = new System.Drawing.Point(12, 12);
            this.runSimulationButton.Name = "runSimulationButton";
            this.runSimulationButton.Size = new System.Drawing.Size(141, 51);
            this.runSimulationButton.TabIndex = 0;
            this.runSimulationButton.Text = "Run Simulation";
            this.runSimulationButton.UseVisualStyleBackColor = true;
            this.runSimulationButton.Click += new System.EventHandler(this.runSimulationButton_Click);
            // 
            // mySimulationBoxControl1
            // 
            this.mySimulationBoxControl1.Location = new System.Drawing.Point(599, 12);
            this.mySimulationBoxControl1.Name = "mySimulationBoxControl1";
            this.mySimulationBoxControl1.Size = new System.Drawing.Size(636, 636);
            this.mySimulationBoxControl1.TabIndex = 7;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 654);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1223, 28);
            this.progressBar1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 692);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.mySimulationBoxControl1);
            this.Controls.Add(this.runSimulationButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button runSimulationButton;
        private MySimulationBoxControl mySimulationBoxControl1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

