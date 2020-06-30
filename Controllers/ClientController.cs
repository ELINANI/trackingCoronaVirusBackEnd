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
    public class ClientController: ControllerBase
    {
        private readonly appliactionDbContext appliactionDbContext;
        public ClientController(appliactionDbContext appliactionDbContext)
        {
            this.appliactionDbContext = appliactionDbContext;
        }
        // GET: api/Client
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClient()
        {
            return await appliactionDbContext.Clients.ToListAsync();
        }

        // GET: api/Client/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(string id)
        {
            var client = await appliactionDbContext.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/Client/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(string id,Client client)
        {
            if (id != client.codeClient)
            {
                return BadRequest();
            }

            appliactionDbContext.Entry(client).State = EntityState.Modified;

            try
            {
                await appliactionDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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
         // POST: api/Client
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            appliactionDbContext.Clients.Add(client);
            await appliactionDbContext.SaveChangesAsync();
            return null;
        }
        // DELETE: api/Client/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> DeleteClient(string id)
        {
            var client = await appliactionDbContext.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            appliactionDbContext.Clients.Remove(client);
            await appliactionDbContext.SaveChangesAsync();

            return client;
        }
        private bool ClientExists(string id)
        {
            return appliactionDbContext.Clients.Any(e => e.codeClient == id);
        }
    }
}