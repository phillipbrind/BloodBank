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
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Message
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Message cannot be blank")]
        [MaxLength(200, ErrorMessage = "Do not enter more than 200 characters")]
        public string Message1 { get; set; }
        [Required(ErrorMessage = "Name cannot be blank")]
        [MaxLength(50, ErrorMessage = "Do not enter more than 50 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email cannot be blank")]
        [MaxLength(30, ErrorMessage = "Do not enter more than 30 characters")]
        public string Email { get; set; }
        public Nullable<int> Phone { get; set; }
    }
}