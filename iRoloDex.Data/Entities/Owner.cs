using System;
using System.ComponentModel.DataAnnotations;

namespace iRoloDex.Data.Entities
{
    public class Owner
    {
        [Key]
        public int OwnerId { get; set; }
        public Guid UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
