using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PartyNeighbors.Data
{
    public class PartyItem
    {
        [Key]
        [Display(Name = "Id")]
        public int PartyItemId { get; set; }
        [Required]
        [Display(Name = "Party Item")]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; } = 0;
        [Required]
        [Range(2,500, ErrorMessage = "Must be less than 500, but at least you and a friend...")]
        public double Price { get; set; }
        public bool Purchased { get; set; } = false;
    }
}
