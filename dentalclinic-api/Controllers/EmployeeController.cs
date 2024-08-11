using dentalclinic.Common.Model.Domain;
using dentalclinic.Common.Services;
using dentalclinic_api.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dentalclinic_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IDentalDBContext _dbContext;
        public EmployeeController(IDentalDBContext dbContext)
        {
            _dbContext = dbContext;
        }
       
    }
}
