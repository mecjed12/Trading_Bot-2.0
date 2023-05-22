using DataBase.DataContext;
using MarketDataService.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Configuration.AddJsonFile("C:\\Users\\aco podgorac\\source\\repos\\Trading_Bot\\DataBase\\appsettings.json");
//builder.Configuration.AddJsonFile("C:\\Users\\Aleksander\\source\\repos\\Trading_Bot-2.0\\DataBase\\appsettings.json");

builder.Services.AddDbContext<DataBaseContext>(
          o => o.UseNpgsql(builder.Configuration.GetConnectionString("TradingDataBase")));

builder.Services.AddScoped<IHistoricalDataService, HistoricalDataService>();
builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<ITradingPairDataServicecs, TradingPairDataService>();
builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
