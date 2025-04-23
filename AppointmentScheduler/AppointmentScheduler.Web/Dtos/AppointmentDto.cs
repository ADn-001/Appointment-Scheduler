using System;

namespace AppointmentScheduler.Web.Dtos
{
    public class AppointmentDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
    }
}