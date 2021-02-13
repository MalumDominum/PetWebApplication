using PetWebProject;

#nullable disable

namespace EFDataAccessLibrary.Models
{
    public partial class UserAddress
    {
        public int UserId { get; set; }
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual User User { get; set; }
    }
}
