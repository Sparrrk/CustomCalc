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
using System.Windows.Shapes;
using SmartCalc;

namespace WPFBegin
{
    /// <summary>
    /// Логика взаимодействия для Graphics.xaml
    /// </summary>
    public partial class Graphics : Window
    {
        public Graphics()
        {
            InitializeComponent();
        }

        private void Plot_graph_button_Click(object sender, RoutedEventArgs e)
        {
            double x_initial = Convert.ToDouble(Tb_x_initial.Text);
            double x_final = Convert.ToDouble(Tb_x_final.Text);
            double step = (x_final - x_initial) / 20;
            double[] y_array = new double[20];
            double[] x_array = X_array_filler(x_initial, x_final);
            if (Error_checker.Str_check(Plot_expression.Text) == 0)
            {
                int counter = 0;
                for (double x = x_initial; counter < 20; x += step)
                {
                    Parser.parsing(Plot_expression.Text, x);
                    y_array[counter] = Calculation.Calc(Parser.list);
                    counter++;
                }
                WpfPlot1.Plot.AddScatter(x_array, y_array);
                WpfPlot1.Refresh();
            }
            else
            {
                Plot_expression.Text = "Wrong expression!";
            }
        }

        private double[] X_array_filler(double x_init, double x_fin)
        {
            double[] array = new double[20];
            double step = (x_fin - x_init) / 20;
            for (int i = 0; i < 20; i++)
            {
                array[i] = x_init + step * i;
            }
            return array;
        }
    }
}
