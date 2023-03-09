using Microsoft.EntityFrameworkCore;
namespace MidvaalCommunityBlog.Common.Entities
{
    public class McbDb :DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        private string connectionString = @"Data Source=.;Initial Catalog=MidvaalCommunityBlog;Integrated Security=true;MultipleResultSets=true;Encrypt=false";

        
        public McbDb(DbContextOptions<McbDb> options):base(options)
        {
            
        }
        
    }
}
