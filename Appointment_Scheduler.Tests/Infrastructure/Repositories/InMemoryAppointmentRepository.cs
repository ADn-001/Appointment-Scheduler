using System.Collections.Generic;
using System;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Repositories
{
    public class InMemoryAppointmentRepository : IAppointmentRepository
    {
        private readonly List<Appointment> _appointments = new();

        public void Add(Appointment appointment) => _appointments.Add(appointment);

        public Appointment? GetById(Guid id) => _appointments.FirstOrDefault(a => a.Id == id);

        public IEnumerable<Appointment> GetAll() => _appointments;

        public void Remove(Guid id)
        {
            var appointment = GetById(id);
            if (appointment != null)
                _appointments.Remove(appointment);
        }
    }
}
