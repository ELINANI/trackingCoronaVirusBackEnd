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
    public class nombreCasController:ControllerBase
    {
        private readonly appliactionDbContext appliactionDbContext ;
        public nombreCasController(appliactionDbContext appliactionDbContext)
        {
            this.appliactionDbContext = appliactionDbContext ;
        }
         
        [Route("[action]")]

         public async Task<ActionResult<IEnumerable<nombreParNiveaux>>> nombreParNiveaux()
        { 
            var tt = await (from n in appliactionDbContext.Niveaux 
                            join c in appliactionDbContext.contaminations on n.codeNiveau equals c.codeNiveau 
                             group new {c,n} by new {c.codeNiveau,n.typeNiveau} into x 
                            select new nombreParNiveaux {
                                typeNiveau  = x.Key.typeNiveau ,
                                nombre = x.Count()
                     } ).ToListAsync();

            return tt ;
        }
         [Route("[action]")]
         public async Task<ActionResult<IEnumerable<nombreParSexe>>> nombreParSexe()
        { int femme = 0 ;
          int homme = 0 ;
            List<nombreParSexe> nbr = new List<nombreParSexe>();
             var tt = await( from c in appliactionDbContext.Clients 
                            join con in appliactionDbContext.contaminations
                            on c.codeClient equals con.codeClient
                             group new {c,con} by new {c.sexeClient,con.codeClient} into x 
                            select new nombreParSexe {
                              sexeClient = x.Key.sexeClient ,
                              nombre = x.Count()
                            }
                            
                            ).ToListAsync();

                    foreach (var item in tt)
                    {
                        if(item.sexeClient.Equals("Homme")){
                            homme++;
                        }
                        else{
                            femme++;
                        }
                    }
                    nombreParSexe nps1 = new nombreParSexe{
                          sexeClient = "Homme",
                          nombre=homme
                    };
                      nombreParSexe nps2= new nombreParSexe{
                          sexeClient = "Femme",
                          nombre=femme
                    };
                 nbr.Add(nps1);
                 nbr.Add(nps2);
            return nbr;
        }


    }
}