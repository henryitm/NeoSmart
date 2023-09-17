using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NeoSmart.Backend.Data;
using NeoSmart.Backend.Intertfaces;
using NeoSmart.Shared.Entities;

namespace NeoSmart.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CapacitationsController : GenericController<Capacitation>
    {
        private readonly DataContext _context;
        public CapacitationsController(IGenericUnitOfWork<Capacitation> unitOfWork, DataContext context) : base(unitOfWork)
        {
            _context = context;
        }

    }
}
