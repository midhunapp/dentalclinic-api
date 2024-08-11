using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dentalclinic.Common.Model.Domain
{
    public class Nationality
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "Int")]
        public Int32 NationalityId { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string NationalityName { get; set;}
        [Column(TypeName = "varchar(20)")]
        public string NationalityCode { get; set; }

        public int IsActive { get; set; }

        public ICollection<ApplicationUser>? ApplicationUser { get; set; }
    }
}
