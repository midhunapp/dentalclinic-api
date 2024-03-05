using dentalclinic.Common.Model.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dentalclinic.Common.Services
{
    public interface IDentalDBContext:IDisposable
    {
       // DbSet<Nationality> Nationalitie { get; set; }
        //public DbSet<Role> Roles { get; set; }
    }
}
