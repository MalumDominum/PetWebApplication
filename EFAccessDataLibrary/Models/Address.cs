using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EFDataAccessLibrary.Models
{
    public class Address
    {
        [Key] internal int AddressId { get; }
        [Required] public string StreetName { get; set; }
        [Required] public int HouseNumber { get; set; }
        public int? ApartmentNumber { get; set; }
        public string District { get; set; }
        internal int CityId { get; }
        [Required] public City City { get; set; }
        public List<Pet> Pets { get; set; } = new List<Pet>();
        public List<User> Users { get; set; } = new List<User>();
    }
}
