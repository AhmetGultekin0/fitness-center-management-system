using System.ComponentModel.DataAnnotations;

namespace fitneesCenterMS.Models
{
    public class Trainer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad Soyad zorunludur.")]
        [Display(Name = "Ad Soyad")]
        public string FullName { get; set; }

        [Display(Name = "Uzmanlık Alanı")]
        public string Specialization { get; set; } 

        [Display(Name = "Fotoğraf")]
        public string ImageUrl { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }
    }
}