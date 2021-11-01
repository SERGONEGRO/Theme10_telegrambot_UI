using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Example_1034
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ObservableCollection<Worker> db = new ObservableCollection<Worker>();

        public MainWindow()
        {
            InitializeComponent();
            listDbBView.ItemsSource = db;
        }

        int c = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db.Add(new Worker() {
                Name = $"Имя {++c}",
                Age = 20 + c,
                Salary = 1000 * c
            });

            this.Title = $"db.Count = {db.Count}";
            //listDbBView.Items.Refresh();

        }
    }
}
