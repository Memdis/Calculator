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
            computedResultLabel.Text = "0";

            _logger = logger;
        }

        private void computeButton_Click(object sender, EventArgs e)
        {          
            String inputString = inputFieldTextBox.Text;

            var equation = EquationHelper.ExtractItems(inputString);
            double result = equation.Calculate();
            computedResultLabel.Text = result.ToString();

            _logger.Log(inputString, computedResultLabel.Text);

        //TODO logging errors?
        }

        private void ShowPopUpError (Exception Ex)
        {
            String message = Ex.Message;
            String caption = "Error!";
            MessageBox.Show(message, caption, MessageBoxButtons.OK);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            
        }

        /*private void AboutToolStripMenuItem(object sender, ToolStripItemClickedEventArgs e)
        {
            MessageBox.Show(e.ClickedItem.Text);
        }*/

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            var aboutBox = new AboutBox1();
            aboutBox.Show();
        }

        private void supportedOperationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var supportedOperationForm = new SupportedOperations();
            supportedOperationForm.Show();
        }
    }
}
