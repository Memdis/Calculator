
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.inputFieldLabel = new System.Windows.Forms.Label();
            this.inputFieldTextBox = new System.Windows.Forms.TextBox();
            this.computeButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.basicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supportedOperationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.buttonPlus = new System.Windows.Forms.Button();
            this.buttonMinus = new System.Windows.Forms.Button();
            this.buttonMult = new System.Windows.Forms.Button();
            this.buttonDiv = new System.Windows.Forms.Button();
            this.buttonLog10 = new System.Windows.Forms.Button();
            this.buttonPow = new System.Windows.Forms.Button();
            this.buttonSqrt = new System.Windows.Forms.Button();
            this.buttonSin = new System.Windows.Forms.Button();
            this.buttonCos = new System.Windows.Forms.Button();
            this.buttonTan = new System.Windows.Forms.Button();
            this.buttonASin = new System.Windows.Forms.Button();
            this.buttonACos = new System.Windows.Forms.Button();
            this.buttonATan = new System.Windows.Forms.Button();
            this.buttonParenthesisLeft = new System.Windows.Forms.Button();
            this.buttonParenthesisRight = new System.Windows.Forms.Button();
            this.buttonParenthesisBoth = new System.Windows.Forms.Button();
            this.groupBoxOperations = new System.Windows.Forms.GroupBox();
            this.groupBoxParenthesis = new System.Windows.Forms.GroupBox();
            this.groupBoxFunctionsGeneral = new System.Windows.Forms.GroupBox();
            this.groupBoxFunctionsGoniometric = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.groupBoxOperations.SuspendLayout();
            this.groupBoxParenthesis.SuspendLayout();
            this.groupBoxFunctionsGeneral.SuspendLayout();
            this.groupBoxFunctionsGoniometric.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputFieldLabel
            // 
            this.inputFieldLabel.AutoSize = true;
            this.inputFieldLabel.Location = new System.Drawing.Point(12, 34);
            this.inputFieldLabel.Name = "inputFieldLabel";
            this.inputFieldLabel.Size = new System.Drawing.Size(61, 15);
            this.inputFieldLabel.TabIndex = 0;
            this.inputFieldLabel.Text = "Input field";
            // 
            // inputFieldTextBox
            // 
            this.inputFieldTextBox.Location = new System.Drawing.Point(12, 52);
            this.inputFieldTextBox.Name = "inputFieldTextBox";
            this.inputFieldTextBox.Size = new System.Drawing.Size(718, 23);
            this.inputFieldTextBox.TabIndex = 1;
            // 
            // computeButton
            // 
            this.computeButton.Location = new System.Drawing.Point(12, 81);
            this.computeButton.Name = "computeButton";
            this.computeButton.Size = new System.Drawing.Size(75, 23);
            this.computeButton.TabIndex = 5;
            this.computeButton.Text = "Compute";
            this.computeButton.UseVisualStyleBackColor = true;
            this.computeButton.Click += new System.EventHandler(this.computeButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.calculatorToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(757, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            this.fileToolStripMenuItem.Visible = false;
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(138, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // calculatorToolStripMenuItem
            // 
            this.calculatorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.basicToolStripMenuItem,
            this.advancedToolStripMenuItem});
            this.calculatorToolStripMenuItem.Name = "calculatorToolStripMenuItem";
            this.calculatorToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.calculatorToolStripMenuItem.Text = "&Calculator";
            this.calculatorToolStripMenuItem.Visible = false;
            // 
            // basicToolStripMenuItem
            // 
            this.basicToolStripMenuItem.Name = "basicToolStripMenuItem";
            this.basicToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.basicToolStripMenuItem.Text = "&Basic";
            // 
            // advancedToolStripMenuItem
            // 
            this.advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
            this.advancedToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.advancedToolStripMenuItem.Text = "&Advanced";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supportedOperationsToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // supportedOperationsToolStripMenuItem
            // 
            this.supportedOperationsToolStripMenuItem.Name = "supportedOperationsToolStripMenuItem";
            this.supportedOperationsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.supportedOperationsToolStripMenuItem.Text = "&Supported Operations";
            this.supportedOperationsToolStripMenuItem.Visible = false;
            this.supportedOperationsToolStripMenuItem.Click += new System.EventHandler(this.supportedOperationsToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(187, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(12, 110);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(718, 23);
            this.textBoxResult.TabIndex = 7;
            this.textBoxResult.Text = "0";
            // 
            // buttonPlus
            // 
            this.buttonPlus.Location = new System.Drawing.Point(10, 19);
            this.buttonPlus.Name = "buttonPlus";
            this.buttonPlus.Size = new System.Drawing.Size(22, 23);
            this.buttonPlus.TabIndex = 8;
            this.buttonPlus.Text = "+";
            this.buttonPlus.UseVisualStyleBackColor = true;
            this.buttonPlus.Click += new System.EventHandler(this.buttonPlus_Click);
            // 
            // buttonMinus
            // 
            this.buttonMinus.Location = new System.Drawing.Point(38, 19);
            this.buttonMinus.Name = "buttonMinus";
            this.buttonMinus.Size = new System.Drawing.Size(22, 23);
            this.buttonMinus.TabIndex = 9;
            this.buttonMinus.Text = "-";
            this.buttonMinus.UseVisualStyleBackColor = true;
            this.buttonMinus.Click += new System.EventHandler(this.buttonMinus_Click);
            // 
            // buttonMult
            // 
            this.buttonMult.Location = new System.Drawing.Point(10, 47);
            this.buttonMult.Name = "buttonMult";
            this.buttonMult.Size = new System.Drawing.Size(22, 23);
            this.buttonMult.TabIndex = 10;
            this.buttonMult.Text = "*";
            this.buttonMult.UseVisualStyleBackColor = true;
            this.buttonMult.Click += new System.EventHandler(this.buttonMult_Click);
            // 
            // buttonDiv
            // 
            this.buttonDiv.Location = new System.Drawing.Point(38, 47);
            this.buttonDiv.Name = "buttonDiv";
            this.buttonDiv.Size = new System.Drawing.Size(22, 23);
            this.buttonDiv.TabIndex = 11;
            this.buttonDiv.Text = "/";
            this.buttonDiv.UseVisualStyleBackColor = true;
            this.buttonDiv.Click += new System.EventHandler(this.buttonDiv_Click);
            // 
            // buttonLog10
            // 
            this.buttonLog10.Location = new System.Drawing.Point(68, 19);
            this.buttonLog10.Name = "buttonLog10";
            this.buttonLog10.Size = new System.Drawing.Size(55, 23);
            this.buttonLog10.TabIndex = 12;
            this.buttonLog10.Text = "log()";
            this.buttonLog10.UseVisualStyleBackColor = true;
            this.buttonLog10.Click += new System.EventHandler(this.buttonLog10_Click);
            // 
            // buttonPow
            // 
            this.buttonPow.Location = new System.Drawing.Point(7, 19);
            this.buttonPow.Name = "buttonPow";
            this.buttonPow.Size = new System.Drawing.Size(55, 23);
            this.buttonPow.TabIndex = 13;
            this.buttonPow.Text = "()^()";
            this.buttonPow.UseVisualStyleBackColor = true;
            this.buttonPow.Click += new System.EventHandler(this.buttonPow_Click);
            // 
            // buttonSqrt
            // 
            this.buttonSqrt.Location = new System.Drawing.Point(7, 48);
            this.buttonSqrt.Name = "buttonSqrt";
            this.buttonSqrt.Size = new System.Drawing.Size(55, 23);
            this.buttonSqrt.TabIndex = 14;
            this.buttonSqrt.Text = "sqrt()";
            this.buttonSqrt.UseVisualStyleBackColor = true;
            this.buttonSqrt.Click += new System.EventHandler(this.buttonSqrt_Click);
            // 
            // buttonSin
            // 
            this.buttonSin.Location = new System.Drawing.Point(7, 19);
            this.buttonSin.Name = "buttonSin";
            this.buttonSin.Size = new System.Drawing.Size(55, 23);
            this.buttonSin.TabIndex = 15;
            this.buttonSin.Text = "sin()";
            this.buttonSin.UseVisualStyleBackColor = true;
            this.buttonSin.Click += new System.EventHandler(this.buttonSin_Click);
            // 
            // buttonCos
            // 
            this.buttonCos.Location = new System.Drawing.Point(68, 19);
            this.buttonCos.Name = "buttonCos";
            this.buttonCos.Size = new System.Drawing.Size(55, 23);
            this.buttonCos.TabIndex = 16;
            this.buttonCos.Text = "cos()";
            this.buttonCos.UseVisualStyleBackColor = true;
            this.buttonCos.Click += new System.EventHandler(this.buttonCos_Click);
            // 
            // buttonTan
            // 
            this.buttonTan.Location = new System.Drawing.Point(129, 19);
            this.buttonTan.Name = "buttonTan";
            this.buttonTan.Size = new System.Drawing.Size(55, 23);
            this.buttonTan.TabIndex = 17;
            this.buttonTan.Text = "tan()";
            this.buttonTan.UseVisualStyleBackColor = true;
            this.buttonTan.Click += new System.EventHandler(this.buttonTan_Click);
            // 
            // buttonASin
            // 
            this.buttonASin.Location = new System.Drawing.Point(7, 48);
            this.buttonASin.Name = "buttonASin";
            this.buttonASin.Size = new System.Drawing.Size(55, 23);
            this.buttonASin.TabIndex = 18;
            this.buttonASin.Text = "asin()";
            this.buttonASin.UseVisualStyleBackColor = true;
            this.buttonASin.Click += new System.EventHandler(this.buttonASin_Click);
            // 
            // buttonACos
            // 
            this.buttonACos.Location = new System.Drawing.Point(68, 48);
            this.buttonACos.Name = "buttonACos";
            this.buttonACos.Size = new System.Drawing.Size(55, 23);
            this.buttonACos.TabIndex = 19;
            this.buttonACos.Text = "acos()";
            this.buttonACos.UseVisualStyleBackColor = true;
            this.buttonACos.Click += new System.EventHandler(this.buttonACos_Click);
            // 
            // buttonATan
            // 
            this.buttonATan.Location = new System.Drawing.Point(129, 48);
            this.buttonATan.Name = "buttonATan";
            this.buttonATan.Size = new System.Drawing.Size(55, 23);
            this.buttonATan.TabIndex = 20;
            this.buttonATan.Text = "atan()";
            this.buttonATan.UseVisualStyleBackColor = true;
            this.buttonATan.Click += new System.EventHandler(this.buttonATan_Click);
            // 
            // buttonParenthesisLeft
            // 
            this.buttonParenthesisLeft.Location = new System.Drawing.Point(10, 19);
            this.buttonParenthesisLeft.Name = "buttonParenthesisLeft";
            this.buttonParenthesisLeft.Size = new System.Drawing.Size(22, 23);
            this.buttonParenthesisLeft.TabIndex = 21;
            this.buttonParenthesisLeft.Text = "(";
            this.buttonParenthesisLeft.UseVisualStyleBackColor = true;
            this.buttonParenthesisLeft.Click += new System.EventHandler(this.buttonParenthesisLeft_Click);
            // 
            // buttonParenthesisRight
            // 
            this.buttonParenthesisRight.Location = new System.Drawing.Point(38, 19);
            this.buttonParenthesisRight.Name = "buttonParenthesisRight";
            this.buttonParenthesisRight.Size = new System.Drawing.Size(22, 23);
            this.buttonParenthesisRight.TabIndex = 22;
            this.buttonParenthesisRight.Text = ")";
            this.buttonParenthesisRight.UseVisualStyleBackColor = true;
            this.buttonParenthesisRight.Click += new System.EventHandler(this.buttonParenthesisRight_Click);
            // 
            // buttonParenthesisBoth
            // 
            this.buttonParenthesisBoth.Location = new System.Drawing.Point(10, 48);
            this.buttonParenthesisBoth.Name = "buttonParenthesisBoth";
            this.buttonParenthesisBoth.Size = new System.Drawing.Size(29, 23);
            this.buttonParenthesisBoth.TabIndex = 23;
            this.buttonParenthesisBoth.Text = "( )";
            this.buttonParenthesisBoth.UseVisualStyleBackColor = true;
            this.buttonParenthesisBoth.Click += new System.EventHandler(this.buttonParenthesisBoth_Click);
            // 
            // groupBoxOperations
            // 
            this.groupBoxOperations.Controls.Add(this.buttonDiv);
            this.groupBoxOperations.Controls.Add(this.buttonPlus);
            this.groupBoxOperations.Controls.Add(this.buttonMinus);
            this.groupBoxOperations.Controls.Add(this.buttonMult);
            this.groupBoxOperations.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxOperations.Location = new System.Drawing.Point(12, 168);
            this.groupBoxOperations.Name = "groupBoxOperations";
            this.groupBoxOperations.Size = new System.Drawing.Size(69, 80);
            this.groupBoxOperations.TabIndex = 24;
            this.groupBoxOperations.TabStop = false;
            this.groupBoxOperations.Text = "Operations";
            // 
            // groupBoxParenthesis
            // 
            this.groupBoxParenthesis.Controls.Add(this.buttonParenthesisLeft);
            this.groupBoxParenthesis.Controls.Add(this.buttonParenthesisRight);
            this.groupBoxParenthesis.Controls.Add(this.buttonParenthesisBoth);
            this.groupBoxParenthesis.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxParenthesis.Location = new System.Drawing.Point(80, 168);
            this.groupBoxParenthesis.Name = "groupBoxParenthesis";
            this.groupBoxParenthesis.Size = new System.Drawing.Size(69, 80);
            this.groupBoxParenthesis.TabIndex = 25;
            this.groupBoxParenthesis.TabStop = false;
            this.groupBoxParenthesis.Text = "Parenthesis";
            // 
            // groupBoxFunctionsGeneral
            // 
            this.groupBoxFunctionsGeneral.Controls.Add(this.buttonPow);
            this.groupBoxFunctionsGeneral.Controls.Add(this.buttonLog10);
            this.groupBoxFunctionsGeneral.Controls.Add(this.buttonSqrt);
            this.groupBoxFunctionsGeneral.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxFunctionsGeneral.Location = new System.Drawing.Point(148, 168);
            this.groupBoxFunctionsGeneral.Name = "groupBoxFunctionsGeneral";
            this.groupBoxFunctionsGeneral.Size = new System.Drawing.Size(130, 80);
            this.groupBoxFunctionsGeneral.TabIndex = 27;
            this.groupBoxFunctionsGeneral.TabStop = false;
            this.groupBoxFunctionsGeneral.Text = "Functions General";
            // 
            // groupBoxFunctionsGoniometric
            // 
            this.groupBoxFunctionsGoniometric.Controls.Add(this.buttonSin);
            this.groupBoxFunctionsGoniometric.Controls.Add(this.buttonCos);
            this.groupBoxFunctionsGoniometric.Controls.Add(this.buttonTan);
            this.groupBoxFunctionsGoniometric.Controls.Add(this.buttonASin);
            this.groupBoxFunctionsGoniometric.Controls.Add(this.buttonATan);
            this.groupBoxFunctionsGoniometric.Controls.Add(this.buttonACos);
            this.groupBoxFunctionsGoniometric.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxFunctionsGoniometric.Location = new System.Drawing.Point(277, 168);
            this.groupBoxFunctionsGoniometric.Name = "groupBoxFunctionsGoniometric";
            this.groupBoxFunctionsGoniometric.Size = new System.Drawing.Size(191, 80);
            this.groupBoxFunctionsGoniometric.TabIndex = 27;
            this.groupBoxFunctionsGoniometric.TabStop = false;
            this.groupBoxFunctionsGoniometric.Text = "Functions Goniometric";
            // 
            // MainForm
            // 
            this.AcceptButton = this.computeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 264);
            this.Controls.Add(this.groupBoxFunctionsGoniometric);
            this.Controls.Add(this.groupBoxFunctionsGeneral);
            this.Controls.Add(this.groupBoxParenthesis);
            this.Controls.Add(this.groupBoxOperations);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.computeButton);
            this.Controls.Add(this.inputFieldTextBox);
            this.Controls.Add(this.inputFieldLabel);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "Calculator";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxOperations.ResumeLayout(false);
            this.groupBoxParenthesis.ResumeLayout(false);
            this.groupBoxFunctionsGeneral.ResumeLayout(false);
            this.groupBoxFunctionsGoniometric.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label inputFieldLabel;
        private System.Windows.Forms.TextBox inputFieldTextBox;
        private System.Windows.Forms.Button computeButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem basicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advancedCalculatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supportedOperationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advancedToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Button buttonPlus;
        private System.Windows.Forms.Button buttonMinus;
        private System.Windows.Forms.Button buttonMult;
        private System.Windows.Forms.Button buttonDiv;
        private System.Windows.Forms.Button buttonLog10;
        private System.Windows.Forms.Button buttonPow;
        private System.Windows.Forms.Button buttonSqrt;
        private System.Windows.Forms.Button buttonSin;
        private System.Windows.Forms.Button buttonCos;
        private System.Windows.Forms.Button buttonTan;
        private System.Windows.Forms.Button buttonASin;
        private System.Windows.Forms.Button buttonACos;
        private System.Windows.Forms.Button buttonATan;
        private System.Windows.Forms.Button buttonParenthesisLeft;
        private System.Windows.Forms.Button buttonParenthesisRight;
        private System.Windows.Forms.Button buttonParenthesisBoth;
        private System.Windows.Forms.GroupBox groupBoxOperations;
        private System.Windows.Forms.GroupBox groupBoxParenthesis;
        private System.Windows.Forms.GroupBox groupBoxFunctionsGeneral;
        private System.Windows.Forms.GroupBox groupBoxFunctionsGoniometric;
    }
}

