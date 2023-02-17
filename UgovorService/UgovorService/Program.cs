using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using UgovorService.Entities;
using UgovorService.Repositories;
using UgovorService.ServiceCalls;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IDokumentRepository, DokumentRepository>();
builder.Services.AddScoped<ITipGarancijeRepository, TipGarancijeRepository>();
builder.Services.AddScoped<IUgovorRepository, UgovorRepository>();
builder.Services.AddScoped<IKupacService, KupacService>();
builder.Services.AddScoped<IJavnoNadmetanjeService, JavnoNadmetanjeService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.SwaggerDoc("v1",
                   new OpenApiInfo()
                   {
                       Title = "Ugovor API",
                       Version = "v1",
                       Description = "Pomocu ovog API-ja moze da se vrsi dodavanje dokumenata,ugovora i tipova garancija, njihovo azuriranje i brisanje.",
                       Contact = new OpenApiContact
                       {
                           Name = "Enio Kurtesi",
                           Email = "enio.estiem@gmail.com",
                           //Url = new Uri("http://www.ftn.uns.ac.rs/")
                       },
                       License = new OpenApiLicense
                       {
                           Name = "FTN licence",
                           //Url = new Uri("http://www.ftn.uns.ac.rs/")
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
