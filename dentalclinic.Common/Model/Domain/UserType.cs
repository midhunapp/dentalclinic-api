using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dentalclinic.Common.Model.Domain
{
    public class UserType
    {
        
        [Column(TypeName = "Int")]
        public Int32 UserTypeId { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string UserTypeName { get; set; }
        public ICollection<ApplicationUser>? ApplicationUser { get; set; }

    }
}
