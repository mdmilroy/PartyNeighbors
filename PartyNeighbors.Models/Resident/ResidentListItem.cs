﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyNeighbors.Models.Resident
{
    public class ResidentListItem
    {
        public int Id { get; set; }
        public string FullName { get; }
        public int NeighborhoodId { get; set; }
    }
}
