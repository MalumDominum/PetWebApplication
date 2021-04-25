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
		// TODO Maybe add Date
    }

    public enum Statuses
    {
        UnderGuardianship, NeedsGuardianship, Attached, NotAttached, Lost, Found, NeedsHelp, NotNeedsHelp, NeedOverexposure, OnOverexposure
    }
}
