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
    public partial class Form1 : Form
    {
        string operatorUsed = "";
        double value = 0;
        bool isOperatorUsed = false;
        bool isDotUsed = false;
        int count = 1; //for multiple numbers
        bool isEqualClicked = false;
        int countSQRT = 0; // count using sqrt
        double initialNum = 0; // for SQRT


        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (isEqualClicked)
            {
                Calculations.Text = "";
            }
            if (resultTextBox.Text == "0" && Calculations.Text == "")
            {
                resultTextBox.Clear();
            }
            if (operatorUsed != "" && count > 0)
            {
                resultTextBox.Clear();
                count--;
            }
            Button button = (Button)sender;
            resultTextBox.Text = resultTextBox.Text + button.Text;
            //isOperatorUsed = false;
            isEqualClicked = false;
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            if (operatorUsed != "" && resultTextBox.Text.Length > 0)
            {
                resultTextBox.Text = "0.";
                isDotUsed = true;
                count--;
            }
            if (!isDotUsed)
            {
                resultTextBox.Text += buttonDot.Text;
                //Calculations.Text += buttonDot.Text;
                isDotUsed = true;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            resultTextBox.Text = "0";

            Calculations.Text = "";
            operatorUsed = "";
            value = 0;
            isOperatorUsed = false;
            isDotUsed = false;
            count = 1;
            isEqualClicked = false;
            countSQRT = 0;
        }

        private void buttonOperator_Click(object sender, EventArgs e)
        {
            if (isEqualClicked)
            {
                Calculations.Text = "";
                value = 0;
            }
            Calculations.Text += resultTextBox.Text;
            if (isOperatorUsed)
            {
                if (operatorUsed == "+")
                {
                    resultTextBox.Text = (value + double.Parse(resultTextBox.Text)).ToString();
                }
                else if (operatorUsed == "-")
                {
                    resultTextBox.Text = (value - double.Parse(resultTextBox.Text)).ToString();
                }
                else if (operatorUsed == "x")
                {
                    resultTextBox.Text = (value * double.Parse(resultTextBox.Text)).ToString();
                }
                else if (operatorUsed == "/")
                {
                    resultTextBox.Text = (value / double.Parse(resultTextBox.Text)).ToString();
                }
                else if (operatorUsed == "%")
                {
                    resultTextBox.Text = (value % double.Parse(resultTextBox.Text)).ToString();
                }

            }
            if (count == 0)
            {
                count++;
            }
            isOperatorUsed = true;
            isDotUsed = false;
            Button button = (Button)sender;
            operatorUsed = button.Text;
            value = double.Parse(resultTextBox.Text);
            Calculations.Text += " " + operatorUsed + " ";
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            if (isEqualClicked)
            {
                Calculations.Text = "";
                Calculations.Text += value + operatorUsed + resultTextBox.Text;
                return;
            }
            isEqualClicked = true;
            Calculations.Text += resultTextBox.Text;
            if (operatorUsed == "+")
            {
                resultTextBox.Text = (value + double.Parse(resultTextBox.Text)).ToString();
            }
            else if (operatorUsed == "-")
            {
                resultTextBox.Text = (value - double.Parse(resultTextBox.Text)).ToString();
            }
            else if (operatorUsed == "x")
            {
                resultTextBox.Text = (value * double.Parse(resultTextBox.Text)).ToString();
            }
            else if (operatorUsed == "/")
            {
                resultTextBox.Text = (value / double.Parse(resultTextBox.Text)).ToString();
            }
            else if (operatorUsed == "%")
            {
                resultTextBox.Text = (value % double.Parse(resultTextBox.Text)).ToString();
            }

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (resultTextBox.Text.Length != 0)
            {
                resultTextBox.Text = resultTextBox.Text.Remove(resultTextBox.Text.Length - 1, 1);
            }
            if (resultTextBox.Text == "")
            {
                resultTextBox.Text = "0";
            }
        }

        private void buttonSQRT_Click(object sender, EventArgs e)
        {
            countSQRT++;
            if (countSQRT > 1)
            {
                Calculations.Text = $"√({initialNum})";
                resultTextBox.Text = (Math.Sqrt(double.Parse(resultTextBox.Text))).ToString();

            }
            else
            {
                initialNum = double.Parse(resultTextBox.Text);
                Calculations.Text += $"√({resultTextBox.Text})";
                resultTextBox.Text = (Math.Sqrt(double.Parse(resultTextBox.Text))).ToString();
            }
        }

        string memoryNumString = null;
        double memoryNum = 0;

        private void MemoryOperations_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button.Text == "M+")
            {
                memoryTextBox.Text = (memoryNum + double.Parse(resultTextBox.Text)).ToString();
                memoryNum = double.Parse(memoryTextBox.Text);
                memoryNumString = memoryTextBox.Text;
            }
            else if (button.Text == "M-")
            {
                memoryTextBox.Text = (memoryNum - double.Parse(resultTextBox.Text)).ToString();
                memoryNum = double.Parse(memoryTextBox.Text);
                memoryNumString = memoryTextBox.Text;

            }
            else if (button.Text == "MC")
            {
                memoryTextBox.Text = "0";
                memoryNum = 0;
                memoryNumString = null;
            }
            else if (button.Text == "MR")
            {
                if (memoryNumString != null)
                {
                    resultTextBox.Text = memoryNum.ToString();
                }
            }
        }

        private void plusToMinus_Click(object sender, EventArgs e)
        {
            double num = double.Parse(resultTextBox.Text);
            double numTwo = num * 2;
            resultTextBox.Text = (num - numTwo).ToString();
        }
    }
}
