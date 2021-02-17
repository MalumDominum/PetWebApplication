using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EFDataAccessLibrary.Models
{
    public class Comment
    {
        [Key] internal int CommentId { get; }
        internal int AuthorId { get; }
        [Required] public User Author { get; set; }
        [Required] public string Content { get; set; }
        [Required] public DateTime PostDate { get; set; }
        internal int PetId { get; }
        [Required] public Pet Pet { get; set; }

        internal int AnswerOnId { get; }

        public Comment AnswerOn { get; set; }
        public List<Comment> Answers { get; set; } = new List<Comment>();
    }
}
