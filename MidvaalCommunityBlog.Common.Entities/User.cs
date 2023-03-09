using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
namespace MidvaalCommunityBlog.Common.Entities
{
    public class User : IdentityUser
    {
        
        public int UserId { get; set; }
        [Required (ErrorMessage ="Please enter your FirstName")]
        [RegularExpression("[a-z][A-Z]+", ErrorMessage = "Name must be Alphabetical letter only")]
        [StringLength(30)]
        public string FirstName { get; set; } = string.Empty;


        [StringLength(30)]
        [Required(ErrorMessage =("Please enter your Lastname"))]
        [RegularExpression("[a-z][A-Z]+" ,ErrorMessage = "Name must be Alphabetical letter only")]
        public string LastName { get; set; } = string.Empty;

        [StringLength(50)]
        [Required(ErrorMessage = "Please enter your Location")]
        public string Location { get; set; } = string.Empty;

        
        public DateTime DateRegistered { get; set; } = DateTime.Now;

        
        [StringLength(40)]
        public string  Profession { get; set; } = string.Empty;
        public string Avatar { get; set; } = "avatar.jpg";

    }
}