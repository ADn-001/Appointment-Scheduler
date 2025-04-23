using System;
using System.Collections.Generic;
using AppointmentScheduler.Core.Entities;

namespace AppointmentScheduler.Core.Interfaces
{
    public interface IAppointmentRepository
    {
        void Add(Appointment appointment);
        Appointment GetById(Guid id);
        IEnumerable<Appointment> GetAll();
        void Remove(Guid id);
    }
}