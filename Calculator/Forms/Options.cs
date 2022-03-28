using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Calculator.Forms
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();

            comboBoxAngleUnits.SelectedIndex = (int)Settings.AngleUnits;
            comboBoxDecimalPoint.SelectedItem = Settings.DecimalSeparator;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Settings.SaveSettings(comboBoxAngleUnits.SelectedIndex, (string)comboBoxDecimalPoint.SelectedItem, 13);
            
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
