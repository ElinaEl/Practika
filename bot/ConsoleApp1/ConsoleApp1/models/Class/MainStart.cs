using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace ConsoleApp1.models.Class
{
    public class MainStart
    {
        private static ITelegramBotClient botClient;
        public  static void Start()
        {

            botClient = new TelegramBotClient("1427476211:AAGCLqT8YZq4Q8dIN95Mu4hDSJ6K4Jo8aNE") { Timeout = TimeSpan.FromSeconds(10) };

            var bot = botClient.GetMeAsync().Result;
            Console.WriteLine($"Работает! \nBot:{bot.Id}");

            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();

            Console.ReadKey();
            botClient.StopReceiving();
        }

        private async static void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            var text = e?.Message?.Text;
            if (text == null)
                return;

            try
            {
                var weatherText = Weather.Show_Api(text);
                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: $"Погода в {text}: \n{weatherText}\n\n" +
                          $"Введите другой город, если хотите узнать погоду в нем."
                    ).ConfigureAwait(false);
            }
            catch (Exception)
            {
                await botClient.SendTextMessageAsync(
            chatId: e.Message.Chat,
            text: "Напишите город в котором нужно узнать погоду"
            ).ConfigureAwait(false);
            }

        }
    }
}
