using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MidvaalCommunityBlog.Common.Entities;

namespace MidvaalCommunityBlog.App.Models
{
    public class BlogRepository : IBlogRepository
    {
        private  McbDb db;
        private readonly UserManager<User> userManager;
        public BlogRepository(McbDb db,UserManager<User> manager)
        {
            this.db = db;
            this.userManager = manager;
        }
        public IQueryable<Post> GetPosts(string? category) => (category == null) ? db.Posts.OrderByDescending(p => p.PostedOn) :db.Posts.Where(p => p.Category== category).OrderByDescending(p => p.PostedOn);

        public async Task<List<string>> GetCategories() => await db.Posts.Select(p => p.Category).Distinct().ToListAsync();

        public async Task CreatePost(Post post)
        {
            await db.Posts.AddAsync(post);
            await db.SaveChangesAsync();
        }
    }
}
