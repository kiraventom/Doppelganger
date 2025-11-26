using Telegram.Bot;

public class Program
{
    public static async void Main(string[] args)
    {
        string token = "8535580400:AAHnZBXUIQMmNyvyOua10FIrEI1syIE0uHo";
        TelegramBotClient client = new TelegramBotClient(token);

        long chatId = 493229987;
        string text = "сука ебучая мошка блядь";
        await client.SendMessage(chatId, text);
    }
}
