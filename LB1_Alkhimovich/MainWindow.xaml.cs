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

namespace LB1_Alkhimovich
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double Value1;
        public double Value2;
        public string Do;
        public double Result;
        public bool flag=false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int lastNewLineIndex = TextBl.Text.LastIndexOf(Environment.NewLine);
            
            Display.Text = "0";
            if (flag == true) { TextBl.Text += Environment.NewLine; flag = false; return; }
            try
            {
                TextBl.Text = TextBl.Text.Remove(lastNewLineIndex);
            }
            catch (ArgumentOutOfRangeException)
            {
                TextBl.Text = "";
            }
            TextBl.Text += Environment.NewLine;
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Content.ToString();
            if (Display.Text == "Деление на 0!") { Display.Text = ""; }
                if (Display.Text == "0")
            {
                Display.Text = buttonText;
            }
            else
            {
                Display.Text += buttonText;
            }
        }
        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string operation = button.Content.ToString();

            switch (operation)
            {
                case ",":
                    if (!Display.Text.Contains(","))
                    {
                        Display.Text += ",";
                    }
                    break;
                case "+":
                    TextBl.Text += Display.Text + " + ";
                    double.TryParse(Display.Text, out Value1);
                    Display.Text = "";
                    Do = "+";
                    break;
                case "-":
                    TextBl.Text += Display.Text + " - ";
                    double.TryParse(Display.Text, out Value1);
                    Display.Text = "";
                    Do = "-";
                    break;
                case "X":
                    TextBl.Text += Display.Text + " x ";
                    double.TryParse(Display.Text, out Value1);
                    Display.Text = "";
                    Do = "X";
                    break;
                case "/":
                    TextBl.Text += Display.Text + " / ";
                    double.TryParse(Display.Text, out Value1);
                    Display.Text = "";
                    Do = "/";
                    break;
                case "X ⁿ":
                    TextBl.Text += Display.Text + " X ⁿ ";
                    double.TryParse(Display.Text, out Value1);
                    Display.Text = "";
                    Do = "X ⁿ";
                    break;
                case "1/X":
                    flag = true;
                    double.TryParse(Display.Text, out Value1);
                    Result = Math.Round(1 / Value1,11);
                    TextBl.Text +=  "1/" + Display.Text + "=" + Result;
                    Display.Text = "";
                    Button_Click_2(sender, e);
                    Display.Text = Result.ToString();
                    break;
                case "SQRT":
                    flag = true;
                    double.TryParse(Display.Text, out Value1);
                    Result = Math.Round(Math.Sqrt (Value1),11);
                    TextBl.Text += "Sqrt " + Display.Text + " = " + Result;
                    Display.Text = "";
                    Button_Click_2(sender, e);
                    Display.Text = Result.ToString();
                    break;
                case "sin":
                    flag = true;
                    double.TryParse(Display.Text, out Value1);
                    if (GRAD.IsChecked == true)
                    {
                        Result = Math.Round(Math.Sin(Value1), 11);
                        TextBl.Text += "Sin " + Display.Text + " = " + Result;
                        Display.Text = "";
                    }
                    else
                    {
                        Value1 = Math.PI * Value1 / 180.0;
                        Result = Math.Round(Math.Sin(Value1), 11);
                        TextBl.Text += "Sin " + Display.Text + " = " + Result;
                        Display.Text = "";
                    }
                    Button_Click_2(sender, e);
                    Display.Text = Result.ToString();
                    break;
                case "cos":
                    flag = true;
                    double.TryParse(Display.Text, out Value1);
                    if (GRAD.IsChecked == true)
                    {
                        Result = Math.Round(Math.Cos(Value1), 11);
                        TextBl.Text += "Cos " + Display.Text + " = " + Result;
                        Display.Text = "";
                    }
                    else
                    {
                        Value1 = Math.PI * Value1 / 180.0;
                        Result = Math.Round(Math.Cos(Value1), 11);
                        TextBl.Text += "Cos " + Display.Text + " = " + Result;
                        Display.Text = "";
                    }
                    Button_Click_2(sender, e);
                    Display.Text = Result.ToString();
                    break;
                case "tg":
                    flag = true;
                    double.TryParse(Display.Text, out Value1);
                    if (GRAD.IsChecked == true)
                    {
                        Result = Math.Round(Math.Tan(Value1), 11);
                        TextBl.Text += "Tg " + Display.Text + " = " + Result;
                        Display.Text = "";
                    }
                    else
                    {
                        Value1 = Math.PI * Value1 / 180.0;
                        Result = Math.Round(Math.Tan(Value1), 11);
                        TextBl.Text += "Tg " + Display.Text + " = " + Result;
                        Display.Text = "";
                    }
                    Button_Click_2(sender, e);
                    Display.Text = Result.ToString();
                    break;

                case "+/-":
                    if (Display.Text == "0")
                    {
                        Display.Text = "-";
                    }
                    else
                    if (Display.Text.StartsWith("-"))
                    {
                        Display.Text = Display.Text.Substring(1);
                    }
                    else
                    {
                        Display.Text = "-" + Display.Text; 
                    }
                    break;
            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string operation = button.Content.ToString();
            if (operation == "=")
            {
                double.TryParse(Display.Text, out Value2);
                if (Do == "+")
                {
                    Result =Value1 + Value2;
                    Display.Text = Result.ToString();
                    TextBl.Text += Value2 + " = " + Result + Environment.NewLine;
                }
                if (Do == "-")
                {
                    Result = Value1 - Value2;
                    Display.Text = Result.ToString();
                    TextBl.Text += Value2 + " = " + Result + Environment.NewLine;
                }
                if (Do == "X")
                {
                    Result = Value1 * Value2;
                    Display.Text = Result.ToString();
                    TextBl.Text += Value2 + " = " + Result + Environment.NewLine;
                }
                if (Do == "X ⁿ")
                {
                    Result = Math.Pow(Value1, Value2);
                    Display.Text = Result.ToString();
                    TextBl.Text += Value2 + " = " + Result + Environment.NewLine;
                }

                if (Do == "/")
                {
                    int lastNewLineIndex = TextBl.Text.LastIndexOf(Environment.NewLine);
                    if (Value2 == 0) 
                    { 
                        Display.Text = "Деление на 0!";
                        try
                        {
                            TextBl.Text = TextBl.Text.Remove(lastNewLineIndex);
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            TextBl.Text = "";
                        }
                        TextBl.Text +=  Environment.NewLine;
                        return;
                    }
                    Result = Value1 / Value2;
                    Display.Text = Result.ToString();
                    TextBl.Text += Value2 + " = " + Result + Environment.NewLine;
                }
            }

            
        }

    }
    }

