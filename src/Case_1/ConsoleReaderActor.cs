using Akka.Actor;

namespace Case_1;

public class ConsoleReaderActor:UntypedActor
{
    private readonly IActorRef _consoleWriterActor;
    
    private const string ExistKey = "exist";

    public ConsoleReaderActor(IActorRef consoleWriterActor)
    {
        _consoleWriterActor = consoleWriterActor;
    }
    
    protected override void OnReceive(object message)
    {
        var readKey = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(readKey) && string.Equals(readKey, ExistKey, StringComparison.OrdinalIgnoreCase))
        {
            Context.System.Terminate();
        }
        
        _consoleWriterActor.Tell(readKey);
        
        Self.Tell("continue");
    }
    
}