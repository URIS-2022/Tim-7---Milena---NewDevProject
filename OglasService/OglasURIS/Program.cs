using Microsoft.EntityFrameworkCore;
using OglasURIS.Data;
using OglasURIS.Interfaces;
using OglasURIS.Repository;
using OglasURIS.ServiceCalls;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IOglasRepository, OglasRepository>();
builder.Services.AddScoped<ISluzbeniListRepository, SluzbeniListRepository>();
builder.Services.AddScoped<IJavnoNadmetanjeService , JavnoNadmetanjeService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
