using System.Collections.Generic;
using PetWebProject;

#nullable disable

namespace EFDataAccessLibrary.Models
{
    public partial class Address
    {
        public Address()
        {
            Pets = new HashSet<Pet>();
            UserAddresses = new HashSet<UserAddress>();
        }

        public int AddressId { get; set; }
        public string StreetName { get; set; }
        public int? HouseNumber { get; set; }
        public int? ApartmentNumber { get; set; }
        public string District { get; set; }
        public int? CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
        public virtual ICollection<UserAddress> UserAddresses { get; set; }
    }
}
