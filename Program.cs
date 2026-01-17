using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

public class Program
{
    //dotnet run -- "C:\Users\Nikita\Documents\Doppelganger\токен бота.txt"(запуск в ручную)
    //args[0] = "C:\Users\Nikita\Documents\Doppelganger\токен бота.txt"
    public static async Task Main(string[] args )   
    {
        string filename = args[0]; //1
        string[] lines = File.ReadAllLines(filename); //2
        string token = lines[0]; //3
        TelegramBotClient client = new TelegramBotClient(token);
        client.StartReceiving/*начинаем получать обновления от телеграма*/(OnUpdate,OnError);
        Console.ReadLine(); // строка служит для того, что програма не зкарылась сразу после 12-16 строки
    }
    private static async Task OnError(ITelegramBotClient client, Exception exception, HandleErrorSource source, CancellationToken token)
    {
    }
    private static async Task OnUpdate(ITelegramBotClient client, Update update, CancellationToken token)
    {
        if(update.Type == UpdateType.Message)
        {
            if(update.Message.From.Id == 493229987)
            {   
                await /*дожидаемся выполнения запроса к телеграму*/ client.SetMessageReaction(493229987, update.Message.MessageId,[ new ReactionTypeEmoji { Emoji = "👍" }]);
            }
        }
    }
}
