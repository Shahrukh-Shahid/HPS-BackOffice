using HPS_backoffice.Interfaces;
using HPS_backoffice.Managers;
using HPS_backoffice.Middleware;
using HPS_backoffice.Models;
using Microsoft.ApplicationInsights;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<HPSContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDDL, DDLManager>();
builder.Services.AddScoped<IService, ServiceManager>();
builder.Services.AddScoped<IClient, ClientManager>();
builder.Services.AddScoped<ICustomer, CustomerManager>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddSingleton<TelemetryClient>();


var app = builder.Build();

app.UseMiddleware<RequestResponseLoggingMiddleware>();
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
