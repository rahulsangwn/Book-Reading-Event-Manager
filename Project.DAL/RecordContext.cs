using Project.DAL.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;

namespace Project.DAL
{
    public class RecordContext : DbContext, IRecordContext
    {
        /// <summary>
        /// For Connecting to Database using connection string named as "MyConnection" in app.config
        /// </summary>
        public RecordContext() : base("MyConnection")
        {
            DbInterception.Add(new InterceptorLogging());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Invite> Invites { get; set; }
    }
}
