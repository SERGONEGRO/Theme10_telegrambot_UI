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

namespace Example_1012
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Rect_MouseDown(object sender, MouseButtonEventArgs e)
        {
            rect.Fill = Brushes.Blue;
        }

        private void Rect_MouseUp(object sender, MouseButtonEventArgs e)
        {
            rect.Fill = Brushes.Yellow;
        }

        private void Rect_MouseEnter(object sender, MouseEventArgs e)
        {
            rect.Fill = Brushes.Black;
        }

        private void Rect_MouseLeave(object sender, MouseEventArgs e)
        {
            rect.Fill = Brushes.Aqua;
        }
    }
}
