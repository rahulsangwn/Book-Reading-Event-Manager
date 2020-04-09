using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.DAL.Data
{
    public class Invite : IInvite
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InviteId { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        public string Email { get; set; }
        public virtual User User { get; set; }
    }
}
