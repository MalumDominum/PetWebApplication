using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EFDataAccessLibrary.Models
{
    public class Country
    {
        [Key] internal int CountryId { get; }
        [Required] public string CountryName { get; set; }

        public virtual List<City> Cities { get; set; } = new List<City>();
    }
}
