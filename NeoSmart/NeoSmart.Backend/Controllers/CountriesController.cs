using Microsoft.AspNetCore.Mvc;
using NeoSmart.Shared.Entities;
using NeoSmart.Backend.Intertfaces;

namespace Sales.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : GenericController<Country>
    {
        public CountriesController(IGenericUnitOfWork<Country> unitOfWork) : base(unitOfWork)
        {
        }
    }
}