using Microsoft.EntityFrameworkCore.Diagnostics;
using MidvaalCommunityBlog.Common.Entities;
namespace MidvaalCommunityBlog.App.Models
{
    public interface IBlogRepository
    {
        IQueryable<Post> GetPosts(string? category);
        Task<List<string>> GetCategories();
        Task CreatePost(Post post);
       
    }
    
}
