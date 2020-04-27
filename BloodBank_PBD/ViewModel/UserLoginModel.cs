using System.ComponentModel.DataAnnotations;

namespace BloodBank_PBD.ViewModel
{
    public class UserLoginModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username cannot be blank")]
        [MaxLength(20, ErrorMessage = "Do not enter more than 20 characters")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Make sure you enter a password.")]
        [MaxLength(20, ErrorMessage = "Do not enter more than 20 characters")]
        public string Password { get; set; }
    }
}