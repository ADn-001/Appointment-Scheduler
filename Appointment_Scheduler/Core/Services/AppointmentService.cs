using System.Collections.Generic;
using System.Linq;
using System;
using Core.Entities;
using Core.Interfaces;

namespace Core.Services
{
    public class AppointmentService
    {
        private readonly IAppointmentRepository _repository;

        public AppointmentService(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public Appointment ScheduleAppointment(Appointment newAppointment)
        {
            if (_repository.GetAll().Any(a => a.ScheduledDate == newAppointment.ScheduledDate))
                throw new InvalidOperationException("There is already an appointment at the given time.");

            _repository.Add(newAppointment);
            return newAppointment;
        }

        public IEnumerable<Appointment> GetAllAppointments() => _repository.GetAll();

        public Appointment GetAppointment(Guid id) => _repository.GetById(id);

        public void CancelAppointment(Guid id) => _repository.Remove(id);
    }
}
