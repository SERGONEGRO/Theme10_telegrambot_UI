using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using System.Windows;

namespace Example_1042
{

    class TelegramMessageClient
    {
        private MainWindow w;
        static TelegramBotClient bot;
        public ObservableCollection<MessageLog> BotMessageLog { get; set; }
        static string path = @"D:\\bot\";
        static DirectoryInfo directoryInfo = new DirectoryInfo(path);
        static bool flag = false;   //flag = true, если ожидается ответ пользователя

        //string tokentg = System.IO.File.ReadAllText(@"D:\programms\Яндекс диск\Синхронизация\YandexDisk\token1.txt");
        // string tokentg = System.IO.File.ReadAllText(@"C:\Users\User\YandexDisk\token1.txt");

        private void MessageListener(object sender, MessageEventArgs e)
        {
            var message = e.Message;                                             //полученное сообщение
            string name = $"{message.From.FirstName} {message.From.LastName}";   //имя собеседника

            string text = $"{DateTime.Now.ToLongTimeString()}: {name} {message.Chat.Id} {message.Text}";

            Debug.WriteLine($"{text} TypeMessage: {message.Type.ToString()}");

            if (message.Text == null) return;

            var messageText = message.Text;

            w.Dispatcher.Invoke(() =>
            {
                BotMessageLog.Add(
                new MessageLog(
                    DateTime.Now.ToLongTimeString(), messageText, message.Chat.FirstName, message.Chat.Id));
            });
        }

        public TelegramMessageClient(MainWindow W, string PathToken = @"C:\Users\User\YandexDisk\token1.txt")
        {
            this.BotMessageLog = new ObservableCollection<MessageLog>();
            this.w = W;

            bot = new TelegramBotClient(File.ReadAllText(PathToken));
            var me = bot.GetMeAsync().Result;
            w.Title = me.ToString();
            bot.OnMessage += MessageListener;
            bot.OnCallbackQuery += BotOnCallbackQueryReceived;    //обработка кнопок

            bot.StartReceiving();
        }

        public void SendMessage(string Text, string Id)
        {
            long id = Convert.ToInt64(Id);
            bot.SendTextMessageAsync(id, Text);
        }

        /// <summary>
        /// обработка кнопок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static async void BotOnCallbackQueryReceived(object sender, CallbackQueryEventArgs e)   //test
        {
            string buttonText = e.CallbackQuery.Data;
            string name = $"{e.CallbackQuery.From.FirstName} {e.CallbackQuery.From.LastName}";
            //Console.WriteLine($"{name} нажал кнопку {buttonText}");
            await bot.AnswerCallbackQueryAsync(e.CallbackQuery.Id, $"Вы нажали кнопку {buttonText}");
        }
    }
}
