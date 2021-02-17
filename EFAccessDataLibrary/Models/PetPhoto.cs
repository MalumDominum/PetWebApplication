using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EFDataAccessLibrary.Models
{
    public partial class PetPhoto
    {
        [Key] internal int PhotoId { get; }
        [Required] public string Path { get; set; }

        internal int PetId { get; }

        [Required] public virtual Pet Pet { get; set; }
    }
}
