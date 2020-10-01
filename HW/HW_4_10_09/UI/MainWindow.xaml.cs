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
using System.Windows.Threading;

namespace HW_4_10_09.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dispatcher dispather = Dispatcher.CurrentDispatcher;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            ColorBlock cb = new ColorBlock(new SolidColorBrush(Color.FromArgb((byte)Convert.ToInt32(Alpha_sl.Value), (byte)Convert.ToInt32(Red_sl.Value), (byte)Convert.ToInt32(Green_sl.Value), (byte)Convert.ToInt32(Blue_sl.Value))));
            dispather.Invoke(new Action(() => { MSPanel.Children.Add(cb); })); 
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Alpha_tbl.Text = Convert.ToInt32(Alpha_sl.Value).ToString();
            Red_tbl.Text = Convert.ToInt32(Red_sl.Value).ToString();
            Green_tbl.Text = Convert.ToInt32(Green_sl.Value).ToString();
            Blue_tbl.Text = Convert.ToInt32(Blue_sl.Value).ToString();
            color_br.Background = new SolidColorBrush(Color.FromArgb((byte)Convert.ToInt32(Alpha_sl.Value), (byte)Convert.ToInt32(Red_sl.Value), (byte)Convert.ToInt32(Green_sl.Value), (byte)Convert.ToInt32(Blue_sl.Value)));
        }
    }
}
