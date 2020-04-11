using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project.BLL.UserModel
{
    public class EventEntity
    {
        public int EventId { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        public int Hours { get; set; }
        [Required]
        public int Mins { get; set; }
        [DisplayName("Event Time")]
        public DateTime StartTime { get; set; }
        [Required]
        public string Location { get; set; }

        [RegularExpression(@"^((Public)|(Private))$", ErrorMessage = "Type can be either Private or Public")]
        public string Type { get; set; }
        public int Duration { get; set; }
        [MaxLength(50, ErrorMessage = "Length must be less than 50")]
        public string Description { get; set; }
        [MaxLength(500, ErrorMessage = "Length must be less than 500")]
        public string Others { get; set; }
        public string Email { get; set; }
        public string InviteList { get; set; }
        public int NoOfInvitedUsers { get; set; }
        public IEnumerable<CommentEntity> Comments { get; set; }
    }
}
