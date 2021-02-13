using System;
using System.Collections.Generic;
using EFDataAccessLibrary.Models;

#nullable disable

namespace PetWebProject
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public int? UserSenderId { get; set; }
        public int? UserReciverId { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastUpdateAt { get; set; }

        public virtual User UserReciver { get; set; }
        public virtual User UserSender { get; set; }
    }
}
