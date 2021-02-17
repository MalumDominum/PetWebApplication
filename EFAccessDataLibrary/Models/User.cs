using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EFDataAccessLibrary.Models
{
    public class User
    {
        [Key] internal int UserId { get; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public char Gender { get; set; }
        [Required] internal string Password { get; set; }
        [Required] [DataType(DataType.EmailAddress)] public string Email { get; }
        public string PhoneNumber { get; set; }
        [Required] public DateTime BirthDate { get; set; }
        public string PhotoPath { get; set; }
        [Required] public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }

        internal int AddressId { get; }

        public List<Message> ReceivedMessages { get; set; } = new List<Message>();
        public List<Message> SentMessages { get; set; } = new List<Message>();
        public List<Pet> Pets { get; private set; }
        [Required] public List<Address> Addresses { get; set; } = new List<Address>();
    }
}
