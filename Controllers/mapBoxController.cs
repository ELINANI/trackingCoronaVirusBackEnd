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

    public class mapBoxController:ControllerBase
    {
        private readonly appliactionDbContext appliactionDbContext;
        public mapBoxController(appliactionDbContext appliactionDbContext)
        {
            this.appliactionDbContext = appliactionDbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<mapBox>> getAll(){
            var mapBox =  from c in appliactionDbContext.Clients 
                          join con in appliactionDbContext.contaminations
                          on c.codeClient equals con.codeClient
                          join q in appliactionDbContext.Quartiers
                          on c.codeQuartier equals q.codeQuartier 
                          group  new {c,con,q} by new {q.codeQuartier,q.lat,q.lng,q.nomQuartier} into x
                               select new mapBox{
                                  nombreCas= x.Count(), 
                                  nom= x.Key.nomQuartier,
                                  lat= x.Key.lat,
                                  lng= x.Key.lng
                               };                                                     
                return mapBox ;                
                         }            
        }       
    }