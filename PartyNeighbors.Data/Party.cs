using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyNeighbors.Data
{
    public class Party
    {
        [Key]
        [Display(Name = "Id")]
        public int PartyId { get; set; }
        
        [Required]
        [Display(Name = "Party Name")]
        public string PartyName { get; set; }
        
        [Required]
        [Display(Name = "Kickoff Time")]
        public DateTimeOffset PartyTime { get; set; }
        
        [Required]
        [Display(Name = "Host")]
        public string HostId { get; set; }
        
        [Required]
        public int Capacity { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Required]
        [Display(Name = "Neighborhood")]
        public int NeighborhoodId { get; set; }
        public virtual Neighborhood Neighborhood { get; set; }

        [Required]
        [Display(Name = "Part of Neighborhood")]
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        public int ResidentId { get; set; }
        public string ResidentName { get; set; }
        public virtual ICollection<Resident> Residents { get; set; }
    }
}
