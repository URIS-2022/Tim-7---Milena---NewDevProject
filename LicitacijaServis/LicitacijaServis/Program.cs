using LicitacijaServis.Data;
using LicitacijaServis.Entities;
using LicitacijaServis.ServiceCalls;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ILicitacijaRepository, LicitacijaRepository>();
//builder.Services.AddSingleton<IJavnoNadmetanjeMockRepository,JavnoNadmetanjeMockRepository>();
builder.Services.AddScoped<IJavnoNadmetanjeService, JavnoNadmetanjeService>();
builder.Services.AddDbContext<LicitacijaContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddSwaggerGen(setup =>
{
    setup.SwaggerDoc("v1",
                   new OpenApiInfo()
                   {
                       Title = "Licitacija API",
                       Version = "v1",
                      
                       Description = "Pomocu ovog API-ja  se vrsi izvrsavanje svih CRUD operacija vezanih za licitaciju, kao i pracenje podataka o javnom nadmetanju date licitacije.",
                       Contact = new OpenApiContact
                       {
                           Name = "Irena Ijacic",
                           Email = "irenaijacic17@gmail.com",
                           Url = new Uri(builder.Configuration["Link:Ftn"])
                       },
                       License = new OpenApiLicense
                       {
                           Name = "FTN licence",
                           Url = new Uri(builder.Configuration["Link:Ftn"])
                       },
                   });

    //Pomocu refleksije dobijamo ime XML fajla sa komentarima (ovako smo ga nazvali u Project -> Properties)
    var xmlComments = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    //Pravimo putanju do XML fajla sa komentarima
    var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlComments);

    //Govorimo swagger-u gde se nalazi dati xml fajl sa komentarima
    setup.IncludeXmlComments(xmlCommentsPath);
});


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

