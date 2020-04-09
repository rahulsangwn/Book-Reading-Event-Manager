using System;

namespace Project.BLL.UserModel
{
    public class InviteEntity
    {
        public int InviteId { get; set; }
        public int EventId { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public DateTime EventDate { get; set; }
    }
}
