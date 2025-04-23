using System;

namespace AppointmentScheduler.Core.Entities
{
    public class Appointment
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public DateTime DateTime { get; private set; }

        public Appointment(string title, DateTime dateTime)
        {
            if (dateTime < DateTime.Now)
                throw new ArgumentException("Cannot schedule an appointment in the past.");

            Id = Guid.NewGuid();
            Title = title;
            DateTime = dateTime;
        }
    }
}