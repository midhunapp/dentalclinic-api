using dentalclinic.Common.Model.Domain;
using dentalclinic.Common.Services;
using dentalclinic.Domain.Repository;
using dentalclinic_api.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dentalclinic_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly IDentalDBContext _dbContext;
        public CommonController(IDentalDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        [Route("Nationalities")]
        public async Task<IEnumerable<SelectListModelInt>> GetNationalities()
        {
            return _dbContext.Nationalities.Select(x => new SelectListModelInt { Id = x.NationalityId, Name = x.NationalityName }).ToList();

        }
        [HttpGet]
        [Route("user-types")]
        public async Task<IEnumerable<SelectListModelInt>> GetUserTypes()
        {
            return _dbContext.UserTypes.Select(x => new SelectListModelInt { Id = x.UserTypeId, Name = x.UserTypeName }).ToList();

        }
    }
}
