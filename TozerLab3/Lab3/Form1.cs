using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /* Name: Lincoln Tozer
         * Date: 2024-10-24
         * This program calculates an annuity */

        double totalPayment = 0;
        const int MINYEARS = 5;
        const string MYNAME = "Lincoln Tozer";


        private void picHelp_Click(object sender, EventArgs e)

            //Displays Message Box when Help is clicked
        {
            string helpMessage = "This program reads in 2 numbers:\n\t" +
                "Future Value: amount of \"$\"\n\t" +
                "Years: must be at least " + MINYEARS + "\n" +
                "and calculates payments based on: \n\t" +
                "Yearly interest rate of " + lblRatePerYear.Text+"%";
            MessageBox.Show(helpMessage, MYNAME);       

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //When Exit is clicked, Display Messagebox and close program
            string exitMessage = "Thanks for using the program! \n" +
                "Total Payments = " + (totalPayment.ToString("C"));
            MessageBox.Show(exitMessage, MYNAME);
            Close();
        }
        private void ResetAll()
        {
            //Function for reset of program
            grpSolution.Hide();
            txtFutureValue.Clear();
            txtYears.Clear();
            lblSolution.Text = "";
            txtFutureValue.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //Reset when Reset button is clicked
            ResetAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Reset when form is loaded
            ResetAll();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //Perfom calculation
            
            //check for correct datatype
            try
            {
                //declare variables
                double futureValue = Convert.ToDouble(txtFutureValue.Text);
                double payment;
                double yearlyRate = Convert.ToDouble(lblRatePerYear.Text) / 100;
                int years = Convert.ToInt32(txtYears.Text);
                
                //make sure years is minyears or greater
                if (years >= MINYEARS)
                {
                    //calculate and show
                    payment = futureValue * (yearlyRate / 12) / (Math.Pow(1 + (yearlyRate / 12), years * 12) - 1);
                    lblSolution.Text = payment.ToString("C");
                    grpSolution.Show();
                    //calculate total payment
                    totalPayment = totalPayment + payment;
                }
                else
                {
                    //if years is under minyears
                    MessageBox.Show("Years must be at least "+MINYEARS, MYNAME);
                    txtYears.Clear();
                    txtYears.Focus();
                }
            }
            catch (Exception ex)
            {
                //if wrong datatype
                MessageBox.Show("Message encountered \n"+ ex.Message, MYNAME);

            }

        }
    }
}
 