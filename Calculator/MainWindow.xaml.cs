using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedOperator;
        public MainWindow()
        {
            InitializeComponent();
            acButton.Click += AcButton_Click;
            plusminusButton.Click += PlusminusButton_Click;
            percentageButton.Click += PercentageButton_Click;
            decimalButton.Click += DecimalButton_Click;
            equalButton.Click += EqualButton_Click;

        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double firstNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out firstNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = lastNumber + firstNumber;
                        break;
                    case SelectedOperator.Subtraction:
                        result = lastNumber - firstNumber;
                        break;
                    case SelectedOperator.Multiplication:
                        result = lastNumber * firstNumber;
                        break;
                    case SelectedOperator.Division:
                        result = lastNumber / firstNumber;
                        break;
                }
                resultLabel.Content = result;
            }
        }

        private void OperationButton_Click(object sender,RoutedEventArgs e)
        {
            if(double.TryParse(resultLabel.Content.ToString(),out lastNumber))
            {
                resultLabel.Content = "0";
            }
            if (sender == additionButton)
                selectedOperator = SelectedOperator.Addition;
            if (sender == subtractionButton)
                selectedOperator = SelectedOperator.Subtraction;
            if (sender == multiplicationButton)
                selectedOperator = SelectedOperator.Multiplication;
            if (sender == divisionButton)
                selectedOperator = SelectedOperator.Division;

        }

        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            if (!resultLabel.Content.ToString().Contains("."))
            {
                resultLabel.Content += ".";
            }
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLabel.Content.ToString(),out lastNumber))
            {
                lastNumber = lastNumber / 100;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void PlusminusButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLabel.Content.ToString(),out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = int.Parse((sender as Button).Content.ToString());
            if(resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = selectedValue.ToString();
            }
            else
            {
                resultLabel.Content += selectedValue.ToString();
            }
        }

        public enum SelectedOperator
        {
            Addition,
            Subtraction,
            Multiplication,
            Division
        }

    }
}
