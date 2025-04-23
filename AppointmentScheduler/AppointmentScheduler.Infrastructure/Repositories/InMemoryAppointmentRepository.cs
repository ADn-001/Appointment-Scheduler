using System;
using System.Collections.Generic;
using System.Linq;
using AppointmentScheduler.Core.Entities;
using AppointmentScheduler.Core.Interfaces;

namespace AppointmentScheduler.Infrastructure.Repositories
{
    public class InMemoryAppointmentRepository : IAppointmentRepository
    {
        private readonly List<Appointment> _appointments = new List<Appointment>();

        public void Add(Appointment appointment)
        {
            _appointments.Add(appointment);
        }

        public Appointment GetById(Guid id)
        {
            return _appointments.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _appointments.OrderBy(a => a.DateTime);
        }

        public void Remove(Guid id)
        {
            var appointment = GetById(id);
            if (appointment != null)
            {
                _appointments.Remove(appointment);
            }
        }
    }
}