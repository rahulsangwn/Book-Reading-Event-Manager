using System;
using System.Collections.Generic;

namespace Project.DAL.Data
{
    public interface IEvent
    {
        ICollection<Comment> Comments { get; set; }
        DateTime Date { get; set; }
        string Description { get; set; }
        int Duration { get; set; }
        string Email { get; set; }
        int EventId { get; set; }
        ICollection<Invite> InvitedUsers { get; set; }
        string Location { get; set; }
        string Others { get; set; }
        DateTime StartTime { get; set; }
        string Title { get; set; }
        string Type { get; set; }
        User User { get; set; }
    }
}