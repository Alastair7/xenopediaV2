using Autofac;
using Autofac.Configuration;
using Autofac.Extensions.DependencyInjection;
using System.Reflection;
using Xenopedia.Service.Autofac;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configure Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder => { builder.RegisterModule(new AutofacModule()); });
builder.Configuration.AddEnvironmentVariables()
                     .AddUserSecrets(Assembly.GetExecutingAssembly(), true);
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

app.UseCors(_ => _.AllowAnyHeader()
.AllowAnyMethod()
.WithOrigins("http://localhost:3000"));

app.UseAuthorization();

app.MapControllers();

app.Run();
