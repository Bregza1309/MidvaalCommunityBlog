using Azure.Identity;
using MidvaalCommunityBlog.Common.Entities;
using System.ComponentModel.DataAnnotations;
namespace MidvaalCommunityBlog.App.Models.ViewModels
{
    public class RegisterUser
    {
        
        [Required(ErrorMessage = "Please enter your UserName")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage ="Please enter your FirstName")]
        [RegularExpression("[A-Z][a-z]+",ErrorMessage ="FirstName should Contain only Alphabetical Letters")]
        public string FirstName { get; set; } = string.Empty;
        
        [Required(ErrorMessage ="Please enter your LastName")]
        [RegularExpression("[A-Z][a-z]+",ErrorMessage ="LastName should Contain only Alphabetical Letters")]
        public string LastName { get; set; } = string.Empty;
        
        [Required(ErrorMessage ="Please enter your Profession")]
        [RegularExpression("[A-Z][a-z]+",ErrorMessage ="Profession should Contain only Alphabetical Letters")]
        public string Profession { get; set; } = string.Empty;

        [Required(ErrorMessage ="Please enter your Email Address")]
        [EmailAddress] 
        public string EmailAddress { get; set;} = string.Empty;
        [Required(ErrorMessage ="Please enter your password")]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage ="Please Confirm your password")]
        public string ConfirmPassword { get; set; } = string.Empty;
        [Required(ErrorMessage ="Enter your Location")]
        public string Location { get; set;} = string.Empty;
    }
}
