using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project.BLL.UserModel
{
    public class UserEntity
    {
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email Address Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [StringLength(20, ErrorMessage = "Must be between 5 and 20 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[^\da-zA-Z]).{5,20}$", ErrorMessage = "Must Contain one special character")]
        public string ConfirmPassword { get; set; }

        public bool PersistentLogin { get; set; }
    }
}
