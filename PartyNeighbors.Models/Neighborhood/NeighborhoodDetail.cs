﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyNeighbors.Models.Neighborhood
{
    public class NeighborhoodDetail
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public List<string> Locations { get; set; }
    }
}
