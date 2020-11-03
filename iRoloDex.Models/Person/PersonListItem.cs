using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRoloDex.Models.Person
{
    public class PersonListItem
    {
        public int OwnerId { get; set; }
        public int HouseholdId { get; set; }
        public int RelationshipId { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int PersonId { get; set; }
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
