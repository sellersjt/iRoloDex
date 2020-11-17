using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRoloDex.Models.RelationshipModels
{
    public class RelationshipCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(25, ErrorMessage = "There are too many characters in this field.")]
        public string RelationshipType { get; set; }
    }
}
