using CurrencyExchang.Application.Services.ServiceEntity;
using CurrencyExchange.Application.Services.Interfaces;
using CurrencyExchange.Core.Interfaces;
using CurrencyExchange.Infrastructure.Persistence;
using CurrencyExchange.Infrastructure.Persistence.Repositories;
using Infrastructure.Extensions;
using Market.api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
builder.Services.AddInfrastructureServices(connectionString);
var app = builder.Build();

//Seed data
app.Services.SeedData();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(op => op.SwaggerEndpoint("/openapi/v1.json", "Welcom Back To Swagger"));
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();