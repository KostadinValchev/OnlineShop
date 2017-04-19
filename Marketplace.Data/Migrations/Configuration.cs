using Marketplace.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Marketplace.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MarketplaceContext>
    {
        public Configuration()
        {

            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MarketplaceContext context)
        {
            if (!context.Roles.Any())
            {
                this.CreateRole(context, "Admin");
                this.CreateRole(context, "User");
            }

            if (!context.Users.Any())
            {
                this.CreateUser(context, "admin@abv.bg", "123", "Pesho", "Pashov", "ul. Tintiava");
                this.SetRoleToUser(context, "admin@abv.bg", "Admin");
                var categoryNike = new Category()
                {
                    Title = "NIKE"
                }; var categoryAdidas = new Category()
                {
                    Title = "ADIDAS"
                }; var categoryPuma = new Category()
                {
                    Title = "PUMA"
                };
                context.Categories.AddOrUpdate(cat => cat.Title, categoryNike, categoryAdidas, categoryPuma);
                context.SaveChanges();
            }
           
        }

        private void CreateRole(MarketplaceContext context, string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var result = roleManager.Create(new IdentityRole(roleName));

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(";", result.Errors));
            }
        }

        private void CreateUser(MarketplaceContext context, string email, string password, string firstName, string lastName, string address)
        {
            // Create user manager
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // Set user manager password validator
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 1,
                RequireDigit = false,
                RequireLowercase = false,
                RequireNonLetterOrDigit = false,
                RequireUppercase = false,
            };

            // Create user object
            var admin = new ApplicationUser
            {
                UserName = email,
                Email = email,
                Firstname = firstName,
                LastName = lastName,
                Address = address
            };
            // Create user
            var result = userManager.Create(admin, password);
            // Validate result
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(";", result.Errors));
            }

        }

        private void SetRoleToUser(MarketplaceContext context, string email, string role)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = context.Users.First(u => u.Email == email);

            var result = userManager.AddToRole(user.Id, role);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(";", result.Errors));
            }
        }
    }
}
