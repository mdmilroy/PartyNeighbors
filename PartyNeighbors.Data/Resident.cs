﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyNeighbors.Data
{
    public class Resident
    {
        [Key]
        public string ResidentId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public int NeighborhoodId { get; set; }
        public int PartyItemId { get; set; }
    }
}
