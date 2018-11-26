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


                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
                {
                    Name = "Admin"
                };
                roleManager.Create(role);

                var user = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@admin.com"
                };
                string pwd = "Password1234%";

                var newuser = userManager.Create(user, pwd);
                if (newuser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id,"Admin");
                }


            }
        }
    }
}
