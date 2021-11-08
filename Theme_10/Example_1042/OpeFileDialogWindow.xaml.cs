using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Theme10_TelegramBot_UI
{
    /// <summary>
    /// Логика взаимодействия для OpeFileDialogWindow.xaml
    /// </summary>
    public partial class OpenFileDialogWindow : Window
    {
        string token = string.Empty;
        public OpenFileDialogWindow()
        {
            InitializeComponent();
        }
        
        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)                 //если выбран файл
                token = File.ReadAllText(openFileDialog.FileName);
            MainWindow mw = new MainWindow(token);                   //главному окну передается токен
            mw.Show();
            this.Close();
        }

    }
}
