using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using trackingCoronaVirusBackEnd2.models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
namespace trackingCoronaVirusBackEnd2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("corsPolicy")]   
    public class QuartierController: ControllerBase
    {
         private readonly appliactionDbContext appliactionDbContext;
         public QuartierController(appliactionDbContext appliactionDbContext)
         {
             this.appliactionDbContext = appliactionDbContext;
         }
          [HttpGet]
        public async Task<ActionResult<IEnumerable<Quartier>>> GetClient()
        {
            return await appliactionDbContext.Quartiers.ToListAsync();
        }
    }
}