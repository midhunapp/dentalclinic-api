using dentalclinic.Common.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using dentalclinic.Common.Model.Domain;
using Microsoft.AspNetCore.Identity;


namespace dentalclinic.Domain.Repository
{
    public class DentalDBContext : IdentityDbContext<ApplicationUser>, IDentalDBContext
    {
        public DentalDBContext(DbContextOptions<DentalDBContext> options)
            : base(options)
        {
        }

        public DbSet<Nationality> Nationalities { get; set; }
        //public override void Dispose()
        //{
        //    throw new NotImplementedException();
        //}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

          
            //builder.Entity<IdentityRole>().HasData(
            //    new IdentityRole { Name = "admin" },
            //    new IdentityRole { Name = "doctor" },
            //    new IdentityRole { Name = "reception" }
            //);
        }
    }
}
