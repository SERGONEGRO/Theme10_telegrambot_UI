using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace Theme10_TelegramBot_UI
{

    class TelegramMessageClient
    {
        private MainWindow w;
        static TelegramBotClient bot;
        public ObservableCollection<MessageLog> BotMessageLog { get; set; }
        static string path = @"D:\\bot\";
        static DirectoryInfo directoryInfo = new DirectoryInfo(path);
        //static bool flag = false;   //flag = true, если ожидается ответ пользователя

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

        public TelegramMessageClient(MainWindow W, string pathToken) 
        {
            this.BotMessageLog = new ObservableCollection<MessageLog>();
            this.w = W;
            string tokentg = pathToken;
            bot = new TelegramBotClient(pathToken);
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
            await bot.AnswerCallbackQueryAsync(e.CallbackQuery.Id, $"Вы нажали кнопку {buttonText}");
        }
    }
}
