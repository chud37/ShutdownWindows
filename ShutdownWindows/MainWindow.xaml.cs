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

namespace ShutdownWindows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private int totalseconds = 0;

        private void SliderHours_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            LabelHours.Content = SliderHours.Value;
            // LabelHours.Content = SliderHours.Value.ToString() + " Hours";
            CalculateSeconds();
        }

        private void SliderMinutes_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            LabelMinutes.Content = SliderMinutes.Value + " Minutes";
            CalculateSeconds();
        }

        private void SliderSeconds_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            LabelSeconds.Content = SliderSeconds.Value + " Seconds";
            CalculateSeconds();
        }


        private void CalculateSeconds()
        {
            double hours = SliderHours.Value;
            double minutes = SliderMinutes.Value;
            double seconds = SliderSeconds.Value;


            totalseconds = 0;
            totalseconds += (int)hours * 3600;
            totalseconds += (int)minutes * 60;
            totalseconds += (int)seconds;

            TotalSecondsSmall.Content = totalseconds.ToString() + " seconds.";


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("CMD.exe", "/C shutdown /a");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (totalseconds != 0) System.Diagnostics.Process.Start("CMD.exe", "/C shutdown /s /t " + totalseconds.ToString());
        }
    }
}
