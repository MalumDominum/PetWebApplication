using System;
using System.Collections.Generic;

#nullable disable

namespace EFDataAccessLibrary.Models
{
    public partial class Comment
    {
        public Comment()
        {
            InverseAnswerOnNavigation = new HashSet<Comment>();
        }

        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime? PostDate { get; set; }
        public int? AnswerOn { get; set; }
        public int? MemberId { get; set; }
        public int? PetId { get; set; }

        public virtual Comment AnswerOnNavigation { get; set; }
        public virtual Pet Pet { get; set; }
        public virtual ICollection<Comment> InverseAnswerOnNavigation { get; set; }
    }
}
