using System.Collections.Generic;
using PetWebProject;

#nullable disable

namespace EFDataAccessLibrary.Models
{
    public partial class City
    {
        public City()
        {
            Addresses = new HashSet<Address>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public string Region { get; set; }
        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
