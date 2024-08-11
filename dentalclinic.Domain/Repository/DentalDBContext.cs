using dentalclinic.Common.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using dentalclinic.Common.Model.Domain;
using Microsoft.AspNetCore.Identity;
using dentalclinic.Domain.SeedData;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dentalclinic.Domain.Repository
{
    public class DentalDBContext : IdentityDbContext<ApplicationUser>, IDentalDBContext
    {
        public DentalDBContext(DbContextOptions<DentalDBContext> options)
            : base(options)
        {
        }
       

        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        //public override void Dispose()
        //{
        //    throw new NotImplementedException();
        //}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            


           
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().Property(u => u.UserRegNo).UseIdentityColumn();
            builder.Entity<ApplicationUser>().Property(u => u.UserRegNo).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);


            builder.Seed();

          
            //builder.Entity<IdentityRole>().HasData(
            //    new IdentityRole { Name = "admin" },
            //    new IdentityRole { Name = "doctor" },
            //    new IdentityRole { Name = "reception" }
            //);
        }
    }
}
