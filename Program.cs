using Telegram.Bot;

public class Program
{
    public static async Task Main()
    {
        
        string[] lines = File.ReadAllLines("C:/Users/Nikita/Documents/Doppelganger/токен бота.txt");
        string token = lines[0];
        TelegramBotClient client = new TelegramBotClient(token);

        long chatId = 493229987;
        string text = "сука ебучая мошка блядь";
        await client.SendMessage(chatId, text);
    }
}
