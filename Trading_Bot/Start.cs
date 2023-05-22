using AuthenticationService.Helper;
using AuthenticationService.Modells;
using AuthenticationService.Services;
using DataBase.DataContext;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Configuration.AddJsonFile("C:\\Users\\aco podgorac\\source\\repos\\Trading_Bot\\DataBase\\appsettings.json");
builder.Configuration.AddJsonFile("C:\\Users\\Aleksander\\source\\repos\\Trading_Bot-2.0\\DataBase\\appsettings.json");

builder.Services.AddDbContext<DataBaseContext>(
          o => o.UseNpgsql(builder.Configuration.GetConnectionString("TradingDataBaseExterned")));


builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IPaswordService, PasswordService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

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

