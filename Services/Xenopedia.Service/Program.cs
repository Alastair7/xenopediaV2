using Autofac;
using Autofac.Configuration;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder();
var containerBuilder = new ContainerBuilder();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure Autofac
config.AddJsonFile("Config/autofac.json");
var module = new ConfigurationModule(config.Build());
containerBuilder.RegisterModule(module);

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
