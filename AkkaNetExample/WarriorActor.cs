using Akka.Actor;

namespace AkkaNetExample;

public class WarriorActor : ReceiveActor
{
    public WarriorActor()
    {
        Receive<Warrior>(warrior => Console.WriteLine($"Warrior: {warrior.Name}. HP left: {warrior.HP}. {warrior.Name} attacks."));
    }

    protected override void PreStart() => Console.WriteLine("Warrior selected");

    protected override void PostStop() => Console.WriteLine("Warrior turn finished");
}
