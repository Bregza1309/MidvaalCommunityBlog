using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MidvaalCommunityBlog.Common.Entities
{
    public class Post
    {
        public int PostId { get; set; }

        [Required(ErrorMessage = "Title for your post is required")]
        [StringLength(40)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Post description is required")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(40)]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Post Tag is required")]
        public string Category { get; set; } = string.Empty;

        [Required]
        public DateTime PostedOn { get; set; } = DateTime.Now;

        

        
    }
}
