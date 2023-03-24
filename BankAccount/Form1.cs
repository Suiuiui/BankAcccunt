using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankAccount
{
    public partial class Form1 : Form
    {
        // Variables to hold the balance, number of deposits, and total deposit amount
        private decimal balance = 0.0m;
        private int numDeposits = 0;
        private decimal totalDeposit = 0.0m;
        private int numChecks = 0;
        private decimal totalChecks = 0.0m;

        public Form1()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            decimal amount = 0.0m;
            bool validAmount = decimal.TryParse(amountTextBox.Text, out amount);

            if (validAmount)
            {
                // Determine the selected transaction type
                if (depositRadioButton.Checked)
                {
                    // Update the balance and number of deposits
                    balance += amount;
                    numDeposits++;
                    totalDeposit += amount;
                }
                else if (checkRadioButton.Checked)
                {
                    // Check if there is enough balance to cover the check
                    if (amount <= balance)
                    {
                        // Update the balance and number of checks
                        balance -= amount;
                        numChecks++;
                        totalChecks += amount;
                    }
                    else
                    {
                        // Display a message box and deduct a service charge of $10
                        MessageBox.Show("Insufficient funds.", "Error");
                        balance -= 10.0m;
                    }
                }
                else if (serviceChargeRadioButton.Checked)
                {
                    // Update the balance by deducting the service charge
                    balance -= amount;
                }

                // Update the balance label
                balanceLabel.Text = balance.ToString("C");
            }
            else
            {
                // Display an error message for invalid amount
                MessageBox.Show("Please enter a valid amount.", "Error");
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // Reset all variables and clear the textboxes and labels
            balance = 0.0m;
            numDeposits = 0;
            totalDeposit = 0.0m;
            numChecks = 0;
            totalChecks = 0.0m;
            balanceLabel.Text = "$0.00";
            amountTextBox.Text = "";
            depositRadioButton.Checked = true;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void summaryButton_Click(object sender, EventArgs e)
        {
            // Display a message box with the summary information
            string summaryMessage = "Number of deposits: " + numDeposits +
                                    "\nTotal deposit amount: " + totalDeposit.ToString("C") +
                                    "\nNumber of checks: " + numChecks +
                                    "\nTotal check amount: " + totalChecks.ToString("C");
            MessageBox.Show(summaryMessage, "Summary");
        }
    }
 }

