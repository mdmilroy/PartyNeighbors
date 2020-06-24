using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyNeighbors.Data
{
    public class Category
    {
        [Key]
        [Display(Name = "Id")]
        public int CategoryId { get; set; }
        [Display(Name = "Category")]
        public string Name { get; set; }
        public ICollection<Party> Parties { get; set; }

    }
}
