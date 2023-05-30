using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
//using Telegram.Bots.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bots.Types;
using Microsoft.Extensions.Configuration;

namespace VoiceTexterBot
{
    internal class Program
    {
        private static TelegramBotClient client;
        static void Main(string[] args)
        {
            string stoken = "5902544993:AAHN-ewoeNEQWSiQuNM-5eAn_sDX62_6krg";

            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            Console.WriteLine("Hello, World!");
            client = new TelegramBotClient(stoken);
            Bot bot = new Bot(client);
            bot.StartAsync(token);
            Console.WriteLine("Нажмите любую кнопку для завершения: ");
            Console.ReadKey();
        }
    }


    internal class Bot : BackgroundService
    {
        private ITelegramBotClient _telegramClient;
        public static string scomm;
        public static bool btext;
        public long myChatID;

        public Bot(ITelegramBotClient telegramClient)
        {
            _telegramClient = telegramClient;
        }
 
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _telegramClient.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                new ReceiverOptions() { AllowedUpdates = { } }, // Здесь выбираем, какие обновления хотим получать. В данном случае разрешены все
                cancellationToken: stoppingToken);
 
            Console.WriteLine("Бот запущен");
            scomm = ""; btext = false;
        }
 
        async Task HandleUpdateAsync(ITelegramBotClient botClient, Telegram.Bot.Types.Update update, CancellationToken cancellationToken)
        {
            //  Обрабатываем нажатия на кнопки  из Telegram Bot API: https://core.telegram.org/bots/api#callbackquery
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.CallbackQuery)
            {
                string str = update.CallbackQuery.Data;
                switch (str)
                {
                    case "/length":
                        scomm = "/length";
                        btext = true;
                        await _telegramClient.SendTextMessageAsync(myChatID, "Введите текст", cancellationToken: cancellationToken);
                        break;
                    case "/summ":
                        scomm = "/summ";
                        btext = true;
                        await _telegramClient.SendTextMessageAsync(myChatID, "Введите числа", cancellationToken: cancellationToken);
                        break;
                    default:

                        break;
                }
                return;
            } else
 
            // Обрабатываем входящие сообщения из Telegram Bot API: https://core.telegram.org/bots/api#message
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                string str = update.Message.Text;
                Console.WriteLine(str);
                if (str.IndexOf("@") > 0)
                    str = str.Substring(0, str.IndexOf("@"));
                myChatID = update.Message.Chat.Id;
                switch (str)
                { 
                    case "/start":
                        await _telegramClient.SendTextMessageAsync(update.Message.Chat.Id, "Считать длину: /length \nНайти сумму: /summ", cancellationToken: cancellationToken);
                        scomm = ""; btext = false;
                        break;
                    case "/length":
                        scomm = "/length";
                        btext = true; 
                        await _telegramClient.SendTextMessageAsync(update.Message.Chat.Id, "Введите текст", cancellationToken: cancellationToken);
                        break;
                    case "/summ":
                        scomm = "/summ"; 
                        btext = true; 
                        await _telegramClient.SendTextMessageAsync(update.Message.Chat.Id, "Введите числа", cancellationToken: cancellationToken);
                        break;
                    case "/menu":
                        scomm = ""; btext = false;
                        var buttons = new List<InlineKeyboardButton[]>();
                        buttons.Add(new[]
                        {
                            InlineKeyboardButton.WithCallbackData($" Длина" , $"/length"),
                            InlineKeyboardButton.WithCallbackData($" Сумма" , $"/summ")
                        });

                        await _telegramClient.SendTextMessageAsync(update.Message.Chat.Id, "Меню", cancellationToken: cancellationToken, parseMode: Telegram.Bot.Types.Enums.ParseMode.Html, replyMarkup: new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup(buttons));
                        break;
                    default:
                        if (scomm == "/length" & btext==true)
                        {
                            string s = update.Message.Text;
                            await _telegramClient.SendTextMessageAsync(update.Message.Chat.Id, "Длина вашего сообщения: "+ s.Length,cancellationToken: cancellationToken);
                            scomm = ""; btext = false;
                        } else
                        if (scomm == "/summ" & btext == true)
                        {
                            string s = update.Message.Text;
                            int isumm = 0;
                            try
                            {
                                for (int i = 1; i < s.Length; i++) isumm = isumm + (int)s[i]-48;
                            } catch { }
                            await _telegramClient.SendTextMessageAsync(update.Message.Chat.Id, "Сумма ваших чисел: " + isumm, cancellationToken: cancellationToken);
                            scomm = ""; btext = false;
                        }
                        else
                        { 
                            await _telegramClient.SendTextMessageAsync(update.Message.Chat.Id, "Меню: /start или /menu", cancellationToken: cancellationToken);
                            scomm = "";btext = false;
                        }
                    break;
                }
                return;
            }
        }
 
        Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            // Задаем сообщение об ошибке в зависимости от того, какая именно ошибка произошла
            var errorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };
 
            // Выводим в консоль информацию об ошибке
            Console.WriteLine(errorMessage);
 
            // Задержка перед повторным подключением
            Console.WriteLine("Ожидаем 10 секунд перед повторным подключением.");
            Thread.Sleep(10000);
 
            return Task.CompletedTask;
        }
    }




}