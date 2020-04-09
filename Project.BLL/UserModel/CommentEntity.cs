using System;

namespace Project.BLL.UserModel
{
    public class CommentEntity
    {
        public string Body { get; set; }
        public DateTime CommentDate { get; set; }
        public int EventId { get; set; }
        public string Email { get; set; }
    }
}
