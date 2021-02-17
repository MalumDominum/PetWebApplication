using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

#nullable disable

namespace EFDataAccessLibrary.Models
{
    public class Status
    {
        internal int StatusId { get; }
        public string Title { get; set; }
        public List<Pet> Pets { get; set; } = new List<Pet>();
    }

    public enum Statuses
    {
        UnderGuardianship, NotUnderGuardianship, Attached, NotAttached, Lost, Found, NeedHelp, NotNeedHelp
    }
}
