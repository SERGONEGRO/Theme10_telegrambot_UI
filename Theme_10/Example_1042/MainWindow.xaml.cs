using System;
using System.Collections.Generic;
using System.IO;
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
using Newtonsoft.Json.Linq;

namespace Example_1042
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TelegramMessageClient client;

        public MainWindow()
        {
            InitializeComponent();

            client = new TelegramMessageClient(this);

            logList.ItemsSource = client.BotMessageLog; //client.BotMessageLog;
        }

        private void btnMsgSendClick(object sender, RoutedEventArgs e)
        {
            client.SendMessage(txtMsgSend.Text, TargetSend.Text);
            txtMsgSend.Text = null;
        }

        private void btnSaveToJsonClick(object sender, RoutedEventArgs e)
        {
            JObject mainTree = new JObject();
            JArray jArray = new JArray();

            mainTree["MessageLog"] = "MessageLog_" + DateTime.Now.ToString();
            mainTree["Messages"] = jArray;

            foreach (var m in client.BotMessageLog)
            {
                JObject obj = m.SerializeMessageLogToJson();
                jArray.Add(obj);
            }
            string json = mainTree.ToString();
            string fileName = "MessageLog.json";
            File.WriteAllText(fileName, json);

            MessageBox.Show($"Экспорт завершен в {fileName}", "Результат:", MessageBoxButton.OK);
        }
    }
}
