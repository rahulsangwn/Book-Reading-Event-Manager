using System.Data.Entity;
using Project.DAL.Data;

namespace Project.DAL
{
    public interface IRecordContext
    {
        DbSet<Comment> Comments { get; set; }
        DbSet<Event> Events { get; set; }
        DbSet<Invite> Invites { get; set; }
        DbSet<User> Users { get; set; }
    }
}