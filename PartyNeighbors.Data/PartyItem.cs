using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyNeighbors.Data
{
    public class PartyItem
    {
        [Key]
        public int PartyItemId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; } = 0;
        [Required]
        public double Price { get; set; } = 0.0;
        [Required]
        public bool Purchased { get; set; } = false;

        public int PartyId { get; set; }
    }
}
