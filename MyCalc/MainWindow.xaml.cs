using SmartCalc;
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

namespace WPFBegin
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void hollow_checker(string obj)
        {
            if (Board.Text == "0")
                Board.Text = obj;
            else
                Board.Text += obj;
        }

        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Board.Text = "0";
        }

        private void Factorial_button_Click(object sender, RoutedEventArgs e)
        {
            Board.Text += '!';
        }

        private void Div_button_Click(object sender, RoutedEventArgs e)
        {
            Board.Text += ':';
        }

        private void Mult_button_Click(object sender, RoutedEventArgs e)
        {
            Board.Text += '*';
        }

        private void Sum_button_Click(object sender, RoutedEventArgs e)
        {
            Board.Text += '+';
        }

        private void Dif_button_Click(object sender, RoutedEventArgs e)
        {
            Board.Text += '-';
        }

        private void Sin_button_Click(object sender, RoutedEventArgs e)
        {
            hollow_checker("sin");
        }

        private void Cos_button_Click(object sender, RoutedEventArgs e)
        {
            hollow_checker("cos");
        }

        private void Seven_button_Click(object sender, RoutedEventArgs e)
        {
            hollow_checker("7");
        }

        private void Eight_button_Click(object sender, RoutedEventArgs e)
        {
            hollow_checker("8");
        }

        private void Nine_button_Click(object sender, RoutedEventArgs e)
        {
            hollow_checker("9");
        }

        private void Сtg_button_Click(object sender, RoutedEventArgs e)
        {
            hollow_checker("ctg");
        }

        private void Asin_button_Click(object sender, RoutedEventArgs e)
        {
            hollow_checker("asin");
        }

        private void Tan_button_Click(object sender, RoutedEventArgs e)
        {
            hollow_checker("tan");
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            hollow_checker("6");
        }

        private void Five_button_Click(object sender, RoutedEventArgs e)
        {
            hollow_checker("5");
        }

        private void Four_button_Click(object sender, RoutedEventArgs e)
        {
            hollow_checker("4");
        }

        private void Atan_button_Click(object sender, RoutedEventArgs e)
        {
            hollow_checker("atan");
        }

        private void X_button_Click(object sender, RoutedEventArgs e)
        {
            hollow_checker("x");
        }

        private void Pow_button_Click(object sender, RoutedEventArgs e)
        {
            Board.Text += '^';
        }

        private void Three_button_Click(object sender, RoutedEventArgs e)
        {
            hollow_checker("3");
        }

        private void Two_button_Click(object sender, RoutedEventArgs e)
        {
            hollow_checker("2");
        }

        private void One_button_Click(object sender, RoutedEventArgs e)
        {
            hollow_checker("1");
        }

        private void Open_bracket_button_Click(object sender, RoutedEventArgs e)
        {
            hollow_checker("(");
        }

        private void Closer_button_Click(object sender, RoutedEventArgs e)
        {
            hollow_checker(")");
        }

        private void Point_button_Click(object sender, RoutedEventArgs e)
        {
            Board.Text += '.';
        }

        private void Graph_button_Click(object sender, RoutedEventArgs e)
        {
            Graphics graph_window = new Graphics();
            graph_window.Show();
        }

        private void Zero_button_Click(object sender, RoutedEventArgs e)
        {
            hollow_checker("0");
        }

        private void Acos_button_Click(object sender, RoutedEventArgs e)
        {
            hollow_checker("acos");
        }

        private void Equal_button_Click(object sender, RoutedEventArgs e)
        {
            if (Error_checker.Str_check(Board.Text) == 0) {
                Parser.parsing(Board.Text, 0);
                double res = Calculation.Calc(Parser.list);
                Board.Text = Convert.ToString(res);
            } else
            {
                Board.Text = "Wrong expression!";
            }
        }
    }
}
