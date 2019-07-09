using ByingApplications.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ByingApplications.Startup))]
namespace ByingApplications
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateUsersandRoles();
        }
        public void CreateUsersandRoles()
        {
            ApplicationDbContext _context = new ApplicationDbContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));

            if (!roleManager.RoleExists("SuperAdmin"))
            {
                var role = new IdentityRole("SuperAdmin");
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.Email = "Admin@gmail.com";
                user.UserName = "Admin@gmail.com";

                string pwd = "App123??";
                var newUser = userManager.Create(user,pwd);

                if (newUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "SuperAdmin");
                }
            }
        }
    }
}
