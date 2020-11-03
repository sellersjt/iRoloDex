using Microsoft.Owin.Security.OAuth;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Metadata.Edm;

namespace iRoloDex.Data.Entities
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [ForeignKey (nameof(Household))]
        public int? HouseholdId{ get; set; }
        public virtual Household Household { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        [ForeignKey (nameof(Owner))]
        public int? OwnerId { get; set; }
        public virtual Owner Owner { get; set; }

        [ForeignKey (nameof(Relationship))]
        public int RelationshipId { get; set; }
        public virtual Relationship Relationship { get; set; }

        //public Person() 
        //{
        //    this.PersonViewers = new HashSet<ApplicationUser>();
        //}
        //public virtual ICollection<ApplicationUser> PersonViewers { get; set; }

        public virtual ICollection<Person> Households { get; set; }
        public virtual ICollection<Person> Relationships { get; set; }

    }
}