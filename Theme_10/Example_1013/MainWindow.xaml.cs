using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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

namespace Example_1013
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

        private void TxtNo_MouseEnter(object sender, MouseEventArgs e)
        {
            var posLeftTxtYes = Canvas.GetLeft(txtYes);
            var posLeftTxtNo = Canvas.GetLeft(txtNo);

            Canvas.SetLeft(txtYes, posLeftTxtNo);
            Canvas.SetLeft(txtNo, posLeftTxtYes);

            SystemSounds.Hand.Play();
        }

        private void TxtYes_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show($"Я в этом и не сомневался :)");
        }
    }
}
