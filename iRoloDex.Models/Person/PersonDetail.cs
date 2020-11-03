using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRoloDex.Models.Person
{
    public class PersonDetail
    {
        public int PersonId { get; set; }
        public int OwnerId { get; set; }
        public int HouseholdId { get; set; }
        public int RelationshipId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }  
}
