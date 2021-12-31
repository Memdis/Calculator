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
        List<char> allowedNums = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        List<char> allowedSigns = new List<char>() { '+' };
        public MainForm()
        {
            InitializeComponent();
            computedResultLabel.Text = "0";
        }

        private void computeButton_Click(object sender, EventArgs e)
        {
            // TODO: allowednum and sign previesť na list a potom bude array iba allowedChar
            
            String inputString = inputFieldTextBox.Text;

            List<char> allowedChars = new List<char>();
            allowedChars.AddRange(allowedNums);
            allowedChars.AddRange(allowedSigns);

            inputString = RemoveForbiddenChars(allowedChars.ToArray(), inputString);

            computedResultLabel.Text = Convert.ToString(ComputeResult(inputString));
        }

        private string RemoveForbiddenChars(char[] AllowedChars, String InputString)
        {
            for (int i = 0; i < InputString.Length; i++)
            {
                for (int j = 0; j < AllowedChars.Length; j++)
                {
                    if (InputString[i] == AllowedChars[j])
                    {
                        break;
                    }
                    else if (j == AllowedChars.Length - 1)
                    {
                        InputString = InputString.Remove(i, 1);
                        i -= 1;
                    }
                }
            }

            return InputString;
        }

        private int ComputeResult(String InputTrimmedString)
        {
            String numToAdd = "";

            int result = 0;

            for(int i = 0; i < InputTrimmedString.Length; i++)
            {
                if (InputTrimmedString[i] != '+')
                {
                    string charToString = InputTrimmedString[i].ToString();
                    numToAdd = numToAdd.Insert(numToAdd.Length, charToString);

                    if (i == InputTrimmedString.Length - 1)
                    {
                        result += int.Parse(numToAdd);
                    }
                }
                else
                {
                    try
                    {
                        result += int.Parse(numToAdd);
                    }
                    catch (FormatException ex)
                    {
                        ShowPopUpError(ex);
                    }
                    
                    numToAdd = "";
                }
            }

            return result;
        }

        private void ShowPopUpError (Exception Ex)
        {
            String message = Ex.Message;
            String caption = "Error!";
            MessageBox.Show(message, caption, MessageBoxButtons.OK);
        }
    }
}
