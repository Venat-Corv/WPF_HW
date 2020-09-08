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

namespace HW_1_07_09.UI
{
    /// <summary>
    /// Interaction logic for Calc.xaml
    /// </summary>
    public partial class Calc : UserControl
    {
        public static Calc hwid = new Calc();
        public Calc()
        {
            InitializeComponent();
            hwid = (hwid != null) ? hwid : this;
        }

        private void back_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.hwid.MainBoard.Children.Add(Menu.hwid);
            MainWindow.hwid.MainBoard.Children.Remove(this);
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            this.operation_tb.Text += sender.ToString().Split(':')[1];
        }
    }
}
