using Calculator.Forms;
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
        private readonly ILogger _logger;
        public MainForm(ILogger logger)
        {
            InitializeComponent();

            _logger = logger;

            textBoxResult.Text = "0";
            textBoxResult.ReadOnly = true;
            textBoxResult.BorderStyle = 0;
            textBoxResult.BackColor = BackColor;
            textBoxResult.TabStop = false;
            textBoxResult.Multiline = true;
        }

        private void computeButton_Click(object sender, EventArgs e)
        {          
            String inputString = inputFieldTextBox.Text;

            var equation = EquationHelper.ExtractItems(inputString);
            double result = equation.Calculate();
            textBoxResult.Text = result.ToString();

            /*var log = Math.Log10(Math.Abs(result));
            var floor = Math.Floor(log);
            Int32 test = Convert.ToInt32(floor);*/

            _logger.Log(inputString, textBoxResult.Text);

        //TODO logging errors?
        }

        private void ShowPopUpError (Exception Ex)
        {
            String message = Ex.Message;
            String caption = "Error!";
            MessageBox.Show(message, caption, MessageBoxButtons.OK);
        }
        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            var aboutBoxForm = new AboutBox();
            aboutBoxForm.Show();
        }

        private void supportedOperationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var supportedOperationForm = new SupportedOperations();
            supportedOperationForm.Show();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var optionsForm = new Options();
            optionsForm.Show();
        }
    }
}
