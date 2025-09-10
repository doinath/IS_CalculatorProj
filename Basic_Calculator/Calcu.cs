using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic_Calculator
{
    public partial class Calcu : Form
    {
        private BasicCalc calc;
        private double firstNumber = 0;
        private string operation = "";
        private double secondNumber = 0;
        public Calcu()
        {
            InitializeComponent();
            calc = new BasicCalc();
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            textBox1.Text += btn.Text;
        }

        private void OperatorButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Enter a number first.");
                    return;
                }

                firstNumber = double.Parse(textBox1.Text);
                Button btn = (Button)sender;
                operation = btn.Text;
                textBox1.Text += " " + operation + " ";
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid number format.");
            }
        }

        private void Calcu_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                string[] parts = textBox1.Text.Split(' ');

                if (parts.Length < 3)
                {
                    MessageBox.Show("Incomplete expression.");
                    return;
                }

                if (!double.TryParse(parts[2], out secondNumber))
                {
                    MessageBox.Show("Invalid second number.");
                    return;
                }

                double result = 0;

                switch (operation)
                {
                    case "+":
                        result = calc.add(firstNumber, secondNumber);
                        break;
                    case "-":
                        result = calc.subtract(firstNumber, secondNumber);
                        break;
                    case "*":
                        result = calc.multiply(firstNumber, secondNumber);
                        break;
                    case "/":
                        if (secondNumber == 0)
                        {
                            MessageBox.Show("Cannot divide by zero.");
                            return;
                        }
                        result = calc.divide(firstNumber, secondNumber);
                        break;
                    default:
                        MessageBox.Show("Unknown operation.");
                        return;
                }

                textBox1.Text = result.ToString();
                firstNumber = result;
                operation = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            firstNumber = 0;
            secondNumber = 0;
            operation = "";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
        }
    }
}
