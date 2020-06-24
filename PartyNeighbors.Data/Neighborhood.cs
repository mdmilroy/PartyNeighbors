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
        public int StateId { get; set; }
        public virtual State State { get; set; }
        [Required]
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        public ICollection<Resident> Residents { get; set; }
        public ICollection<Party> Parties { get; set; }
        public Neighborhood()
        {
            Locations = new HashSet<Location>();
        }
        public virtual ICollection<Location> Locations { get; set; }
    }
}
