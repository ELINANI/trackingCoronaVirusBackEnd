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
    public class NiveauController: ControllerBase
    {
          private readonly appliactionDbContext appliactionDbContext;
       
         public NiveauController(appliactionDbContext appliactionDbContext)
         {
             this.appliactionDbContext = appliactionDbContext;
         }
         [HttpGet]
            public async Task<ActionResult<IEnumerable<Niveau>>> GetNiveau()
        {
            return await appliactionDbContext.Niveaux.ToListAsync();
        }
       

    }
}