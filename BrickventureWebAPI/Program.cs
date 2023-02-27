using Brickventure_Library.Environment;
using Brickventure_Library.Partecipants;
using Brickventure_Library_0._1;
using Brickventure_Library_0._1.Partecipants;
using Brickventure_Library_0._1.States;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IWorld, World>();
builder.Services.AddSingleton<IPlayer, Player>();
builder.Services.AddSingleton<IPlayerStateTimer, PlayerStateTimer>();
builder.Services.AddSingleton<IOutputMessageWriter, APIOutputMessageWriter >();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
