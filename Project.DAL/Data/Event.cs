using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.DAL.Data
{
    public class Event : IEvent
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public string Location { get; set; }

        [MaxLength(10)]
        public string Type { get; set; }

        public int Duration { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        [MaxLength(500)]
        public string Others { get; set; }

        public string Email { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Invite> InvitedUsers { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
