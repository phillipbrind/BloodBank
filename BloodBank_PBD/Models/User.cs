using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BloodBank_PBD.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name cannot be blank")]
        [MaxLength(30, ErrorMessage = "Do not enter more than 30 characters")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name cannot be blank")]
        [MaxLength(30, ErrorMessage = "Do not enter more than 30 characters")]
        public string LastName { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address cannot be blank")]
        [MaxLength(60, ErrorMessage = "Do not enter more than 60 characters")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Age cannot be blank")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Make sure you select a blood type")]
        [MaxLength(3)]
        public string BloodType { get; set; }
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username cannot be blank")]
        [MaxLength(20, ErrorMessage = "Do not enter more than 20 characters")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Make sure you enter a password")]
        [MaxLength(50)]
        public string Password { get; set; }

        public virtual List<Test> Tests { get; set; }
    }
}
