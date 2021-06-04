using Infinity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Infinity.Startup))]
namespace Infinity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            UserRolesCreation();
        }

        private void UserRolesCreation()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
  
            if (!roleManager.RoleExists("Administrator"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Administrator";
                roleManager.Create(role);              

                var user = new ApplicationUser();
                user.UserName = "Admin17";
                user.Email = "admin.web17@gmail.com";

                string userPWD = "ABC_abc_100";
                var chkUser = UserManager.Create(user, userPWD);
    
                if (chkUser.Succeeded)
                    UserManager.AddToRole(user.Id, "Administrator");
            }
 
            if (!roleManager.RoleExists("Customer"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }
        }
    }
}