using Autofac;
using Autofac.Configuration;
using Xenopedia.Commons.Configuration.Autofac;

var builder = WebApplication.CreateBuilder(args);
AutofacConfiguration autofacConfig = new ();
var containerBuilder = new ContainerBuilder();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure Autofac
var module = autofacConfig.LoadModules();
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
