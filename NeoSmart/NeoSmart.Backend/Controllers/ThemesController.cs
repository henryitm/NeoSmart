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
    public class ThemesController : GenericController<Theme>
    {
        private readonly DataContext _context;

        public ThemesController(IGenericUnitOfWork<Theme> unitOfWork, DataContext context) : base(unitOfWork)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet("[action]")]
        public async Task<ActionResult> GetCombo()
        {
            return Ok(await _context.Themes.ToListAsync());
        }
    }
}
