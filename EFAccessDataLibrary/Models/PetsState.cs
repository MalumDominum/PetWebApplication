using PetWebProject;

#nullable disable

namespace EFDataAccessLibrary.Models
{
    public partial class PetsState
    {
        public int? PetId { get; set; }
        public int? StateId { get; set; }

        public virtual Pet Pet { get; set; }
        public virtual State State { get; set; }
    }
}
