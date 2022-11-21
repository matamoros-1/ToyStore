using AutoMapper.Internal.Mappers;
using Backend_ToyStore.Data;
using Backend_ToyStore.Repository;
using Backend_ToyStore.ToysToreMapper;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IJuguetesRepository, JuguetesRepository>();
builder.Services.AddAutoMapper(typeof(ToyStoreMapper));

#region SERVICIOS AGREGADOS

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://LocalHost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});


#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(myAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
