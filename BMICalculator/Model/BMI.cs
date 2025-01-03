using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMICalculator.Model
{
    internal class BMI
    {
        private double weight;
        private double height;

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        public double calculatedBMI
        {
            get
            {
                double bmi = weight / (height * height);
                return bmi;
            }
        }
    }
}
