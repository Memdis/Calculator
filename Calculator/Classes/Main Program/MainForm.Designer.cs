
namespace Calculator
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.inputFieldLabel = new System.Windows.Forms.Label();
            this.inputFieldTextBox = new System.Windows.Forms.TextBox();
            this.computedResultLabel = new System.Windows.Forms.Label();
            this.infoLabel = new System.Windows.Forms.Label();
            this.computeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inputFieldLabel
            // 
            this.inputFieldLabel.AutoSize = true;
            this.inputFieldLabel.Location = new System.Drawing.Point(12, 9);
            this.inputFieldLabel.Name = "inputFieldLabel";
            this.inputFieldLabel.Size = new System.Drawing.Size(61, 15);
            this.inputFieldLabel.TabIndex = 0;
            this.inputFieldLabel.Text = "Input field";
            // 
            // inputFieldTextBox
            // 
            this.inputFieldTextBox.Location = new System.Drawing.Point(12, 27);
            this.inputFieldTextBox.Name = "inputFieldTextBox";
            this.inputFieldTextBox.Size = new System.Drawing.Size(505, 23);
            this.inputFieldTextBox.TabIndex = 1;
            // 
            // computedResultLabel
            // 
            this.computedResultLabel.AutoSize = true;
            this.computedResultLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.computedResultLabel.Location = new System.Drawing.Point(12, 82);
            this.computedResultLabel.Name = "computedResultLabel";
            this.computedResultLabel.Size = new System.Drawing.Size(13, 15);
            this.computedResultLabel.TabIndex = 3;
            this.computedResultLabel.Text = "0";
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(12, 176);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(106, 15);
            this.infoLabel.TabIndex = 4;
            this.infoLabel.Text = "Supported sings: +";
            // 
            // computeButton
            // 
            this.computeButton.Location = new System.Drawing.Point(12, 56);
            this.computeButton.Name = "computeButton";
            this.computeButton.Size = new System.Drawing.Size(75, 23);
            this.computeButton.TabIndex = 5;
            this.computeButton.Text = "Compute";
            this.computeButton.UseVisualStyleBackColor = true;
            this.computeButton.Click += new System.EventHandler(this.computeButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 309);
            this.Controls.Add(this.computeButton);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.computedResultLabel);
            this.Controls.Add(this.inputFieldTextBox);
            this.Controls.Add(this.inputFieldLabel);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label inputFieldLabel;
        private System.Windows.Forms.TextBox inputFieldTextBox;
        private System.Windows.Forms.Label computedResultLabel;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Button computeButton;
    }
}

