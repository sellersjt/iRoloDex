using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRoloDex.Data.Entities
{
    public class Relationship
    {
        [Key]
        public int RelationshipId { get; set; }
        [Required]
        public string Name { get; set; }
        public string RelationshipType { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
        //public virtual ICollection<Person> Persons { get; set; }
    }
}
