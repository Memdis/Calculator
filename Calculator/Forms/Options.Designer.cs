
namespace Calculator.Forms
{
    partial class Options
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
            this.comboBoxAngleUnits = new System.Windows.Forms.ComboBox();
            this.labelAnlgeUnits = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelDecimalPoint = new System.Windows.Forms.Label();
            this.comboBoxDecimalPoint = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBoxAngleUnits
            // 
            this.comboBoxAngleUnits.FormattingEnabled = true;
            this.comboBoxAngleUnits.Items.AddRange(new object[] {
            "Rad",
            "Deg"});
            this.comboBoxAngleUnits.Location = new System.Drawing.Point(117, 15);
            this.comboBoxAngleUnits.Name = "comboBoxAngleUnits";
            this.comboBoxAngleUnits.Size = new System.Drawing.Size(66, 23);
            this.comboBoxAngleUnits.TabIndex = 0;
            // 
            // labelAnlgeUnits
            // 
            this.labelAnlgeUnits.AutoSize = true;
            this.labelAnlgeUnits.Location = new System.Drawing.Point(12, 15);
            this.labelAnlgeUnits.Name = "labelAnlgeUnits";
            this.labelAnlgeUnits.Size = new System.Drawing.Size(68, 15);
            this.labelAnlgeUnits.TabIndex = 1;
            this.labelAnlgeUnits.Text = "Angle Units";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(12, 98);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(108, 98);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelDecimalPoint
            // 
            this.labelDecimalPoint.AutoSize = true;
            this.labelDecimalPoint.Location = new System.Drawing.Point(12, 61);
            this.labelDecimalPoint.Name = "labelDecimalPoint";
            this.labelDecimalPoint.Size = new System.Drawing.Size(103, 15);
            this.labelDecimalPoint.TabIndex = 4;
            this.labelDecimalPoint.Text = "Decimal Separator";
            // 
            // comboBoxDecimalPoint
            // 
            this.comboBoxDecimalPoint.FormattingEnabled = true;
            this.comboBoxDecimalPoint.Items.AddRange(new object[] {
            ",",
            "."});
            this.comboBoxDecimalPoint.Location = new System.Drawing.Point(117, 53);
            this.comboBoxDecimalPoint.Name = "comboBoxDecimalPoint";
            this.comboBoxDecimalPoint.Size = new System.Drawing.Size(66, 23);
            this.comboBoxDecimalPoint.TabIndex = 5;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(214, 140);
            this.Controls.Add(this.comboBoxDecimalPoint);
            this.Controls.Add(this.labelDecimalPoint);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelAnlgeUnits);
            this.Controls.Add(this.comboBoxAngleUnits);
            this.Name = "Options";
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxAngleUnits;
        private System.Windows.Forms.Label labelAnlgeUnits;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelDecimalPoint;
        private System.Windows.Forms.ComboBox comboBoxDecimalPoint;
    }
}