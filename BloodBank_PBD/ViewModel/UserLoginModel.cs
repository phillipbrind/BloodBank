using System.ComponentModel.DataAnnotations;

namespace BloodBank_PBD.ViewModel
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Username cannot be blank", AllowEmptyStrings = false)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Make sure you enter a password.", AllowEmptyStrings = false)]
        public string Password { get; set; }
    }
}