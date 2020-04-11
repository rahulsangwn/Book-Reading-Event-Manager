using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.DAL.Data
{
    public class Comment : IComment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int      CommentId        { get; set; }
        public string   Body             { get; set; }
        public DateTime CommentDate      { get; set; }

        public string   Email            { get; set; }
        public virtual  User User        { get; set; }

        public int?     EventId          { get; set; }
        public virtual  Event Event      { get; set; }
    }
}
