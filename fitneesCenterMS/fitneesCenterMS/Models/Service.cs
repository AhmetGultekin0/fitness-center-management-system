using System.ComponentModel.DataAnnotations;

namespace fitneesCenterMS.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Hizmet adı zorunludur.")]
        [Display(Name = "Hizmet Adı")]
        public string Name { get; set; } // Örn: Pilates Seansı

        [Required]
        [Display(Name = "Süre (Dakika)")]
        public int DurationMinutes { get; set; } // Örn: 60

        [Required]
        [Display(Name = "Ücret")]
        public decimal Price { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}