//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BloodBank_PBD.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Tests = new HashSet<Test>();
        }

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
        [Range(16, 60, ErrorMessage = "Age allowed is between 16 to 60")]
        public int Age { get; set; }
        [Display(Name = "Blood Type")]
        [Required(ErrorMessage = "Make sure you select a blood type.")]
        [MaxLength(3)]
        public string BloodType { get; set; }
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username cannot be blank")]
        [MaxLength(20, ErrorMessage = "Do not enter more than 20 characters")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Make sure you enter a password.")]
        [MaxLength(50, ErrorMessage = "Do not enter more than 50 characters")]
        public string Password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Test> Tests { get; set; }
    }
}
