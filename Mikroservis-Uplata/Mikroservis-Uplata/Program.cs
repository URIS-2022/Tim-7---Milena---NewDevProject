using Microsoft.EntityFrameworkCore;
using Mikroservis_Uplata.Context;
using Mikroservis_Uplata.Repositories.KursRepository;
using Mikroservis_Uplata.Repositories.UplataRepository;
using Mikroservis_Uplata.ServiceCalls;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UrisDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IKursRepository, KursRepository>();
builder.Services.AddScoped<IUplataRepository, UplataRepository>();

builder.Services.AddScoped<IKupacService, KupacService>();
builder.Services.AddScoped<IJavnoNadmetanjeService, JavnoNadmetanjeService>();

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
