using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyNeighbors.Data
{
    public class Party // "state"
    {
        [Key]
        public int PartyId { get; set; }
        [Required]
        public string PartyName { get; set; }
        [Required]
        public DateTimeOffset PartyTime { get; set; }
        [Required]
        public string ResidentId { get; set; }
        public virtual Resident Resident { get; set; }
        [Required]
        public int Capacity { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Required]
        public int NeighborhoodId { get; set; }
        public virtual Neighborhood Neighborhood { get; set; }

        [Required]
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }


        public Party()
        {
            PartyItems = new HashSet<PartyItem>();
        }
        public virtual ICollection<PartyItem> PartyItems { get; set; }
    }
}
