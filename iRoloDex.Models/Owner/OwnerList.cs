using System;
using System.ComponentModel.DataAnnotations;

namespace iRoloDex.Models.Owner
{
    public class OwnerList
    {
        [Display(Name = "User Id")]
        public Guid UserId { get; set; }
        [Display(Name = "Owner Id")]
        public int OwnerId { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Email Address")]
        public string Email { get; set; }
    }
}
