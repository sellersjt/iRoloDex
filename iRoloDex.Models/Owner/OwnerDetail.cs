using System.ComponentModel.DataAnnotations;

namespace iRoloDex.Models.Owner
{
    public class OwnerDetail
    {
        [Display(Name = "Owner Id")]
        public int OwnerId { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Email Address")]
        public string Email { get; set; }
    }
}
