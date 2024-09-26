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
        // Initialize variables for future operations
        Double numValue = 0;
        String operation = "";
        bool operationClicked = false;

        public MainForm()
        {
            InitializeComponent();
            btnBackspace.Text = "\u232B"; // Set backspace button to display Unicode backspace character
        }

        // All number buttons share this dynamic click event,
        // rather than each having their own separate events with duplicate code.
        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (txtbDisplay.Text == "0" || operationClicked)
                txtbDisplay.Clear();

            operationClicked = false;
            Button btn = (Button)sender;
            txtbDisplay.Text = txtbDisplay.Text + btn.Text;
        } // end function

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            // Allow for only one decimal per equation
            if (!txtbDisplay.Text.Contains("."))
            {
                Button btn = (Button)sender;
                if (numValue == 0)
                {
                    txtbDisplay.Text = 0.ToString();
                }
                txtbDisplay.Text = txtbDisplay.Text + btn.Text;
            }
        } // end function

        private void operator_Click(object sender, EventArgs e)
        {
            // Capture the value of the button clicked and set the operator varible to that button's value
            Button btn = (Button)sender;
            operation = btn.Text;

                // Capture and parse the current value to be operated on
                numValue = Double.Parse(txtbDisplay.Text);
                operationClicked = true;
        } // end function

        private void btnEquals_Click(object sender, EventArgs e)
        {
            // Calculate result based on operation clicked
            switch (operation)
            {
                case "+":
                    txtbDisplay.Text = (numValue + Double.Parse(txtbDisplay.Text)).ToString();
                    break;
                case "-":
                    txtbDisplay.Text = (numValue - Double.Parse(txtbDisplay.Text)).ToString();
                    break;
                case "*":
                    txtbDisplay.Text = (numValue * Double.Parse(txtbDisplay.Text)).ToString();
                    break;
                case "/":
                    txtbDisplay.Text = (numValue / Double.Parse(txtbDisplay.Text)).ToString();
                    break;
                default:
                    break;
            } // end switch
        } // end function

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            txtbDisplay.Text = "0"; // Reset the display
        } // end function

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtbDisplay.Text = "0"; // Reset the display
            numValue = 0; // Reset value to allow for a new equation to be entered
        } // end function

        private void btnPosNeg_Click(object sender, EventArgs e)
        {
            // If a number is positive, make it negative, and vice versa
            txtbDisplay.Text = (Double.Parse(txtbDisplay.Text) * -1).ToString();
        } // end function

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            // Code reference: https://www.codeproject.com/Questions/1209099/Backspace-function-in-Csharp
            // Delete first operand
            if (!operationClicked && txtbDisplay.Text.Length > 0)
            {
                txtbDisplay.Text = txtbDisplay.Text.Remove(txtbDisplay.Text.Length - 1);
            }
        } // end function

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            txtbDisplay.Text = txtbDisplay.Text + btn.Text;
        }
    } // end class
} // end namespace
