using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyNeighbors.Data
{
    public class Neighborhood
    {
        [Key]
        [Display(Name = "Id")]
        public int NeighborhoodId { get; set; }

        [Required]
        [Display(Name = "Neighborhood")]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [Range(10000, 99999, ErrorMessage = "Please enter your 5-digit zip code.")]
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        [Required]
        public int StateId { get; set; }
        public virtual State State { get; set; }


        public int ResidentId { get; set; }
        public string ResidentName { get; set; }
        public virtual ICollection<Resident> Residents { get; set; }

        public int PartyId { get; set; }
        public string PartyName { get; set; }
        public virtual ICollection<Party> Parties { get; set; }

        public int LocationId { get; set; }
        [Display(Name= "Venue Name")]
        public string LocationName { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}
