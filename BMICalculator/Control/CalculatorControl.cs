using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BMICalculator.Model;
using BMICalculator.View;

namespace BMICalculator.Control
{
    internal class CalculatorControl
    {
        private BMI _bmi;
        private Form _calculatorView;

        public CalculatorControl(Form view)
        {
            _calculatorView = view;
            _bmi = new BMI();
        }

        public void CalculateBMI(double weight, double height, ComboBox measurement)
        {
            _bmi.Weight = weight;
            if (measurement.Text == "cm")
            {
                _bmi.Height = height / 100;
            }else
            {
                _bmi.Height = height;
            }
            DisplayResult();

        }

        private void DisplayResult()
        {
            string result = string.Empty;

            Label lblResult = (Label)_calculatorView.Controls["pMain"].Controls["pResult"].Controls["lblResult"];
            TableLayoutPanel obessePanel = (TableLayoutPanel)_calculatorView.Controls["pSide"].Controls["tableLayoutPanel1"];
            TableLayoutPanel overweightPanel = (TableLayoutPanel)_calculatorView.Controls["pSide"].Controls["tableLayoutPanel2"];
            TableLayoutPanel normalPanel = (TableLayoutPanel)_calculatorView.Controls["pSide"].Controls["tableLayoutPanel3"];
            TableLayoutPanel underweightPanel = (TableLayoutPanel)_calculatorView.Controls["pSide"].Controls["tableLayoutPanel4"];
            if (_bmi.calculatedBMI > 30)
            { 
                result = "OBESSE";
                obessePanel.BackColor = Color.Green;
                overweightPanel.BackColor = SystemColors.Window;
                normalPanel.BackColor = SystemColors.Window;
                underweightPanel.BackColor = SystemColors.Window;
            }
            if (_bmi.calculatedBMI <= 29.9 && _bmi.calculatedBMI > 24.9)
            {
                result = "OVERWEIGHT";
                obessePanel.BackColor = SystemColors.Window;
                overweightPanel.BackColor = Color.Green;
                normalPanel.BackColor = SystemColors.Window;
                underweightPanel.BackColor = SystemColors.Window;
            }
            if(_bmi.calculatedBMI <= 24.9 && _bmi.calculatedBMI > 18.5) 
            {
                result = "NORMAL";
                obessePanel.BackColor = SystemColors.Window;
                overweightPanel.BackColor = SystemColors.Window;
                normalPanel.BackColor = Color.Green;
                underweightPanel.BackColor = SystemColors.Window;
            }
            if(_bmi.calculatedBMI < 18.5) { 
                result = "UNDERWEIGHT";
                obessePanel.BackColor = SystemColors.Window;
                overweightPanel.BackColor = SystemColors.Window;
                normalPanel.BackColor = SystemColors.Window;
                underweightPanel.BackColor = Color.Green;
            }

            lblResult.Text = _bmi.calculatedBMI.ToString("F2");
            lblResult.Text = $"{lblResult.Text} = {result}";
        }

        public void Clear()
        {
            Label lblResult = (Label)_calculatorView.Controls["pMain"].Controls["pResult"].Controls["lblResult"];
            TableLayoutPanel obessePanel = (TableLayoutPanel)_calculatorView.Controls["pSide"].Controls["tableLayoutPanel1"];
            TableLayoutPanel overweightPanel = (TableLayoutPanel)_calculatorView.Controls["pSide"].Controls["tableLayoutPanel2"];
            TableLayoutPanel normalPanel = (TableLayoutPanel)_calculatorView.Controls["pSide"].Controls["tableLayoutPanel3"];
            TableLayoutPanel underweightPanel = (TableLayoutPanel)_calculatorView.Controls["pSide"].Controls["tableLayoutPanel4"];
            TextBox txtWeight = (TextBox)_calculatorView.Controls["pMain"].Controls["txtWeight"];
            TextBox txtHeight = (TextBox)_calculatorView.Controls["pMain"].Controls["txtHeight"];

            txtWeight.Text = "";
            txtHeight.Text = "";

            lblResult.Text = "Result";
            obessePanel.BackColor = SystemColors.Window;
            overweightPanel.BackColor = SystemColors.Window;
            normalPanel.BackColor = SystemColors.Window;
            underweightPanel.BackColor = SystemColors.Window;
        }
    }
}
