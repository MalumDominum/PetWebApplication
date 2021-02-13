#nullable disable

namespace EFDataAccessLibrary.Models
{
    public partial class PetPhoto
    {
        public int PhotoId { get; set; }
        public int? PetId { get; set; }
        public string Path { get; set; }

        public virtual Pet Pet { get; set; }
    }
}
