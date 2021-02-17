using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

#nullable disable

namespace EFDataAccessLibrary.Models
{
    public class City
    {
        [Key] internal int CityId { get; }
        [Required] public string CityName { get; set; }
        public string Region { get; set; }

        internal int CountryId { get; }

        [Required] public Country Country { get; set; }
        public List<Address> Addresses { get; set; } = new List<Address>();
    }
}
