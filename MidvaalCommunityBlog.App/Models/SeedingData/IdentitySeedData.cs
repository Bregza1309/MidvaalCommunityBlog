using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MidvaalCommunityBlog.App.Models;
using MidvaalCommunityBlog.Common.Entities;
namespace MidvaalCommunityBlog.App.Models.SeedingData
{
    public static class IdentitySeedData
    {
        public async static Task EnsurePopulated(IApplicationBuilder app)
        {
            BlogIdentityContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BlogIdentityContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            //get user manager
            UserManager<User> userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<User> >();
            User[] initialUsers = { new User { UserName = "Bregza" ,Email = "brendon@example.com" ,PhoneNumber = "073 345 6787" ,FirstName = "Brendon", LastName = "Muchesa", Avatar = "avatar.jpg", Profession = "Software Developer"},
                                            new User { UserName = "Paul1234" ,Email = "heyman@example.com" ,PhoneNumber = "065 345 6787" ,FirstName = "Paul", LastName = "Heyman",  Avatar = "avatar.jpg", Profession = "Student"},
                                            new User { UserName = "Jones1345" ,Email = "jones@example.com" ,PhoneNumber = "081 365 6757",FirstName = "Kevin", LastName = "Jones",  Avatar = "avatar.jpg", Profession = "Carpenter"}};

            string[] passwords = { "Bregz@1234" ,"P@ul1234" ,"Jone$1234"};

            for(int i = 0; i < initialUsers.Length; i++)
            {
                IdentityUser identityUser = await userManager.FindByEmailAsync(initialUsers[i].Email);
                if (identityUser == null) {
                    await userManager.CreateAsync(initialUsers[i], passwords[i]);
                }
            }
                                            
        }
    }
}
