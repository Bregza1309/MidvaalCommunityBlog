using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MidvaalCommunityBlog.Common.Entities;
namespace MidvaalCommunityBlog.App.Models
{
    public class BlogIdentityContext:IdentityDbContext<User>
    {
        public BlogIdentityContext(DbContextOptions<BlogIdentityContext> options) : base(options) { }
    }
}
