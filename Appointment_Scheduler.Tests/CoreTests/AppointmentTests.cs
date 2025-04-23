using System;
using System.Linq;
using Core.Entities;
using Core.Services;
using Infrastructure.Repositories;
using Xunit;

public class AppointmentServiceTests
{
    [Fact]
    public void Should_Create_Valid_Appointment()
    {
        var repo = new InMemoryAppointmentRepository();
        var service = new AppointmentService(repo);

        var appointment = new Appointment(DateTime.Now.AddHours(1), "Test");

        var result = service.ScheduleAppointment(appointment);

        Assert.Contains(repo.GetAll(), a => a.Id == result.Id);
    }

    [Fact]
    public void Should_Throw_When_Date_In_Past()
    {
        Assert.Throws<ArgumentException>(() => new Appointment(DateTime.Now.AddHours(-1), "Invalid"));
    }

    [Fact]
    public void Should_Throw_On_Conflict()
    {
        var repo = new InMemoryAppointmentRepository();
        var service = new AppointmentService(repo);

        var time = DateTime.Now.AddHours(1);
        service.ScheduleAppointment(new Appointment(time, "First"));

        Assert.Throws<InvalidOperationException>(() =>
            service.ScheduleAppointment(new Appointment(time, "Conflict")));
    }
}
