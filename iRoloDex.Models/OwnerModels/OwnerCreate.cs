using System;
using System.ComponentModel.DataAnnotations;

namespace iRoloDex.Models.OwnerModels
{
    public class OwnerCreate
    {
        public Guid UserId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Name { get; set; }
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
