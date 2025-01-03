using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BMICalculator.Control;

namespace BMICalculator.View
{
    public partial class CalculatorForm : Form
    {
        private CalculatorControl _calculateControl;

        public CalculatorForm()
        {
            InitializeComponent();
            _calculateControl = new CalculatorControl(this);
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            double weight = double.Parse(txtWeight.Text);
            double height = double.Parse(txtHeight.Text);
            _calculateControl.CalculateBMI(weight, height, cbMeasurement);
        }

        private void CalculatorForm_Load(object sender, EventArgs e)
        {
            cbMeasurement.SelectedIndex = 1;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _calculateControl.Clear();
        }
    }
}
