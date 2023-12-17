
using Akka.Actor;
using Akka.Actor.Dsl;
using Case_1;

public class Program
{
    public static ActorSystem MyActorSystem;

    
    public static void Main(string[] args)
    {
        // make an actor system 
        MyActorSystem = ActorSystem.Create("MyActorSystem");

        PrintInstructions();

        IActorRef consoleWriteActor =
            MyActorSystem.ActorOf(Props.Create(() => new ConsoleWriterActor()), "ConsoleWriterActor");

        IActorRef consoleReadActor = MyActorSystem.ActorOf(Props.Create(() => new ConsoleReaderActor(consoleWriteActor)), "ConsoleReaderActor");
        
        consoleReadActor.Tell("start");
        
        MyActorSystem.WhenTerminated.Wait();
    }
    
    private static void PrintInstructions()
    {
        Console.WriteLine("Write whatever you want into the console!");
        Console.Write("Some lines will appear as");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write(" red ");
        Console.ResetColor();
        Console.Write(" and others will appear as");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(" green! ");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Type 'exit' to quit this application at any time.\n");
    }
}