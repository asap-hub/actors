using Akka.Actor;

namespace Case_1;

public class ConsoleWriterActor:UntypedActor
{
    protected override void OnReceive(object message)
    {
        var msg = message as string;

        if (string.IsNullOrWhiteSpace(msg))
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("please provide input. \n");
            Console.ResetColor();
        }

        var even = msg.Length % 2 == 0;
        var color = even
            ? ConsoleColor.Yellow
            : ConsoleColor.Blue;
        var alert = even ? "Your string had an even # of characters.\n" : "Your string had an odd # of characters.\n";
        
        Console.WriteLine(alert);
        Console.ForegroundColor = color;
        Console.ResetColor();
    }
}