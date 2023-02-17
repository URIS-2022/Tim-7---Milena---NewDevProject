using KupacServis.Data;
using KupacServis.Data.MockRepository;
using KupacServis.Entities;
using KupacServis.ServiceCalls;
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
builder.Services.AddScoped<IPrioritetRepository, PrioritetRepository>();
builder.Services.AddScoped<IFizickoLiceRepository, FizickoLiceRepository>();
builder.Services.AddScoped<IKupacRepository, KupacRepository>();
builder.Services.AddScoped<IPravnoLiceRepository, PravnoLiceRepository>();
//builder.Services.AddSingleton<IJavnoNadmetanjeRepository, JavnoNadmetanjeRepository>();
//builder.Services.AddSingleton<IUplataRepository, UplataRepository>();
//builder.Services.AddSingleton<IAdresaRepository, AdresaRepository>();
builder.Services.AddScoped<IOvlascenoLiceRepository, OvlascenoLiceRepository>();
builder.Services.AddScoped<IAdresaService, AdresaService>();
builder.Services.AddScoped<IDrzavaService, DrzavaService>();
builder.Services.AddScoped<IJavnoNadmetanjeService, JavnoNadmetanjeService>();
builder.Services.AddScoped<IUplataService, UplataService>();
builder.Services.AddSwaggerGen(setup =>
{
    setup.SwaggerDoc("v1",
                   new OpenApiInfo()
                   {
                       Title = "Kupac API",
                       Version = "v1",
                       //Èesto treba da dodamo neke dodatne informacije
                       Description = "Pomocu ovog API-ja  se vrsi izvrsavanje svih CRUD operacija vezanih za kupca, koji je pravno ili fizicko lice, zatim prioriteta datog kupca kao i koja ovlasena lica ga zastupaju, ako ona postoje.",
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


builder.Services.AddDbContext<KupacContext>(options => {
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
