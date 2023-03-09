using Microsoft.AspNetCore.Identity;
using MidvaalCommunityBlog.Common.Entities;
using MidvaalCommunityBlog.App.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MidvaalCommunityBlog.App.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> UserManager;
        private SignInManager<User> SignInManager;
        public AccountController(UserManager<User> UserManager, SignInManager<User> SignInManager)
        {
            this.UserManager = UserManager;
            this.SignInManager = SignInManager;
        }
        public ViewResult LogIn(string? returnUrl)
        {
            return View(new UserLogin { ReturnUrl = returnUrl ?? "/"});
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(UserLogin details)
        {
            if(ModelState.IsValid)
            {
                User existing = await UserManager.FindByEmailAsync(details.Email);
                if(existing != null)
                {
                    await SignInManager.SignOutAsync();
                    if((await SignInManager.PasswordSignInAsync(existing, details.Password, false, false)).Succeeded)
                    {
                        return Redirect(details.ReturnUrl ?? "/");
                    }
                    
                }
                ModelState.AddModelError("", "Invalid Password or Email");
            }
            return View(details);
        }
        public async Task<RedirectResult> LogOut()
        {
            await SignInManager.SignOutAsync();
            return Redirect("/");
        }
        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser user)
        {
            if(user.ConfirmPassword != user.Password)
            {
                ModelState.AddModelError("", "Passwords don't Match");
            }
            if (ModelState.IsValid)
            {
                User newUser = new() { 
                    UserName= user.UserName,
                    LastName= user.LastName,
                    Email = user.EmailAddress,
                    Profession = user.Profession,
                    Location = user.Location,
                    FirstName = user.FirstName
                };
                IdentityResult result = await UserManager.CreateAsync(newUser, user.Password);
                if (result.Succeeded)
                {
                    await SignInManager.PasswordSignInAsync(newUser, user.Password, false, false);
                    return Redirect("/");
                }
                else
                {
                    foreach(IdentityError err in result.Errors)
                    {
                        ModelState.AddModelError("",err.Description);
                    }
                }
                
            }
            return(View(user));
            
        }
    }
}
