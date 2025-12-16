using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace fitneesCenterMS.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Randevu Tarihi")]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public string MemberId { get; set; }
        public IdentityUser Member { get; set; }

        [Display(Name = "Antrenör")]
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }

        [Display(Name = "Hizmet")]
        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public string Status { get; set; } = "Bekliyor"; // Varsayılan değer
    }
}