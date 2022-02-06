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
        private readonly ILogger _logger;
        public MainForm(ICalculator calculator, ILogger logger)
        {
            InitializeComponent();
            computedResultLabel.Text = "0";

            _calculator = calculator;
            _logger = logger;
        }

        private void computeButton_Click(object sender, EventArgs e)
        {          
            String inputString = inputFieldTextBox.Text;
            computedResultLabel.Text = _calculator.Calculate(inputString);

            _logger.Log(inputString, computedResultLabel.Text);

        //TODO logging errors?
    }

        private void ShowPopUpError (Exception Ex)
        {
            String message = Ex.Message;
            String caption = "Error!";
            MessageBox.Show(message, caption, MessageBoxButtons.OK);
        }
    }
}
