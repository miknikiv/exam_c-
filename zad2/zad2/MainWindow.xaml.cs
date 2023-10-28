using System;
using System.Windows;
using System.Windows.Controls;

namespace CalculatorApp
{
    public partial class MainWindow : Window
    {
        private string currentInput = "";
        private double currentValue = 0;
        private double previousValue = 0;
        private string currentOperation = "";
        private bool isNewNumber = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string digit = button.Content.ToString();

            if (isNewNumber)
            {
                display.Text = digit;
                isNewNumber = false;
            }
            else
            {
                display.Text += digit;
            }

            currentValue = double.Parse(display.Text);
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string operation = button.Content.ToString();

            if (!isNewNumber)
            {
                if (!string.IsNullOrEmpty(currentOperation))
                {
                    currentValue = PerformOperation(currentOperation, currentValue, previousValue);
                    display.Text = currentValue.ToString();
                }
                else
                {
                    currentValue = double.Parse(display.Text);
                    previousValue = currentValue;
                }

                currentInput = "";
                currentOperation = operation;
                isNewNumber = true;
            }
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (!isNewNumber)
            {
                if (!string.IsNullOrEmpty(currentOperation))
                {
                    currentValue = PerformOperation(currentOperation, currentValue, previousValue);
                    display.Text = currentValue.ToString();
                    currentInput = currentValue.ToString();
                    currentOperation = "";
                    isNewNumber = true;
                }
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            display.Text = "0";
            currentInput = "";
            currentValue = 0;
            currentOperation = "";
            isNewNumber = true;
        }

        private void SignChange_Click(object sender, RoutedEventArgs e)
        {
            if (!isNewNumber)
            {
                double number = double.Parse(display.Text);
                number = -number;
                display.Text = number.ToString();
                currentInput = number.ToString();
            }
        }

        private void Percent_Click(object sender, RoutedEventArgs e)
        {
            if (!isNewNumber)
            {
                double number = double.Parse(display.Text);
                number = number / 100;
                display.Text = number.ToString();
                currentInput = number.ToString();
            }
        }

        private void SquareRoot_Click(object sender, RoutedEventArgs e)
        {
            if (!isNewNumber)
            {
                double number = double.Parse(display.Text);
                number = Math.Sqrt(number);
                display.Text = number.ToString();
                currentInput = number.ToString();
            }
        }

        private void Reciprocal_Click(object sender, RoutedEventArgs e)
        {
            if (!isNewNumber)
            {
                double number = double.Parse(display.Text);
                number = 1 / number;
                display.Text = number.ToString();
                currentInput = number.ToString();
            }
        }

        private void Factorial_Click(object sender, RoutedEventArgs e)
        {
            if (!isNewNumber)
            {
                int number = (int)double.Parse(display.Text);
                int result = CalculateFactorial(number);
                display.Text = result.ToString();
                currentInput = result.ToString();
            }
        }

        private void Logarithm_Click(object sender, RoutedEventArgs e)
        {
            if (!isNewNumber)
            {
                double number = double.Parse(display.Text);
                number = Math.Log10(number);
                display.Text = number.ToString();
                currentInput = number.ToString();
            }
        }

        private void Modulo_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string operation = button.Content.ToString();

            if (!isNewNumber)
            {
                if (!string.IsNullOrEmpty(currentOperation))
                {
                    currentValue = PerformOperation(currentOperation, currentValue, double.Parse(currentInput));
                    display.Text = currentValue.ToString();
                }
                else
                {
                    currentValue = double.Parse(currentInput);
                }

                currentInput = "";
                currentOperation = operation;
                isNewNumber = true;
            }
        }

        private void Floor_Click(object sender, RoutedEventArgs e)
        {
            if (!isNewNumber)
            {
                double number = double.Parse(display.Text);
                number = Math.Floor(number);
                display.Text = number.ToString();
                currentInput = number.ToString();
            }
        }

        private void Ceiling_Click(object sender, RoutedEventArgs e)
        {
            if (!isNewNumber)
            {
                double number = double.Parse(display.Text);
                number = Math.Ceiling(number);
                display.Text = number.ToString();
                currentInput = number.ToString();
            }
        }

        private void Sqrt_Click(object sender, RoutedEventArgs e)
        {
            if (!isNewNumber)
            {
                double number = double.Parse(display.Text);
                number = Math.Sqrt(number);
                display.Text = number.ToString();
                currentInput = number.ToString();
            }
        }


        private double PerformOperation(string operation, double leftOperand, double rightOperand)
        {
            switch (operation)
            {
                case "+":
                    return leftOperand + rightOperand;
                case "-":
                    return leftOperand - rightOperand;
                case "*":
                    return leftOperand * rightOperand;
                case "/":
                    return leftOperand / rightOperand;
                case "%":
                    return Modulo(leftOperand, rightOperand);
                case "^": // Potęgowanie
                    return Pow(leftOperand, rightOperand);
                case "!": // Silnia
                    return Factorial((int)leftOperand);
                case "log": // Logarytm
                    return Logarithm(leftOperand, rightOperand);
                case "⌊": // Zaokrąglenie w dół
                    return Floor(leftOperand);
                case "⌈": // Zaokrąglenie w górę
                    return Ceiling(leftOperand);
                case "1/x":
                    return 1 / leftOperand;
                default:
                    return rightOperand;
            }
        }


        private int CalculateFactorial(int number)
        {
            if (number == 0)
                return 1;
            else
                return number * CalculateFactorial(number - 1);
        }

        private double Pow(double baseValue, double exponent)
        {
            return Math.Pow(baseValue, exponent);
        }

        private double Modulo(double dividend, double divisor)
        {
            if (divisor == 0)
            {
                // Handle division by zero if necessary
                return double.NaN;
            }
            return dividend % divisor;
        }

        private double Factorial(int n)
        {
            if (n < 0)
            {
                // Handle negative input if necessary
                return double.NaN;
            }

            if (n == 0)
            {
                return 1;
            }

            double result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        private double Logarithm(double value, double baseValue)
        {
            if (value <= 0 || baseValue <= 0)
            {
                // Handle invalid input if necessary
                return double.NaN;
            }
            return Math.Log(value, baseValue);
        }

        private double Floor(double value)
        {
            return Math.Floor(value);
        }

        private double Ceiling(double value)
        {
            return Math.Ceiling(value);
        }
    }
}
