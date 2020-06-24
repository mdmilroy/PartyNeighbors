using System;
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
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Resident Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Neighborhood")]
        public int NeighborhoodId { get; set; }
        public virtual Neighborhood Neighborhood { get; set; }

        public ICollection<Party> Parties { get; set; }
        public ICollection<PartyItem> PartyItems { get; set; }
    }
}
