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

namespace HW_4_10_09.UI
{
    /// <summary>
    /// Interaction logic for ColorBlock.xaml
    /// </summary>
    public partial class ColorBlock : UserControl
    {
        public ColorBlock()
        {
            InitializeComponent();
        }

        public ColorBlock(SolidColorBrush scb)
        {
            InitializeComponent();
            color_rbl.Text = scb.ToString();
            color_br.Background = scb;
        }
    }
}
