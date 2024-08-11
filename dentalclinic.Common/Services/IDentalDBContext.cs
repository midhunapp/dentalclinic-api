using dentalclinic.Common.Model.Domain;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dentalclinic.Common.Services
{
    public interface IDentalDBContext:IDisposable
    {
        DbSet<Nationality> Nationalities { get; set; }
        DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

    }
}
