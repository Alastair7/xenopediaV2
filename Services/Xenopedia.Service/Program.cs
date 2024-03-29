using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using Xenopedia.Service.Autofac;
using Xenopedia.Service.Startup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configure Autofac
builder.Host.UseServiceProviderFactory(
    new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder => { builder.RegisterModule(new AutofacModule()); });

builder.Host.ConfigureAppSettings();

// Configure Security
builder.Configuration.AddEnvironmentVariables()
                     .AddUserSecrets(Assembly.GetExecutingAssembly(), true);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => 
    {
        options.Authority = "https://securetoken.google.com/PROJECT-ID";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "https://securetoken.google.com/PROJECT-ID",
            ValidateAudience = true,
            ValidAudience = "PROJECT-ID",
            ValidateLifetime = true,
        };
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//app.UseJwtMiddleware();
// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseCors(_ => _.AllowAnyHeader()
.AllowAnyMethod()
.WithOrigins("http://localhost:3000"));

app.UseAuthorization();

app.MapControllers();

app.Run();
