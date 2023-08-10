using FetchFood.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FetchFood.WebApi.Controllers.Core
{
    [ApiController]
    [Route("api/core")]
    public class Restaurat : ControllerBase
    {
        private readonly CoreDbContext _coreContext;
        private readonly FetchFoodDbContext _fetchfoodContext;

        public Restaurat(CoreDbContext coreContext, FetchFoodDbContext fetchfoodContext)
        {
            _coreContext = coreContext;
            _fetchfoodContext = fetchfoodContext;
        }


        [HttpPost]
        [Route("UpdateRestaurat")]
        public IActionResult RunRestaurantMigration()
        {
            _fetchfoodContext.Database.Migrate();
            return Ok();
        }
    }
}
