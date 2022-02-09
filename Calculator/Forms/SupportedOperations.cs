using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Calculator.Forms
{
    public partial class SupportedOperations : Form
    {
        private const string supportedOperationsText = "+\r\n" +
            "-\r\n" +
            "*\r\n" +
            "/\r\n" +
            "sqrt(x)\r\n" +
            "x^(y) or (x)^(y)\r\n" +
            "log(x)\r\n" +
            "sin(x)\r\n" +
            "cos(x)\r\n" +
            "tan(x)\r\n";
        public SupportedOperations()
        {
            InitializeComponent();
            supportedOperationsTextBox.Text = supportedOperationsText;
            supportedOperationsTextBox.DeselectAll();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            supportedOperationsTextBox.SelectionStart = supportedOperationsTextBox.Text.Length;
            supportedOperationsTextBox.DeselectAll();
        }

        /*private void supportedOperationsTextBox_TextChanged(object sender, EventArgs e)
        {
            supportedOperationsTextBox.DeselectAll();
        }*/
    }
}
