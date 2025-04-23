using System;

namespace Core.Entities
{
    public class Appointment
    {
        public Guid Id { get; private set; }
        public DateTime ScheduledDate { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }

        public Appointment(DateTime scheduledDate, string title, string description = null)
        {
            if (scheduledDate <= DateTime.Now)
                throw new ArgumentException("Appointment date must be in the future.", nameof(scheduledDate));

            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty.", nameof(title));

            Id = Guid.NewGuid();
            ScheduledDate = scheduledDate;
            Title = title;
            Description = description;
        }

        public void Reschedule(DateTime newDate)
        {
            if (newDate <= DateTime.Now)
                throw new ArgumentException("New appointment date must be in the future.", nameof(newDate));

            ScheduledDate = newDate;
        }
    }
}
