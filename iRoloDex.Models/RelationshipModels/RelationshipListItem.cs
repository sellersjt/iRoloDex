﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRoloDex.Models.RelationshipModels
{
    public class RelationshipListItem
    {
        public int RelationshipId { get; set; }
        public string RelationshipType { get; set; }
    }
}
