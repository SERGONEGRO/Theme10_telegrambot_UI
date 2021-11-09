using Newtonsoft.Json.Linq;
using System;

namespace Theme10_TelegramBot_UI
{
    struct MessageLog
    {
        public string Time { get; set; }

        public long Id { get; set; }

        public string Msg { get; set; }

        public string FirstName { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Time"></param>
        /// <param name="Msg"></param>
        /// <param name="FirstName"></param>
        /// <param name="Id"></param>
        public MessageLog(string Time, string Msg, string FirstName, long Id)
        {
            this.Time = Time;
            this.Msg = Msg;
            this.FirstName = FirstName;
            this.Id = Id;
        }

        /// <summary>
        /// Выгрузка лога сообщений в JSON
        /// </summary>
        /// <returns></returns>
        internal JObject SerializeMessageLogToJson()
        {
            JObject jMessageLog = new JObject
            {
                ["ID"] = this.Id,
                ["TIME"] = this.Time,
                ["NAME"] = this.FirstName,
                ["MESSAGE"] = this.Msg
            };
            return jMessageLog;
        }
    }
}
