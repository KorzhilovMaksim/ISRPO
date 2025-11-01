using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Calculator
{
    public partial class MainForm : Form
    {
        string input_number = "0";
        List<double> operands = new List<double>();
        List<string> operations = new List<string>();
        string[] priorities = { "^", "*/", "+-" };

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            string text = ((Button)sender).Text;
            switch (text)
            {
                case "PI":
                    input_number += "3,141592";
                    txtConsole.Text += "3,141592";
                    break;
                case "e":
                    input_number += "2,718281828";
                    txtConsole.Text += "2,718281828";
                    break;
                default:
                    input_number += text;
                    txtConsole.Text += text;
                    break;
            }
            
            if (text == ",")
            {
                btnPoint.Enabled = false;
            }
        }

        private void btnMathoOperation_Click(object sender, EventArgs e)
        {
            string text = ((Button)sender).Text;
            txtConsole.Text += text;
            operations.Add(text);
            addOperand();
        }

        private void addOperand()
        {
            double operand = Convert.ToDouble(input_number);
            operands.Add(operand);
            btnPoint.Enabled = true;
            input_number = "0";
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            addOperand();
            foreach (string op in priorities)
            {
                for (int i = 0; i < operations.Count; i++)
                {
                    if (op.Contains(operations[i]))
                    {
                        switch (operations[i])
                        {
                            case "^":
                                operands[i + 1] = Math.Pow(operands[i], operands[i + 1]);
                                break;
                            case "*":
                                operands[i + 1] = operands[i] * operands[i + 1];
                                break;
                            case "/":
                                operands[i + 1] = operands[i] / operands[i + 1];
                                break;
                            case "+":
                                operands[i + 1] = operands[i] + operands[i + 1];
                                break;
                            case "-":
                                operands[i + 1] = operands[i] - operands[i + 1];
                                break;
                        }
                    }
                }
            }
            txtConsole.Text = operands[operands.Count - 1].ToString();
            input_number = txtConsole.Text;
            operands.Clear();
            operations.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtConsole.Text = "";
            operands.Clear();
            operations.Clear();
            input_number = "0";
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            txtConsole.Text = txtConsole.Text.Substring(0, txtConsole.Text.Length - input_number.Length + 1);
            input_number = "0";
        }
    }
}
