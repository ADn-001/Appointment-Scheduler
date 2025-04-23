using System;
using System.Collections.Generic;
using AppointmentScheduler.Core.Entities;
using AppointmentScheduler.Core.Interfaces;

namespace AppointmentScheduler.Application.Services
{
    public class AppointmentService
    {
        private readonly IAppointmentRepository _repository;

        public AppointmentService(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public void ScheduleAppointment(string title, DateTime dateTime)
        {
            var appointment = new Appointment(title, dateTime);
            _repository.Add(appointment);
        }

        public IEnumerable<Appointment> GetAllAppointments()
        {
            return _repository.GetAll();
        }

        public void CancelAppointment(Guid id)
        {
            _repository.Remove(id);
        }
    }
}