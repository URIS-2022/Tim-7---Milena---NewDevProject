using Microsoft.EntityFrameworkCore;
using Uris.Context;
using Uris.Repositories.KatastarskaOpstinaRepository;
using Uris.Repositories.KulturaRepository;
using Uris.Repositories.KvalitetZemljistaRepository;
using Uris.Repositories.ParcelaRepository;
using Uris.ServiceCalls;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(setup =>
                setup.ReturnHttpNotAcceptable = true
            ).AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UrisDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); 
builder.Services.AddScoped<IKulturaRepository, KulturaRepository>();  
builder.Services.AddScoped<IKvalitetZemljistaRepository, KvalitetZemljistaRepository>();  
builder.Services.AddScoped<IKatastarskaOpstinaRepository, KatastarskaOpstinaRepository>();  
builder.Services.AddScoped<IParcelaRepository, ParcelaRepository>();

builder.Services.AddScoped<IKupacService, KupacService>();

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
