using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using trackingCoronaVirusBackEnd2.models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace trackingCoronaVirusBackEnd2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("corsPolicy")] 
    public class hopitalProfile:ControllerBase
    {
        private readonly appliactionDbContext appliactionDbContext ;
        public hopitalProfile(appliactionDbContext appliactionDbContext)
        {
          this.appliactionDbContext = appliactionDbContext;   
        }
        [HttpGet]
        [Authorize]
        public async Task<Object> gethopitaleProfile(){
            string codeHopitale = User.Claims.First(c => c.Type == "codeHopitale").Value;
            var hopitale = await appliactionDbContext.Hopitaux.FindAsync(codeHopitale);
            return new {
                     hopitale.nomHopitale,
                     hopitale.phoneHopitale
                       };
        }
        
    }
}