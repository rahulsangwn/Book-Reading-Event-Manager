using System.ComponentModel.DataAnnotations;

namespace Project.DAL.Data
{
    public class User : IUser
    {
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}
