using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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

namespace HW_3_09_09
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static bool isBold { get; set; }
        private static bool isItalic { get; set; }
        private static bool isUnder { get; set; }


        //private static ObservableCollection<Test> size_list = new ObservableCollection<Test> { };
        private static List<int> size_list = new List<int> { };
        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 50; i++)
            {
                //this.cmbSize.ItemsSource = 
                size_list.Add(i + 1);
            }
            cmbColors.ItemsSource = typeof(Colors).GetProperties();
            cmbColors.SelectionChanged += cmbColors_SelectionChanged;
            cmbSize.ItemsSource = size_list;
            cmbSize.SelectionChanged += cmbSize_SelectionChanged;
        }

        private void cmbColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Color selectedColor = (Color)(cmbColors.SelectedItem as PropertyInfo).GetValue(null, null);
            this.main_tb.Foreground = new SolidColorBrush(selectedColor);
        }


        private void cmbSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // MessageBox.Show($"index: {cmbSize.SelectedIndex} value: {cmbSize.SelectedItem}");
            this.main_tb.FontSize = Convert.ToInt32(cmbSize.Items[cmbSize.SelectedIndex]);
        }


        private void bold_MouseEnter(object sender, MouseEventArgs e)
        {
           
        }

        private void italic_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }

        private void under_MouseEnter(object sender, MouseEventArgs e)
        {
           
        }

        private void clear_MouseEnter(object sender, MouseEventArgs e)
        {
           isBold = isItalic = isUnder = false;
        }

        private void bold_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!isBold)
            {
                this.main_tb.FontWeight = FontWeights.UltraBold;
                isBold = true;
            }
            else
            {
                this.main_tb.FontWeight = FontWeights.Normal;
                isBold = false;
            }
        }

        private void italic_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!isItalic)
            {
                this.main_tb.FontStyle = FontStyles.Italic;
                isItalic = true;
            }
            else
            {
                this.main_tb.FontStyle = FontStyles.Normal;
                isItalic = false;
            }
        }

        private void under_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!isUnder)
            {
                this.main_tb.TextDecorations = TextDecorations.Underline;
                isUnder = true;
            }
            else
            {
                this.main_tb.TextDecorations = null;
                isUnder = false;
            }
        }

        private void clear_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isBold = isItalic = isUnder = false;
            this.main_tb.FontWeight = FontWeights.Normal; 
            this.main_tb.TextDecorations = null;
            this.main_tb.FontStyle = FontStyles.Normal;
        }
    }
}
