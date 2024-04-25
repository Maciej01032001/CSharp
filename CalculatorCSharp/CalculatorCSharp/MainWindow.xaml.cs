using System.Windows;
using System.Windows.Controls;


namespace CalculatorCSharp
{

    public partial class MainWindow : Window
    {
        private string operation = "";
        private double result = 0;
        private double firstNumber = 0;
        private double secondNumber = 0;
        private bool fraction = false;


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Number(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (button.Content.ToString() == ",")
            {


                if (fraction == false)
                {
                    if (txtCurrentNumber.Text == "")
                    {
                        txtCurrentNumber.Text = "0,";
                    }
                    else
                    {
                        txtCurrentNumber.Text += button.Content.ToString();
                    }
                    fraction = true;
                }
            }
            else
            {
                if (txtCurrentNumber.Text != "0")
                {
                    txtCurrentNumber.Text += button.Content.ToString();
                }
            }

        }

        private void Operation(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Content.ToString();
            if ((operation == "-" & txtCurrentNumber.Text == "" & txtOperator.Text == "") | (txtCurrentNumber.Text == "-"))
            {
                txtCurrentNumber.Text = "-";
            }
            else if ((txtCurrentNumber.Text == "") & (txtResult.Text == ""))
            {
                txtResult.Text = "0";
                txtOperator.Text = operation;
            }
            else if (txtCurrentNumber.Text != "")
            {
                txtResult.Text = txtCurrentNumber.Text.TrimEnd(',');
                txtOperator.Text = operation;
                txtCurrentNumber.Text = "";
                fraction = false;
            }
            else
            {
                txtOperator.Text = operation;
            }
        }

        private void Equals(object sender, RoutedEventArgs e)
        {
            if ((txtResult.Text != "") & (txtCurrentNumber.Text != ""))
            {
                firstNumber = double.Parse(txtResult.Text);
                secondNumber = double.Parse(txtCurrentNumber.Text);
                switch (operation)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    case "/":
                        if (secondNumber == 0)
                        {
                            MessageBox.Show("You can't divide by 0");
                            break;
                        }
                        result = firstNumber / secondNumber;
                        break;
                    case "*":
                        result = firstNumber * secondNumber;
                        break;

                }
                txtCurrentNumber.Text = result.ToString();
                if (txtCurrentNumber.Text.Contains(","))
                {
                    txtCurrentNumber.Text = txtCurrentNumber.Text.TrimEnd('0').TrimEnd(',');
                }
                result = 0;
                txtOperator.Text = "";
                txtResult.Text = "";
            }
        }

        private void CleanCurrent(object sender, RoutedEventArgs e)
        {
            txtCurrentNumber.Text = "";
            fraction = false;
        }

        private void CleanAll(object sender, RoutedEventArgs e)
        {
            txtCurrentNumber.Text = "";
            txtResult.Text = "";
            txtOperator.Text = "";
            fraction = false;
        }

        private void CleanOne(object sender, RoutedEventArgs e)
        {

            txtCurrentNumber.Text = txtCurrentNumber.Text.Substring(0, txtCurrentNumber.Text.Length - 1);

        }
    }
}