using Microsoft.AspNetCore.Mvc;
using NeoSmart.Backend.Intertfaces;
using NeoSmart.Shared.Entities;

namespace NeoSmart.Backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CapacitationsThemesController : GenericController<CapacitationTheme>
    {
        public CapacitationsThemesController(IGenericUnitOfWork<CapacitationTheme> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
