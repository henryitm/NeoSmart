using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NeoSmart.Backend.Data;
using NeoSmart.Backend.Intertfaces;
using NeoSmart.Shared.Entities;


namespace NeoSmart.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PositionsController : GenericController<Position>
    {
        private readonly DataContext _context;

        public PositionsController(IGenericUnitOfWork<Position> unitOfWork, DataContext context) : base(unitOfWork)
        {
            _context = context;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Positions
                .Include(s => s.Coachings)
                .ToListAsync());
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var position = await _context.Positions
                .Include(s => s.Coachings)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (position == null)
            {
                return NotFound();
            }
            return Ok(position);
        }
    }
}
