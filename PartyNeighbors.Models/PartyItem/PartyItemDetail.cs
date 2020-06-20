using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyNeighbors.Models.PartyItem
{
    public class PartyItemDetail
    {
        public string Name { get; set; }
        public int Quantity { get; set; } = 0;
        public decimal Price { get; set; }
        public bool Purchased { get; set; } = false;
    }
}
