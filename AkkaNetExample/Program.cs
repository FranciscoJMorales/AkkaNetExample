using Akka.Actor;
using AkkaNetExample;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/warrior", () =>
{
    // Create actors system
    var system = ActorSystem.Create("battlefield");
    var warriorActor = system.ActorOf<WarriorActor>("warrior");

    var chrom = new Warrior("Chrom", 44);

    // Send a message to the actor
    warriorActor.Tell(chrom);

    // Stop actor
    Thread.Sleep(5000);
    system.Stop(warriorActor);

    return Results.Ok(chrom);
});

app.Run();
