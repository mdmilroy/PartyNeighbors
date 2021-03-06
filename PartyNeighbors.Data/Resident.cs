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
        [Display(Name = "Id")]
        public string ResidentId { get; set; }
        [Required]
        [Display(Name = "First Name"), StringLength(25,ErrorMessage = "Your first name must be 25 characters or less.")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name"), StringLength(50, ErrorMessage = "Your last name must be 50 characters or less.")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Resident Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Neighborhood")]
        public int NeighborhoodId { get; set; }
        public virtual Neighborhood Neighborhood { get; set; }

        public int PartyId { get; set; }
        public string PartyName { get; set; }
        public virtual ICollection<Party> Parties { get; set; }
    }
}
