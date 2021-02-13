using System;
using System.Collections.Generic;
using PetWebProject;

#nullable disable

namespace EFDataAccessLibrary.Models
{
    public partial class User
    {
        public User()
        {
            MessageUserRecivers = new HashSet<Message>();
            MessageUserSenders = new HashSet<Message>();
            Pets = new HashSet<Pet>();
            UserAddresses = new HashSet<UserAddress>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char? Gender { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? AddressId { get; set; }
        public string PhotoPath { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }

        public virtual ICollection<Message> MessageUserRecivers { get; set; }
        public virtual ICollection<Message> MessageUserSenders { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
        public virtual ICollection<UserAddress> UserAddresses { get; set; }
    }
}
