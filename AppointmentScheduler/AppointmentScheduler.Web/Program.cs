using AppointmentScheduler.Application.Services;
using AppointmentScheduler.Core.Interfaces;
using AppointmentScheduler.Infrastructure.Repositories;
using AppointmentScheduler.Web.Dtos;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IAppointmentRepository, InMemoryAppointmentRepository>();
builder.Services.AddScoped<AppointmentService>();

// Add Swagger for API documentation.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

// Minimal API Endpoints
app.MapPost("/appointments", (AppointmentDto dto, AppointmentService service) =>
{
    service.ScheduleAppointment(dto.Title, dto.DateTime);
    return Results.Created($"/appointments/{dto.Id}", dto);
});

app.MapGet("/appointments", (AppointmentService service) =>
{
    var appointments = service.GetAllAppointments();
    var dtos = appointments.Select(a => new AppointmentDto
    {
        Id = a.Id,
        Title = a.Title,
        DateTime = a.DateTime
    });
    return Results.Ok(dtos);
});

app.MapDelete("/appointments/{id:guid}", (Guid id, AppointmentService service) =>
{
    service.CancelAppointment(id);
    return Results.NoContent();
});

app.Run();