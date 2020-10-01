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

        private static string all_result { get; set; } = "";
        private static string current_number { get; set; } = "";
        private Random rnd { get; set; } = new Random();
        private static bool IsFinished { get; set; } = false;
        private List<string> actionSymbol { get; set; } = new List<string>()
            { "+", "-", "/", "*" };
        private List<string> resSymbol { get; set; } = new List<string>()
        {"CE", "C", "=", "<", "."};
        public static Calc hwid = new Calc();
        public Calc()
        {
            InitializeComponent();
            hwid = (hwid != null) ? hwid : this;
        }

        private void back_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.hwid.KeyDown += null;
            MainWindow.hwid.MainBoard.Children.Add(Menu.hwid);
            MainWindow.hwid.MainBoard.Children.Remove(this);
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (IsFinished)
            {
                Action.Text = null;
                IsFinished = false;
            }

            Button temp = (Button)sender;
            if (actionSymbol.Contains(temp.Content))
            {
                if (Number.Text.Length == 0) return;
                Action.Text += Number.Text + " " + temp.Content + " ";
                Number.Text = null;
            }
            else if (resSymbol.Contains(temp.Content))
            {
                switch (temp.Content)
                {
                    case "CE":
                        Number.Text = null;
                        break;
                    case "C":
                        Number.Text = null;
                        Action.Text = null;
                        break;
                    case "<":
                        if (Number.Text.Length > 0)
                            Number.Text = Number.Text.Remove(Number.Text.Length - 1, 1);
                        break;
                    case ".":
                        if (Number.Text.Length == 0) return;
                        Number.Text += ",";
                        break;
                    case "=":
                        if (Number.Text.Length > 0)
                        {
                            if (resSymbol.Contains(Number.Text)) return;
                            if (Number.Text.Length == 2 && Number.Text[0] == '0') return;
                            if (Number.Text[Number.Text.Length - 1] == ',') return;
                            Action.Text += Number.Text;
                            Number.Text = null;
                        }
                        if (Action.Text.Length == 0) return;
                        if (Action.Text[Action.Text.Length - 1] == ' ') Action.Text = Action.Text.Remove(Action.Text.Length - 3, 3);

                        string[] buffer = Action.Text.Split(' ');
                        List<double> numbers = new List<double>();
                        List<char> actions = new List<char>();

                        foreach (var item in buffer)
                        {
                            double num;
                            char act;

                            if (double.TryParse(item, out num))
                            {
                                numbers.Add(num);
                            }
                            else if (char.TryParse(item, out act))
                            {
                                actions.Add(act);
                            }

                        }

                        if (actions.Count == 0)
                        {
                            IsFinished = true;
                            return;
                        }

                        try
                        {
                            int i = 0;
                            int j = 0;

                            while (actions.Count > 0 && j != actions.Count)
                            {

                                if (actions[i] == '+' || actions[i] == '-') j++;
                                else
                                {
                                    if (numbers[i + 1] == 0 && actions[i] == '/')
                                    {
                                        Action.Text = null;
                                        Number.Text = "Subtract by zero...";
                                        IsFinished = true;
                                        return;
                                    }
                                    double res = MakeMath(numbers[i], numbers[i + 1], actions[i]);

                                    actions.RemoveAt(i);
                                    numbers.RemoveAt(i + 1);
                                    numbers[i] = res;
                                }
                                i++;
                            }

                            i = 0;

                            while (actions.Count > 0)
                            {
                                if (numbers[i + 1] == 0 && actions[i] == '/')
                                {
                                    Action.Text = null;
                                    Number.Text = "Subtract by zero...";
                                    IsFinished = true;
                                    return;
                                }
                                double res = MakeMath(numbers[i], numbers[i + 1], actions[i]);

                                actions.RemoveAt(i);
                                numbers.RemoveAt(i + 1);
                                numbers[i] = res;
                                i++;
                            }
                        }
                        catch { }

                        Action.Text = numbers[0].ToString();
                        IsFinished = true;
                        break;
                }
            }
            else
            {
                if (Number.Text.Length == 1 && Number.Text[0] == '0') return;
                Number.Text += temp.Content;
            }
        }

        private double MakeMath(double a, double b, char action)
        {
            switch (action)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    return a / b;
            }
            return 0;
        }

    }

}
