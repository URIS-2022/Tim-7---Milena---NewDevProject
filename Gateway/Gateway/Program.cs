using Gateway.ServiceCalls.Implementations;
using Gateway.ServiceCalls.Interfaces;
using Gateway.Helpers;
using Microsoft.OpenApi.Models;
using Gateway.Logger;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IAuthHelper, AuthHelper>();
builder.Services.AddScoped<IKorisnikService, KorisnikService>();
builder.Services.AddScoped<ILoggerService, LoggerService>();
builder.Services.AddScoped(typeof(IServiceCall<,>), typeof(ServiceCall<,>));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Gateway API",
        Description = "Mikroservis za rutiranje zahteva i autorizaciju"
    });

    var xmlComments = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlComments);
    options.IncludeXmlComments(xmlCommentsPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
