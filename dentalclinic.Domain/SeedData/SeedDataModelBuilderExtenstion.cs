using dentalclinic.Common.Model.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace dentalclinic.Domain.SeedData
{
    public static class SeedDataModelBuilderExtenstion
    {
        public static void Seed(this ModelBuilder builder)
        {
          
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Admin" },
                new IdentityRole { Name = "Doctor" },
                new IdentityRole { Name = "Reception" }
            );
        }
    }
}
