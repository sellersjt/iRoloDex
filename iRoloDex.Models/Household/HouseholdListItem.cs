using iRoloDex.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRoloDex.Models.Household
{
    public class HouseholdListItem
    {
        public int HouseholdId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public Owner Owner { get; set; }
        public ICollection<Person> Persons { get; set; }
    }
}
