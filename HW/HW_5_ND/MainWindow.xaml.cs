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

namespace HW_5_ND
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random r = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Grid.SetColumn(MButton, r.Next(0, 4));
            Grid.SetRow(MButton, r.Next(0, 4));
        }

        private void MButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You are Win!");
        }
    }
}
