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
        private readonly ICalculation _calculation;
        public MainForm(ILogger logger, ICalculation calculation)
        {
            InitializeComponent();

            _logger = logger;
            _calculation = calculation;

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

            try
            {
                textBoxResult.Text = _calculation.CalculateResult(inputString);// ((double.Parse(inputString))%Math.PI).ToString();//
            }
            catch (Exception ex)
            {
                ShowPopUpError(ex);
            }

            _logger.Log(inputString, textBoxResult.Text);//TODO logging errors?
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

        private void InsertTextToInputField(string insertionText, int selectionShift)
        {
            var selectionIndex = inputFieldTextBox.SelectionStart;

            inputFieldTextBox.Text = inputFieldTextBox.Text.Insert(selectionIndex, insertionText);
            inputFieldTextBox.SelectionStart = selectionIndex + insertionText.Length + selectionShift;
            inputFieldTextBox.SelectionLength = 0;

            inputFieldTextBox.Focus();
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            var function = new PlusOperation(FunctionType.Operation);
            InsertTextToInputField(function.GetStringRepresentation(), 0);
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            var function = new MinusOperation(FunctionType.Operation);
            InsertTextToInputField(function.GetStringRepresentation(), 0);
        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            var function = new MultOperation(FunctionType.Operation);
            InsertTextToInputField(function.GetStringRepresentation(), 0);
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            var function = new DivOperation(FunctionType.Operation);
            InsertTextToInputField(function.GetStringRepresentation(), 0);
        }

        private void buttonParenthesisLeft_Click(object sender, EventArgs e)
        {
            InsertTextToInputField("(", 0);
        }

        private void buttonParenthesisRight_Click(object sender, EventArgs e)
        {
            InsertTextToInputField(")", 0);
        }

        private void buttonParenthesisBoth_Click(object sender, EventArgs e)
        {
            InsertTextToInputField("()", -1);
        }

        private void buttonPow_Click(object sender, EventArgs e)
        {
            var function = new PowFunction(FunctionType.Function);
            InsertTextToInputField("()"+function.GetStringRepresentation()+"()", -4);
        }

        private void buttonLog10_Click(object sender, EventArgs e)
        {
            var function = new Log10Function(FunctionType.Function);
            InsertTextToInputField(function.GetStringRepresentation() + "()", -1);
        }

        private void buttonSqrt_Click(object sender, EventArgs e)
        {
            var function = new SqrtFunction(FunctionType.Function);
            InsertTextToInputField(function.GetStringRepresentation() + "()", -1);
        }

        private void buttonSin_Click(object sender, EventArgs e)
        {
            var function = new SinFunction(FunctionType.Function);
            InsertTextToInputField(function.GetStringRepresentation() + "()", -1);
        }

        private void buttonCos_Click(object sender, EventArgs e)
        {
            var function = new CosFunction(FunctionType.Function);
            InsertTextToInputField(function.GetStringRepresentation() + "()", -1);
        }

        private void buttonTan_Click(object sender, EventArgs e)
        {
            var function = new TanFunction(FunctionType.Function);
            InsertTextToInputField(function.GetStringRepresentation() + "()", -1);
        }

        private void buttonASin_Click(object sender, EventArgs e)
        {
            var function = new ASinFunction(FunctionType.Function);
            InsertTextToInputField(function.GetStringRepresentation() + "()", -1);
        }

        private void buttonACos_Click(object sender, EventArgs e)
        {
            var function = new ACosFunction(FunctionType.Function);
            InsertTextToInputField(function.GetStringRepresentation() + "()", -1);
        }

        private void buttonATan_Click(object sender, EventArgs e)
        {
            var function = new ATanFunction(FunctionType.Function);
            InsertTextToInputField(function.GetStringRepresentation() + "()", -1);
        }
    }
}
