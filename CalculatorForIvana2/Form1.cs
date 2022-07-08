using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorForIvana2
{
    public partial class Form1 : Form
    {
        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void buttonClick(object sender, EventArgs e)
        {
            if ((textBox1_result.Text == "0") || (isOperationPerformed))
            {
                textBox1_result.Clear();
            }
            isOperationPerformed = false;
            Button button = (Button)sender;
            if(button.Text == ",")
            {
                if (!textBox1_result.Text.Contains(","))
                {
                    textBox1_result.Text = textBox1_result.Text + button.Text;
                } 
            }
            else
            {
                textBox1_result.Text = textBox1_result.Text + button.Text;
            }
                
        }
        

        private void OperatorClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0 && !isOperationPerformed)
            {
                buttonEqual.PerformClick();
                operationPerformed = button.Text;
                CurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else if(textBox1_result.Text == ",")
            {
                MessageBox.Show("Incorrect entry, try again");
                ClearEntry(sender, e);

            }
            else
            {
                operationPerformed = button.Text;
                resultValue = double.Parse(textBox1_result.Text);
                CurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }

        }

        private void ClearEntry(object sender, EventArgs e)
        {
            isOperationPerformed = false;
            textBox1_result.Text = "0";
        }

        private void Clear(object sender, EventArgs e)
        {
            isOperationPerformed=false;
            textBox1_result.Text = "0";
            CurrentOperation.Text = "";
            resultValue = 0;
        }

        private void Equal(object sender, EventArgs e)
        {
            
            switch (operationPerformed)
            {
                case "+":
                    textBox1_result.Text = (resultValue + Double.Parse(textBox1_result.Text)).ToString();
                    break;
                case "-":
                    textBox1_result.Text = (resultValue - Double.Parse(textBox1_result.Text)).ToString();
                    break;
                case "*":
                    textBox1_result.Text = (resultValue * Double.Parse(textBox1_result.Text)).ToString();
                    break;
                case "/":
                    if (textBox1_result.Text != "0")
                        textBox1_result.Text = (resultValue / Double.Parse(textBox1_result.Text)).ToString();
                    else
                        MessageBox.Show("Nedei da delish na nula de!");

                    break;
                default:
                    break;
            }
            resultValue = 0;
            CurrentOperation.Text = "";
        }
    }
}
