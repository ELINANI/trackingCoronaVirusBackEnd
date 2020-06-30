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

    public class ContaminationController:ControllerBase
    {
        private readonly appliactionDbContext appliactionDbContext;
        public ContaminationController(appliactionDbContext appliactionDbContext)
        {
            this.appliactionDbContext = appliactionDbContext;
        }
         [HttpGet]
        public async Task<ActionResult<IEnumerable<Contamination>>> GetContamination()
        {
            return await appliactionDbContext.contaminations.ToListAsync();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContamination(string id,Contamination contamination)
        {
            if (id != contamination.codeContamination)
            {
                return BadRequest();
            }

            appliactionDbContext.Entry(contamination).State = EntityState.Modified;

            try
            {
                await appliactionDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContaminationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<Contamination>> PostContamination(Contamination contamination)
        {
            appliactionDbContext.contaminations.Add(contamination);
            await appliactionDbContext.SaveChangesAsync();
            return null;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Contamination>> DeleteClient(string id)
        {
            var ctm = await appliactionDbContext.contaminations.FindAsync(id);
            if (ctm == null)
            {
                return NotFound();
            }

            appliactionDbContext.contaminations.Remove(ctm);
            await appliactionDbContext.SaveChangesAsync();

            return ctm;
        }
        private bool ContaminationExists(string id)
        {
            return appliactionDbContext.Clients.Any(e => e.codeClient == id);
        }
    }
}