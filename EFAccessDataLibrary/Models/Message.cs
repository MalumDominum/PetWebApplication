using System;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EFDataAccessLibrary.Models
{
    public class Message
    {
        [Key] internal int MessageId { get; }
        [Required] public string Content { get; set; }
        [Required] public DateTime CreatedAt { get; set; }
        [Required] public DateTime LastUpdateAt { get; set; }

        internal int UserReceiverId { get; }
        internal int UserSenderId { get; }

        [Required] public User UserReceiver { get; set; }
        [Required] public User UserSender { get; set; }
    }
}
