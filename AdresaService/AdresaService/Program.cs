using AdresaService.Entities;
using AdresaService.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IDrzavaRepository, DrzavaRepository>();
builder.Services.AddScoped<IAdresaRepository, AdresaRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.SwaggerDoc("v1",
                   new OpenApiInfo()
                   {
                       Title = "Adresa API",
                       Version = "v1",
                       Description = "Pomocu ovog API-ja moze da se vrsi dodavanje adrese i drzave, njihovo azuriranje i brisanje.",
                       Contact = new OpenApiContact
                       {
                           Name = "Enio Kurtesi",
                           Email = "enio.estiem@gmail.com",
                           Url = new Uri("http://www.ftn.uns.ac.rs/")
                       },
                       License = new OpenApiLicense
                       {
                           Name = "FTN licence",
                           Url = new Uri("http://www.ftn.uns.ac.rs/")
                       },
                   });
    var xmlComments = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    //Pravimo putanju do XML fajla sa komentarima
    var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlComments);

    //Govorimo swagger-u gde se nalazi dati xml fajl sa komentarima
    setupAction.IncludeXmlComments(xmlCommentsPath);
});

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
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
