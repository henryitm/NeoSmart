using Microsoft.AspNetCore.Mvc;
using NeoSmart.Backend.Intertfaces;
using NeoSmart.Shared.Entities;

namespace NeoSmart.Backend.Controllers 
{

        [ApiController]
        [Route("api/[controller]")]
        public class UsersController : GenericController<User>
        {
            public UsersController(IGenericUnitOfWork<User> unitOfWork) : base(unitOfWork)
            {
            }
        }

    
}
