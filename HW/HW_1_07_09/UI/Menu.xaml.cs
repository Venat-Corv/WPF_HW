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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        public static Menu hwid = new Menu();
        public Menu()
        {
            InitializeComponent();
            hwid = (hwid != null) ? hwid : this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            MainWindow.hwid.MainBoard.Children.Add(ColorBatton.hwid);
            MainWindow.hwid.MainBoard.Children.Remove(this);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow.hwid.MainBoard.Children.Add(Calc.hwid);
            MainWindow.hwid.MainBoard.Children.Remove(this);
        }
    }
}
