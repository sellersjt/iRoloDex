using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRoloDex.Models.OwnerModels
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