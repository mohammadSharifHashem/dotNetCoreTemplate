using System;
using System.Collections.Generic;

namespace Project.Entity.Models
{
    public partial class Countries
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Iso2 { get; set; }
        public string Iso3 { get; set; }
        public int? CountryCode { get; set; }
        public int? NumCode { get; set; }
        public byte Status { get; set; }
    }
}
