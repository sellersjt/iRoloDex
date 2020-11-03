using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRoloDex.Data.Entities
{
    public class Household
    {
        [Key]
        public int HouseholdId { get; set; }
        public virtual ICollection<Person> Persons { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Zip { get; set; }

        [ForeignKey(nameof(Owner))]
        public int? OwnerId { get; set; }
        public virtual Owner Owner { get; set; }

        public Household()
        {
            this.HouseholdViewers = new HashSet<ApplicationUser>();
        }
        public virtual ICollection<ApplicationUser> HouseholdViewers { get; set; }
    }
}
