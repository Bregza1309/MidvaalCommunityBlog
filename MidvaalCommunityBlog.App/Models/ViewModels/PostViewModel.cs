using Microsoft.AspNetCore.Identity;
using MidvaalCommunityBlog.Common.Entities;
namespace MidvaalCommunityBlog.App.Models.ViewModels
{
    public class PostViewModel
    {
        public IEnumerable<Post> Posts { get; set; } = Enumerable.Empty<Post>();
        public List<string> Categories { get; set; } = new();

        public string Avatar { get; set; } = string.Empty;
        public string? Category { get; set; }

    }
}
