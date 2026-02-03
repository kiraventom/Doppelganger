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
        string filename = args[0]; 
        string[] lines = File.ReadAllLines(filename); 
        string token1 = lines[0];
        string token2 = lines[1]; 
        TelegramBotClient client1 = new TelegramBotClient(token1);
        TelegramBotClient client2 = new TelegramBotClient(token2);
        client1.StartReceiving/*начинаем получать обновления от телеграма*/(OnUpdate,OnError);
        client2.StartReceiving(OnUpdate,OnError);
        Console.ReadLine(); // строка служит для того, что програма не зкарылась сразу после 12-19 строки
    }
    private static async Task OnError(ITelegramBotClient client, Exception exception, HandleErrorSource source, CancellationToken token)
    {
        Console.WriteLine(exception/*исключение*/.Message);
    }
    private static async Task OnUpdate(ITelegramBotClient client, Update update, CancellationToken token)
    {
        if(update.Type == UpdateType.Message)
        {
            if(update.Message.From.Id == 493229987)
            {   
                if(update.Message.Text.Contains("Добро") || update.Message.Text.Contains("добро"))// TODO
                {
                    await client.SetMessageReaction(update.Message.Chat.Id, update.Message.MessageId,[ new ReactionTypeEmoji { Emoji = "🤝" }]);
                }
                else
                {
                    await /*дожидаемся выполнения запроса к телеграму*/ client.SetMessageReaction(update.Message.Chat.Id, update.Message.MessageId,[ new ReactionTypeEmoji { Emoji = "👍" }]);
                }   
            }
        }
        else if(update.Type == UpdateType.MessageReaction)
        {
            if(update.MessageReaction.User.Id == 493229987)
            {
                if (update.MessageReaction.NewReaction.Count() == 0)//количество новых реакций 
                {
                    await client.SetMessageReaction(update.MessageReaction.Chat.Id, update.MessageReaction.MessageId,[]);
                }
                else
                {
                    var reaction = update.MessageReaction.NewReaction[0];
                    if (reaction is /*является*/ ReactionTypeEmoji reactionEmoji)
                    {
                        await client.SetMessageReaction(update.MessageReaction.Chat.Id, update.MessageReaction.MessageId,[reactionEmoji]);
                    }
                    else if (reaction is ReactionTypeCustomEmoji reactionEmoji1)
                    {
                        await client.SetMessageReaction(update.MessageReaction.Chat.Id, update.MessageReaction.MessageId,[reactionEmoji1]);
                    }
                }    
            }
        }
    }
}
