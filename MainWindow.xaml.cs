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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            num2 = false;
            InitializeComponent();
        }
        public double First_num;
        public double Second_num;
        public string sign;
        public bool num2;
        double result = 0;
        double Accumulator, Operand;
        double memory = 0;
        private void digit_click(object sender, RoutedEventArgs e)
        {
            if (num2)
            {
                num2 = false;
                Enter_field.Text = "0";
            }
            if (Enter_field.Text.Length < 16) {
               
                if (Enter_field.Text == "0")
                {
                    Enter_field.Text = (sender as Button).Content.ToString();
                }
                else
                {
                    Enter_field.Text = Enter_field.Text + (sender as Button).Content.ToString();
                }   
            }
        }

        private void operation_click(object sender, RoutedEventArgs e)
        {
            sign = (sender as Button).Content.ToString();
            First_num = double.Parse(Enter_field.Text);
            
            Operation_field.Text = First_num.ToString() + " " + sign;
            num2 = true;
           
        }

        private void equal_click(object sender, RoutedEventArgs e)
        {
            
            
            
            Accumulator = First_num;
            
            Operand = double.Parse(Enter_field.Text);
            
            
            if (sign == "+")
            {
                result = Accumulator + Operand;
                Operation_field.Text = result.ToString() + " " + "+";
            }
            if (sign == "-")
            {
                result = Accumulator - Operand;
                Operation_field.Text = result.ToString() + " " + "-";
            }
            if (sign == "/")
            {
                if (Operand == 0)
                {
                    Enter_field.Text = "Деление на ноль невозможно";
                }
                else
                {
                    result = Accumulator / Operand;
                    Operation_field.Text = result.ToString() + " " + "/";
                }
            }
            if (sign == "*")
            {
                result = Accumulator * Operand;
                Operation_field.Text = result.ToString() + " " + "*";
            }

            sign = "=";
            
                Enter_field.Text = result.ToString();
                Operation_field.Text = "";
                
            
            num2 = true;
        }

        private void Clear_click(object sender, RoutedEventArgs e)
        {
            Enter_field.Text = "0";
            Operation_field.Text = "";
            First_num = 0;
        }

        private void plus_minus_click(object sender, RoutedEventArgs e)
        {
            if (double.Parse(Enter_field.Text)!= 0)
                First_num = -(double.Parse(Enter_field.Text));
                Enter_field.Text = First_num.ToString();
            
        }

        private void sqrt_click(object sender, RoutedEventArgs e)
        {
            if (double.Parse(Enter_field.Text) < 0)
            {
                Enter_field.Text = "Недопустимый ввод";
            }
            else
            {
                First_num = Math.Sqrt(double.Parse(Enter_field.Text));
                Enter_field.Text = First_num.ToString();
            }
        }

        private void onedel_click(object sender, RoutedEventArgs e)
        {
            if (double.Parse(Enter_field.Text) != 0) 
            {
                Operation_field.Text = "reciproc("+ Enter_field.Text + ")";
                First_num = 1 / (double.Parse(Enter_field.Text));
                Enter_field.Text = First_num.ToString();
                
            }
            if (double.Parse(Enter_field.Text) == 0)
            {
                Enter_field.Text = "Деление на ноль невозможно";
            }
            num2 = true;
        }

        
        private void double_click(object sender, RoutedEventArgs e)
        {
            if (!Enter_field.Text.Contains(","))
            Enter_field.Text = Enter_field.Text + ",";

        }

        private void backclear_click(object sender, RoutedEventArgs e)
        {
            Enter_field.Text = Enter_field.Text.Substring(0, Enter_field.Text.Length - 1);
            if (Enter_field.Text == "")
            {
                Enter_field.Text = "0";
            }
        }


        private void percent_click(object sender, RoutedEventArgs e)
        {            
            Operand = (First_num * double.Parse(Enter_field.Text))/100;
            
            Enter_field.Text = "";
            Operation_field.Text += Operand.ToString();
            Enter_field.Text = Operand.ToString();
        }
        
        private void num(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                Enter_field.Text += e.Key.ToString();
            }
        }

        private void MS_click(object sender, RoutedEventArgs e)
        {
         
                memory = double.Parse(Enter_field.Text);
                num2 = true;
            
        }

        private void MR_click(object sender, RoutedEventArgs e)
        {
                Enter_field.Text = memory.ToString();
                num2 = true;
        }

        private void MC_click(object sender, RoutedEventArgs e)
        {   
            memory = 0;
            num2 = true;
        }

        private void mem_plus_click(object sender, RoutedEventArgs e)
        {
            memory += double.Parse(Enter_field.Text);
            num2 = true;
        }

        private void _click(object sender, RoutedEventArgs e)
        {

        }

        private void mem_minus_click(object sender, RoutedEventArgs e)
        {
            memory -= double.Parse(Enter_field.Text);
            num2 = true;
        }

        private void Enter_field_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Enter_field.Text.Length >= 14)
            {
                Enter_field.FontSize = 19;

            }
        }

        private void hover__color(object sender, MouseEventArgs e)
        {
            
        }

        private void clear_ce_click(object sender, RoutedEventArgs e)
        {
            Enter_field.Text = "0";
            if (num2 == true)
            {
                Operand = 0;
            } else
            {
                Accumulator = 0;
            }

        }
    }
}
