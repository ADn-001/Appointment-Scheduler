using System.ComponentModel.DataAnnotations;

namespace AppointmentScheduler.Web.Dtos
{
    public class AppointmentDto
    {
        [Required(ErrorMessage = "The Title field is required.")]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        [Range(typeof(DateTime), "2025-01-01", "2100-12-31", ErrorMessage = "Scheduled date must be in the future.")]
        public DateTime ScheduledDate { get; set; }

        // public Guid Id { get; set; }
        // public bool IsCancelled { get; set; }
    }
}
