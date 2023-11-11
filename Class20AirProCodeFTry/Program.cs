using Class20AirProCodeFTry.BokRepo;
using Class20AirProCodeFTry.FltRepo;
using Class20AirProCodeFTry.Models;
using Class20AirProCodeFTry.UsrRepo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<airLineDbContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));
builder.Services.AddTransient<IUsrRepo, UsrRepo>();
builder.Services.AddTransient<IFltRepo, FltRepo>();
builder.Services.AddTransient<IBokRepo, BokRepo>();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.UseCors("corsapp");

app.Run();
