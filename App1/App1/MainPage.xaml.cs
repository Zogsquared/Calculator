using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        int currentState = 1;
        string myoperator;
        double firstNumber, secondNumber;

        public MainPage()
        {
            InitializeComponent();
            OnClear(this, null);
            this.typeText.Text = "";
        }

        void OnSelectNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;


            string pressed = button.Text;
            this.typeText.Text += button.Text;

            if (this.resultText.Text == "0" || currentState < 0)
            {
                this.resultText.Text = "";

                if (currentState < 0)
                    currentState *= -1;
            }

            this.resultText.Text += pressed;

            double number;
            if (double.TryParse(this.resultText.Text, out number))
            {
                this.resultText.Text = number.ToString("");
                if (currentState == 1)
                {
                    firstNumber = number;
                }
                else
                {
                    secondNumber = number;
                }
            }
        }

        void OnSelectOperator(object sender, EventArgs e)
        {
            currentState = -2;
            Button button = (Button)sender;
            string pressed = button.Text;
            this.typeText.Text += " " + button.Text + " ";
            myoperator = pressed;
        }

        void OnClear(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            currentState = 1;
            this.resultText.Text = "0";
            this.typeText.Text = "";
        }

        void OnPercentage(object sender, EventArgs e)
        {
            if ((currentState == -1) || (currentState == 1))
            {
                var result = firstNumber / 100;
                this.resultText.Text = result.ToString();
                firstNumber = result;
                currentState = -1;
            }
        }

        void OnCalculate(object sender, EventArgs e)
        {
            if (currentState == 2)
            {
                this.typeText.Text = "";
                var result = OperatorHelper.Calculate(firstNumber, secondNumber, myoperator);

                this.resultText.Text = result.ToString();
                firstNumber = result;
                currentState = -1;
            }
        }

        void OnSquareRoot(object sender, EventArgs e) 
        {
            if ((currentState == -1) || (currentState == 1))
            {
                
                var result = Math.Sqrt(firstNumber);

                this.resultText.Text = result.ToString();
                firstNumber = result;
                currentState = -1;
            }
        }
    }
}
