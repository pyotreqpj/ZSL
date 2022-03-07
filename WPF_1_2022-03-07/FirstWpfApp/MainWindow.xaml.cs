using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Xps.Serialization;

namespace FirstWpfApp
{
    public enum OperationType
    {
        Unknown = 0,
        Add = 1,
        Substraction = 2,
        Multiplying = 3,
        Division = 4,
    }

    public partial class MainWindow : Window
    {
        private int? firstNumber;
        private int? secondNumber;
        private OperationType operationType;
        private char operationSign;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Number_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button) sender;

            if (!int.TryParse(button.Content.ToString(), out int result)) {
                _ = MessageBox.Show(
                    $"Can not parse number (\"{button.Content}\")",
                    "Error",
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error);
                return;
            }

            SetValues(result);
            Calculate();
        }

        private void Button_Operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Operation(button.Content.ToString());
        }

        private void Operation(string content)
        {
            switch (content)
            {
                case "+":
                    operationType = OperationType.Add;
                    ResultTextBox.Text += "+";
                    break;
                case "-":
                    operationType = OperationType.Substraction;
                    ResultTextBox.Text += "-";
                    break;
                case "*":
                    operationType = OperationType.Multiplying;
                    ResultTextBox.Text += "*";
                    break;
                case "/":
                    operationType = OperationType.Division;
                    ResultTextBox.Text += "/";
                    break;
            }
        }

        private void SetValues(int value)
        {
            if (firstNumber == null)
            {
                firstNumber = value;
            }
            else if (secondNumber == null)
            {
                secondNumber = value;
            }
            else
            {
                firstNumber = value;
                secondNumber = null;
                ResultTextBox.Text = string.Empty;
            }

            ResultTextBox.Text += value.ToString();
        }

        private void Calculate()
        {
            if (firstNumber == null || secondNumber == null)
            {
                return;
            }

            Calculate((float) firstNumber, (float) secondNumber);
        }

        private void ResultTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            var textbox = (TextBox)sender;

            if (textbox.Text.Length <= 0)
            {
                return;
            }

            var lastChar = textbox.Text[^1];

            switch (lastChar)
            {
                case '=':
                    string[] numbers = textbox.Text.Split(operationSign, '=');
                    var a = float.Parse(numbers[0]);
                    var b = float.Parse(numbers[1]);
                    Calculate(a, b);
                    break;
                case '+':
                    operationType = OperationType.Add;
                    operationSign = '+';
                    break;
                case '-':
                    operationType = OperationType.Substraction;
                    operationSign = '-';
                    break;
                case '*':
                    operationType = OperationType.Multiplying;
                    operationSign = '*';
                    break;
                case '/':
                    operationType = OperationType.Division;
                    operationSign = '/';
                    break;
            }
        }

        private void Calculate(float firstNumber, float secondNumber)
        {
            switch (operationType)
            {
                case OperationType.Unknown:
                    break;
                case OperationType.Add:
                    ResultTextBox.Text += $"{firstNumber + secondNumber}";
                    break;
                case OperationType.Substraction:
                    ResultTextBox.Text += $"{firstNumber - secondNumber}";
                    break;
                case OperationType.Multiplying:
                    ResultTextBox.Text += $"{firstNumber * secondNumber}";
                    break;
                case OperationType.Division:
                    ResultTextBox.Text += $"{firstNumber / secondNumber}";
                    break;
            }
        }
    }
}
