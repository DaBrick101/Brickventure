using Brickventure_Library.Environment;
using Brickventure_Library.Partecipants;
using Brickventure_Library_0._1;
using Brickventure_Library_0._1.Commands;
using Brickventure_Library_0._1.Partecipants;
using Brickventure_Library_0._1.States;
using BrickventureWebAPI;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IWorld, World>();
builder.Services.AddSingleton<IPlayer, Player>();
builder.Services.AddSingleton<IController, KeyboardController>();
builder.Services.AddSingleton<IPlayerStateTimer, PlayerStateTimer>();
builder.Services.AddSingleton<IOutputMessageWriter, ApiOutputMessageWriter >();
builder.Services.AddSingleton< ICommand, MoveNorthCommand >() ;
builder.Services.AddSingleton<ICommand , MoveEastCommand >();
builder.Services.AddSingleton<ICommand, MoveSouthCommand>();
builder.Services.AddSingleton<ICommand, MoveWestCommand>();
builder.Services.AddSingleton<ICommand, AttackCommand>();
builder.Services.AddSingleton<ICommand, DefendCommand>();
builder.Services.AddSingleton<IInvoker, Invoker>();
builder.Services.AddSingleton<IPlayerStateTimer, PlayerStateTimer>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:7149", "http://localhost:4200");
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(MyAllowSpecificOrigins);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
