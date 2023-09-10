using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Helpers;
using MoviesAPI.Services.Classes;
using MoviesAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// --------------------- Configurando AutoMapper ---------------------
var mapperConfig = new MapperConfiguration((options) =>
{
    options.AddProfile(new AutoMapperProfile());
});
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
// -------------------------------------------------------------------

// --------------------- Configurando DbContext ----------------------
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL"));
});
// -------------------------------------------------------------------

builder.Services.AddScoped<Respository>();
builder.Services.AddScoped<GenderRepository>();
builder.Services.AddScoped<ActorRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
