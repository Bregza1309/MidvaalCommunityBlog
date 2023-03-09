using Microsoft.EntityFrameworkCore;
using MidvaalCommunityBlog.Common.Entities;
namespace MidvaalCommunityBlog.App.Models.SeedingData
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            McbDb db = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<McbDb>();

            if (db.Database.GetPendingMigrations().Any())
            {
                db.Database.Migrate();
            }
            
            if (!db.Posts.Any())
            {
                db.Posts.AddRange(new Post { Title = "Loose Tiger", Description = "There is a tiger on the loose around the walkerville area", UserName = "Paul1234", Category = "Alert" },
                                   new Post { Title = "Carpenter Needed", Description = "Carpenter needed in Daleside call Boris on  073 123 5678", UserName = "Jones1345", Category = "Jobs" });
                db.SaveChanges();
            }
        }
    }
}
