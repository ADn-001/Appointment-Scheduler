using System.Collections.Generic;
using System;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IAppointmentRepository
    {
        void Add(Appointment appointment);
        Appointment GetById(Guid id);
        IEnumerable<Appointment> GetAll();
        void Remove(Guid id);
    }
}
