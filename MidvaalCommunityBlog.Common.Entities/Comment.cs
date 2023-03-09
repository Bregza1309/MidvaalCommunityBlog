using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MidvaalCommunityBlog.Common.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }

        [Required]
        [StringLength(50)]
        public string CommentText { get; set; } = string.Empty;

        [Required]
        public DateTime TimeOfPost { get; set; } = DateTime.Now;

        [Required]
        public int PostId { get; set; }
        [Required]
        public int UserId { get; set; }

        
    }
}
