using Microsoft.EntityFrameworkCore;
using MidvaalCommunityBlog.App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MidvaalCommunityBlog.Common.Entities;
using MidvaalCommunityBlog.App.Models.SeedingData;

var builder = WebApplication.CreateBuilder(args);
//add Blog Repository
builder.Services.AddScoped<IBlogRepository, BlogRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<McbDb>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("MidvaalCommunityBlog"), b => b.MigrationsAssembly("MidvaalCommunityBlog.App")));

//Add Identity
builder.Services.AddDbContext<BlogIdentityContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BlogIdentity"));
});
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<BlogIdentityContext>();

//add Razor pages support
builder.Services.AddRazorPages();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
SeedData.EnsurePopulated(app);
await IdentitySeedData.EnsurePopulated(app);
app.Run();
