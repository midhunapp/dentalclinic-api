using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dentalclinic.Common.Model.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 UserRegNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Int32 NationalityId { get; set; }
        public Int32 UserTypeId { get; set; }
        public string? Designation { get; set; }
        public string? Moh { get; set; }
        public Nationality Nationality { get; set; }
        public UserType UserType { get; set; }

    }
}
