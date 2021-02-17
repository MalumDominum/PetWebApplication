using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EFDataAccessLibrary.Models
{
    public class Pet
    {
        [Key] internal int PetId { get; }
        [Required] public string Name { get; set; }
        [Required] public string Species { get; set; }
        public string Breed { get; set; }
        public DateTime? BirthDate { get; set; }
        [Required] public TimeSpan? RoughAge { get; set; }
        public bool? Neutering { get; set; }
        [Required] public char Gender { get; set; }
        [Required] public bool Healthy { get; set; }
        public string Description { get; set; }
        [Required] public int ViewsNumber { get; } = 0;
        [Required] public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdateAt { get; set; }

        internal int AddressId { get; }
        internal int UserId { get; }

        [Required] public Address Address { get; set; }
        [Required] public User User { get; set; }
        public List<Status> Statuses { get; set; } = new List<Status>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<PetPhoto> PetPhotos { get; set; }
    }
}
