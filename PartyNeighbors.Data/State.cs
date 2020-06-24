using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyNeighbors.Data
{
    public class State
    {
        [Key]
        [Display(Name = "State Id")]
        public int StateId { get; set; }

        [Display(Name = "State Name")]
        public string StateName { get; set; }

        public ICollection<Neighborhood> Neighborhoods { get; set; }
    }
}