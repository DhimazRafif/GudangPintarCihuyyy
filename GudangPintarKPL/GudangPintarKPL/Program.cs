using GudangPintar.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<StockService>();
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<HistoryService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

// jalanin API async
var api = app.RunAsync();

// jalanin console
var console = new ConsoleApp(
    app.Services.GetRequiredService<StockService>(),
    app.Services.GetRequiredService<UserService>(),
    app.Services.GetRequiredService<HistoryService>()
);

console.Run();

await api;