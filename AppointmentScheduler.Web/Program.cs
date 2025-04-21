using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;
using AppointmentScheduler.Core.Interfaces; // for IAppointmentRepository
using AppointmentScheduler.Infrastructure.Repositories; // for InMemoryAppointmentRepository
using AppointmentScheduler.Core.Services; // for AppointmentService
using AppointmentScheduler.Core.Entities; // For Appointment entity
using AppointmentScheduler.Web.Dtos;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IAppointmentRepository, InMemoryAppointmentRepository>();
builder.Services.AddScoped<AppointmentService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/appointments", (AppointmentDto dto, AppointmentService svc) =>
{
    try
    {
        var appointment = new Appointment(dto.ScheduledDate, dto.Title, dto.Description);
        var result = svc.ScheduleAppointment(appointment);
        return Results.Ok(new { message = "Appointment scheduled successfully", appointment = result });
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { message = "Error scheduling appointment", error = ex.Message });
    }
});

app.MapGet("/appointments", (AppointmentService svc) =>
{
    try
    {
        var result = svc.GetAllAppointments();
        return Results.Ok(new { message = "Appointments retrieved successfully.", appointments = result });
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { message = "An error occurred while retrieving the appointments.", error = ex.Message });
    }
});


app.MapGet("/appointments/{id}", (Guid id, AppointmentService svc) =>
{
    try
    {
        var result = svc.GetAppointmentById(id);
        if (result == null)
        {
            return Results.NotFound(new { message = "Appointment not found." });
        }
        return Results.Ok(new { message = "Appointment retrieved successfully.", appointment = result });
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { message = "An error occurred while retrieving the appointment.", error = ex.Message });
    }
});

app.MapDelete("/appointments/{id}", (Guid id, AppointmentService svc) =>
{
    try
    {
        var result = svc.CancelAppointment(id);
        if (!result)
        {
            return Results.NotFound(new { message = "Appointment not found." });
        }
        return Results.Ok(new { message = "Appointment successfully canceled." });
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { message = "An error occurred while deleting the appointment.", error = ex.Message });
    }
});

app.Run();
