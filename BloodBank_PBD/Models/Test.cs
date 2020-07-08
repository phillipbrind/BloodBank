using System.ComponentModel.DataAnnotations;

namespace BloodBank_PBD.Models
{
    public class Test
    {
        [Key]
        public int TestId { get; set; }
        [Display(Name = "Donor Full Name")]
        [Required(ErrorMessage = "Donor Full Name cannot be blank")]
        [MaxLength(50, ErrorMessage = "Do not enter more than 50 characters")]
        public string DonorFullName { get; set; }
        [Display(Name = "Weight (kg)")]
        [Required(ErrorMessage = "Weight cannot be blank")]
        public double Weight { get; set; }
        [Display(Name = "Height (cm)")]
        [Required(ErrorMessage = "Height cannot be blank")]
        public double Height { get; set; }
        [MaxLength(7)]
        public string BP { get; set; }
        [MaxLength(9)]
        public string Progress { get; set; }
        [Required(ErrorMessage = "Make sure you select a date")]
        public System.DateTime Date { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "Systolic cannot be blank")]
        public int Systolic { get; set; }
        [Required(ErrorMessage = "Diastolic cannot be blank")]
        public int Diastolic { get; set; }

        public virtual User User { get; set; }
    }
}
