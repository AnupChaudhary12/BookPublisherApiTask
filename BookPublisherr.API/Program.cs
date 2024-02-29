using System.ComponentModel;
using System.Text.Json.Serialization;
using BookPublisher.Application;
using BookPublisher.Application.Dto;
using BookPublisher.Domain.Entities;
using BookPublisher.Infrastructure;
using BookPublisher.Infrastructure.Mapper;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using BookDto = BookPublisher.Domain.Entities.BookDto;

// Logger Configuration
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft",LogEventLevel.Warning)
    .Enrich.WithProcessId()
    .Enrich.WithThreadId()
    .Enrich.WithEnvironmentName()
    .Enrich.WithMachineName()
    .WriteTo.Console(new CompactJsonFormatter())
    .WriteTo.File(new CompactJsonFormatter(), "Log/log.txt",rollingInterval:RollingInterval.Day)
    .CreateLogger();
Log.Logger.Information("Starting up");
var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Add services to the container.

builder.Services.AddControllers()
    .AddFluentValidation(fv =>
    {
        fv.RegisterValidatorsFromAssemblyContaining<BookDto>();
        fv.RegisterValidatorsFromAssemblyContaining<BookPublisher.Application.Dto.BookDto>();
    });
//    .AddJsonOptions(options =>
//    {
//        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull; // Ignore null values
//    options.JsonSerializerOptions.PropertyNamingPolicy = null; // Keep property names as they are, preserve property names
//    options.JsonSerializerOptions.WriteIndented = true; // Pretty print JSON
//    options.JsonSerializerOptions.Converters.Add(new DateTimeConverter("yyyy-MM-dd")); // Convert enums to string
//});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BookPublisherDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("BookPublisher.Infrastructure")));

builder.Services.AddInfrastructure();
builder.Services.AddApplicationServices();
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
