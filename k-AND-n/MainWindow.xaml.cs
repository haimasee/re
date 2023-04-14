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

namespace k_AND_n
{
    public partial class MainWindow : Window
    {
        public static int a = 1;
        public MainWindow()
        {
            InitializeComponent();
            Background = new ImageBrush(new BitmapImage(new Uri("https://i.pinimg.com/564x/be/e8/3c/bee83c425ff2c8b0946802e6dbaca60a.jpg", UriKind.RelativeOrAbsolute)));
            Button[] k = { b1, b2, b3, b4, b5, b6, b7, b8, b9 };
            foreach (Button button in k)
            {
                button.IsEnabled = false;
            }
            kr.IsEnabled = false;
            no.IsEnabled = false;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button[] k = { b1, b2, b3, b4, b5, b6, b7, b8, b9 };
            bool wi;
            string hod;
            if (kr.IsChecked == true)
            {
                hod = "o ";
                wi = hod_player(sender, e);
                if (wi == false)
                    wi = seee(k);
                if (wi == true)
                    itog("player", k);
                if (wi != true)
                {
                    wi = hod_bot(k, hod);
                    if (wi == false)
                        wi = seee(k);
                    if (wi == true)
                        itog("bot", k);
                }
            }
            else if (no.IsChecked == true)
            {
                hod = "x ";
                wi = hod_player(sender, e);
                if (wi == false)
                    wi = seee(k);
                if (wi == true)
                    itog("Игрок", k);
                if (wi != true)
                {
                    wi = hod_bot(k, hod);
                    if (wi == false)
                        wi = seee(k);
                    if (wi == true)
                        itog("Робот", k);
                }
            }


        }
        private void start(object sender, RoutedEventArgs e)
        {
            Button[] k = { b1, b2, b3, b4, b5, b6, b7, b8, b9 };
            foreach (Button b in k)
            {
                b.IsEnabled = true;
            }
            starts.IsEnabled = false;
            if (a == 1)
            {
                kr.IsChecked = true;
            }
            else if (a == 2)
            {
                no.IsChecked = true;
                hod_bot(k, "x ");
            }
        }
        private bool hod_bot(Button[] x, string hod)
        {
            while (true)
            {
                Random y = new Random();
                int a = y.Next(9);
                if (x[a].Content != "x " && x[a].Content != "o ")
                {
                    x[a].Content = hod;
                    x[a].IsEnabled = false;
                    break;
                }
            }
            return win("o ");
        }
        private bool hod_player(object sender, RoutedEventArgs e)
        {
            if (a == 1)
                (sender as Button).Content = "x ";
            else if (a == 2)
                (sender as Button).Content = "o ";
            (sender as Button).IsEnabled = false;
            return win((string)(sender as Button).Content);
        }
        private bool win(string hod)
        {
            bool w = false;
            if (b1.Content == hod && b2.Content == hod && b3.Content == hod)
                w = true;
            else if (b1.Content == hod && b5.Content == hod && b9.Content == hod)
                w = true;
            else if (b1.Content == hod && b4.Content == hod && b7.Content == hod)
                w = true;
            else if (b2.Content == hod && b5.Content == hod && b8.Content == hod)
                w = true;
            else if (b3.Content == hod && b6.Content == hod && b9.Content == hod)
                w = true;
            else if (b4.Content == hod && b5.Content == hod && b6.Content == hod)
                w = true;
            else if (b7.Content == hod && b8.Content == hod && b9.Content == hod)
                w = true;
            else if (b3.Content == hod && b5.Content == hod && b7.Content == hod)
                w = true;
            return w;
        }
        private void itog(string name, Button[] x)
        {
            if (name == "Ничья")
                MessageBox.Show("Ничья!");
            else if (name != "")
                MessageBox.Show($"{name} победил!");
            foreach (Button b in x)
            {
                b.IsEnabled = false;
                b.Content = "";
            }
            if (a == 1)
                a = 2;
            else if (a == 2)
                a = 1;
            starts.IsEnabled = true;
        }
        private bool seee(Button[] x)
        {
            bool hh = false;
            foreach (Button b in x)
            {
                if (b.Content != "x " && b.Content != "o ")
                {
                    hh = false;
                    break;
                }
                else
                {
                    hh = true;
                }
            }
            if (hh == true)
                itog("Ничья", x);
            return hh;
        }
    }
}