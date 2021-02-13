using System;
using System.Collections.Generic;
using PetWebProject;

#nullable disable

namespace EFDataAccessLibrary.Models
{
    public partial class Pet
    {
        public Pet()
        {
            Comments = new HashSet<Comment>();
            PetPhotos = new HashSet<PetPhoto>();
        }

        public int PetId { get; set; }
        public int? UserId { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public DateTime? BirthDate { get; set; }
        public TimeSpan? RoughAge { get; set; }
        public bool? Neutering { get; set; }
        public char? Gender { get; set; }
        public bool? Healthy { get; set; }
        public string Descriprion { get; set; }
        public int? AddressId { get; set; }
        public int? ViewsNumber { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastUpdateAt { get; set; }

        public virtual Address Address { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<PetPhoto> PetPhotos { get; set; }
    }
}
