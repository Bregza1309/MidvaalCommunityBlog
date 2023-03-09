using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace MidvaalCommunityBlog.App.Models.ViewModels
{
    public class UserLogin
    {
        [Required(ErrorMessage ="Please enter your email address")]
        [EmailAddress(ErrorMessage ="Invalid Email format")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage ="Please enter your password")]
        [PasswordPropertyText]
        public string Password { get; set; } = string.Empty;

        public string ReturnUrl { get; set; } = "/";

    }
}
