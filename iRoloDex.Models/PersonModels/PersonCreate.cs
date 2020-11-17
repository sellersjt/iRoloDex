using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRoloDex.Models.PersonModels
{
    public class PersonCreate
    {
        public int OwnerId { get; set; }
        public int HouseholdId { get; set; }
        public int RelationshipId { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
