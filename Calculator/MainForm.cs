using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class MainForm : Form
    {
        private readonly ICalculator _calculator;
        public MainForm(ICalculator calculator)
        {
            InitializeComponent();
            computedResultLabel.Text = "0";

            _calculator = calculator;
        }

        private void computeButton_Click(object sender, EventArgs e)
        {
            // TODO: allowednum and sign previesť na list a potom bude array iba allowedChar
            
            String inputString = inputFieldTextBox.Text;
            computedResultLabel.Text = _calculator.Calculate(inputString);
        }

        

        private void ShowPopUpError (Exception Ex)
        {
            String message = Ex.Message;
            String caption = "Error!";
            MessageBox.Show(message, caption, MessageBoxButtons.OK);
        }
    }
}
