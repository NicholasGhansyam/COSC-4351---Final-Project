using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using MvcMovies.Models;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcMovies.Startup))]
namespace MvcMovies
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateUserAndRoles();
        }

        public void CreateUserAndRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {

                var role = new IdentityRole("Admin");
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "Admin@company.com";
                user.Email = "Admin@company.com";
                string pwd = "Admin#1";

                var newuser = userManager.Create(user, pwd);
                if (newuser.Succeeded)
                {
                    userManager.AddToRole(user.Id,"Admin");
                }


            }
        }
    }
}
