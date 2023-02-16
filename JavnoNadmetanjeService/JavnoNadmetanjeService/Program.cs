using JavnoNadmetanjeService.Entities;
using JavnoNadmetanjeService.Repository;
using JavnoNadmetanjeService.ServiceCalls;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddXmlDataContractSerializerFormatters() 
            .ConfigureApiBehaviorOptions(setupAction => 
            {
                setupAction.InvalidModelStateResponseFactory = context =>
                {
                    //Kreiramo problem details objekat
                    ProblemDetailsFactory problemDetailsFactory = context.HttpContext.RequestServices
                        .GetRequiredService<ProblemDetailsFactory>();

                    //Prosleðujemo trenutni kontekst i ModelState, ovo prevodi validacione greške iz ModelState-a u RFC format
                    ValidationProblemDetails problemDetails = problemDetailsFactory.CreateValidationProblemDetails(
                        context.HttpContext,
                        context.ModelState);

                    //Ubacujemo dodatne podatke
                    problemDetails.Detail = "Pogledajte polje errors za detalje.";
                    problemDetails.Instance = context.HttpContext.Request.Path;

                    //po defaultu se sve vraæa kao status 400 BadRequest, to je ok kada nisu u pitanju validacione greške,
                    //ako jesu hoæemo da koristimo status 422 UnprocessibleEntity
                    //tražimo info koji status kod da koristimo
                    var actionExecutiongContext = context as ActionExecutingContext;

                    //proveravamo da li postoji neka greška u ModelState-u, a takoðe proveravamo da li su svi prosleðeni parametri dobro parsirani
                    //ako je sve ok parsirano ali postoje greške u validaciji hoæemo da vratimo status 422
                    if ((context.ModelState.ErrorCount > 0) &&
                        (actionExecutiongContext?.ActionArguments.Count == context.ActionDescriptor.Parameters.Count))
                    {
                        problemDetails.Status = StatusCodes.Status422UnprocessableEntity;
                        problemDetails.Title = "Došlo je do greške prilikom validacije.";

                        //sve vraæamo kao UnprocessibleEntity objekat
                        return new UnprocessableEntityObjectResult(problemDetails)
                        {
                            ContentTypes = { "application/problem+json" }
                        };
                    };

                    //ukoliko postoji nešto što nije moglo da se parsira hoæemo da vraæamo status 400 
                    problemDetails.Status = StatusCodes.Status400BadRequest;
                    problemDetails.Title = "Došlo je do greške prilikom parsiranja poslatog sadržaja.";
                    return new BadRequestObjectResult(problemDetails)
                    {
                        ContentTypes = { "application/problem+json" }
                    };
                };
            });
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ITipJavnogNadmetanjaRepository, TipJavnogNadmetanjaRepository>();
builder.Services.AddScoped<IStatusJavnogNadmetanjaRepository, StatusJavnogNadmetanjaRepository>();
builder.Services.AddScoped<IJavnoNadmetanjeRepository, JavnoNadmetanjeRepository>();
builder.Services.AddScoped<IAdresaService, AdresaService>();
builder.Services.AddScoped<IKupacService, KupacService>();
builder.Services.AddScoped<IParcelaService, ParcelaService>();
builder.Services.AddScoped<IOvlascenoLiceService, OvlascenoLiceService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.SwaggerDoc("v1",
                   new OpenApiInfo()
                   {
                       Title = "Javno nadmetanje API",
                       Version = "v1",
                       //Èesto treba da dodamo neke dodatne informacije
                       Description = "Pomoæu ovog API-ja može da se vrši dodavanje kako javnog nadmetanja,tako statusa i tipa,ažuriranje prethodno dodatih javnih nadmetanja,statusa i tipova,pregled i brisanje.",
                       Contact = new OpenApiContact
                       {
                           Name = "Saša Iliæ",
                           Email = "ilic.sasa2001@gmail.com",
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
