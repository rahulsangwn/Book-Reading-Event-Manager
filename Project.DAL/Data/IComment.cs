using System;

namespace Project.DAL.Data
{
    public interface IComment
    {
        string Body { get; set; }
        DateTime CommentDate { get; set; }
        int CommentId { get; set; }
        Event Event { get; set; }
        int? EventId { get; set; }
        User User { get; set; }
        string Email { get; set; }
    }
}