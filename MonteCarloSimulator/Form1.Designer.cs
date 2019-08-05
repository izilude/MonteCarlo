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
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.addObjectsButton = new System.Windows.Forms.Button();
            this.objectTypeSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.objectTemplatePropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.numberOfObjectsToAdd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // runSimulationButton
            // 
            this.runSimulationButton.Location = new System.Drawing.Point(437, 590);
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
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(12, 12);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(566, 253);
            this.propertyGrid1.TabIndex = 9;
            // 
            // addObjectsButton
            // 
            this.addObjectsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addObjectsButton.Location = new System.Drawing.Point(12, 603);
            this.addObjectsButton.Name = "addObjectsButton";
            this.addObjectsButton.Size = new System.Drawing.Size(141, 34);
            this.addObjectsButton.TabIndex = 10;
            this.addObjectsButton.Text = "Add Objects";
            this.addObjectsButton.UseVisualStyleBackColor = true;
            this.addObjectsButton.Click += new System.EventHandler(this.addObjectsButton_Click);
            // 
            // objectTypeSelectionComboBox
            // 
            this.objectTypeSelectionComboBox.FormattingEnabled = true;
            this.objectTypeSelectionComboBox.Location = new System.Drawing.Point(149, 277);
            this.objectTypeSelectionComboBox.Name = "objectTypeSelectionComboBox";
            this.objectTypeSelectionComboBox.Size = new System.Drawing.Size(249, 24);
            this.objectTypeSelectionComboBox.TabIndex = 11;
            this.objectTypeSelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.objectTypeSelectionComboBox_SelectedIndexChanged);
            // 
            // objectTemplatePropertyGrid
            // 
            this.objectTemplatePropertyGrid.Location = new System.Drawing.Point(12, 312);
            this.objectTemplatePropertyGrid.Name = "objectTemplatePropertyGrid";
            this.objectTemplatePropertyGrid.Size = new System.Drawing.Size(566, 268);
            this.objectTemplatePropertyGrid.TabIndex = 12;
            // 
            // numberOfObjectsToAdd
            // 
            this.numberOfObjectsToAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfObjectsToAdd.Location = new System.Drawing.Point(159, 602);
            this.numberOfObjectsToAdd.Name = "numberOfObjectsToAdd";
            this.numberOfObjectsToAdd.Size = new System.Drawing.Size(100, 34);
            this.numberOfObjectsToAdd.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Object Templates";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 692);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numberOfObjectsToAdd);
            this.Controls.Add(this.objectTemplatePropertyGrid);
            this.Controls.Add(this.objectTypeSelectionComboBox);
            this.Controls.Add(this.addObjectsButton);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.mySimulationBoxControl1);
            this.Controls.Add(this.runSimulationButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button runSimulationButton;
        private MySimulationBoxControl mySimulationBoxControl1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Button addObjectsButton;
        private System.Windows.Forms.ComboBox objectTypeSelectionComboBox;
        private System.Windows.Forms.PropertyGrid objectTemplatePropertyGrid;
        private System.Windows.Forms.TextBox numberOfObjectsToAdd;
        private System.Windows.Forms.Label label1;
    }
}

