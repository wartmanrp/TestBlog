namespace TestBlog.Migrations
{
   using Microsoft.AspNet.Identity;
   using Microsoft.AspNet.Identity.EntityFramework;
   using Models;
   using System.Data.Entity.Migrations;
   using System.Linq;

   internal sealed class Configuration : DbMigrationsConfiguration<TestBlog.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TestBlog.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
         //create admin

         //creates admin if doesn't exist.
         if (!roleManager.RoleExists("Admin"))
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
               roleManager.Create(new IdentityRole { Name = "Admin" });
            }

         //creates moderator role if doesn't exist
         if (!context.Roles.Any(r => r.Name == "Moderator"))
         {
            roleManager.Create(new IdentityRole { Name = "Moderator" });
         }

         var uStore = new UserStore<ApplicationUser>(context);
         var userManager = new UserManager<ApplicationUser>(uStore);

         //creates new user
         if (userManager.FindByEmail("powers.wartman@gmail.com") == null)
         {
            userManager.Create(new ApplicationUser
            {
               UserName = "powers.wartman@gmail.com",
               Email = "powers.wartman@gmail.com",
               FirstName = "Powers",
               LastName = "Wartman"
            }, "Password-1");
         }

         //assigns person to given role (admin || moderator), if not already in it.
         var userId = userManager.FindByEmail("powers.wartman@gmail.com").Id;
         if (!userManager.IsInRole(userId, "Admin"))
         {
            userManager.AddToRole(userId, "Admin");
         }       
      }
   }
}
