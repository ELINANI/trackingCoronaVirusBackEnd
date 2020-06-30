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
    public class traitController:ControllerBase
    {
        private readonly appliactionDbContext appliactionDbContext;
        public traitController(appliactionDbContext appliactionDbContext)
        {
            this.appliactionDbContext = appliactionDbContext;
        }
         [HttpGet("getAllCas")]
        public async Task<ContaClient> getAllCas(){
           var  s =  appliactionDbContext.contaminations.Count();
          ContaClient ct = new ContaClient{
              nom = "Nombre De Cas Dans Kenitra",
              nombre = s
          };

          return ct;
        } 
       
        
        [HttpGet("GetHommeCas")]
        public async Task<ContaClient> GetHommeCas(){
            int i  = 0;
            var ff = from s in appliactionDbContext.Clients 
                    join co in appliactionDbContext.contaminations
                    on s.codeClient equals co.codeClient
                    where s.sexeClient ==  "Homme"
                    select new ContaClient {
                        nom = "Homme",
                        nombre = co.codeContamination.Count()
                    };
                    foreach (var item in ff)
                    {
                        i ++;
                    }
                    ContaClient c = new ContaClient{
                        nom="Homme",
                        nombre=i
                    };

            return c ;
        }
         [HttpGet("GetFemmeCas")]
        public async Task<ContaClient> GetFemmeCas(){
            int i  = 0;
            var ff =  from s in appliactionDbContext.Clients 
                    join co in appliactionDbContext.contaminations
                    on s.codeClient equals co.codeClient
                    where s.sexeClient.Equals("Femme")
                    select new ContaClient {
                        nom = "Femme",
                        nombre = co.codeContamination.Count()
                    };
                    foreach (var item in ff)
                    {
                        i++;
                    }
                    ContaClient c = new ContaClient{
                        nom="Femme",
                        nombre=i
                    };

            return c ;
        }
         [HttpGet("GetEnfantCas")]
        public async Task<ContaClient> GetEnfantCas(){
            int i  = 0;
            var ff =  from s in appliactionDbContext.Clients 
                    join co in appliactionDbContext.contaminations
                    on s.codeClient equals co.codeClient
                   select s.age;
                foreach (var item in ff)
                {
                    if(Convert.ToInt16(item)>=1 && Convert.ToInt16(item)<=18 ){
                        i++;
                    }
                }
                 ContaClient c = new ContaClient{
                        nom="Enfants",
                        nombre=i
                    };

            return c ;
        }
        [HttpGet("GetVieuxCas")]
        public async Task<ContaClient> GetVieuxCas(){
            int i  = 0;
            var ff =  from s in appliactionDbContext.Clients 
                    join co in appliactionDbContext.contaminations
                    on s.codeClient equals co.codeClient
                   select s.age;
                foreach (var item in ff)
                {
                    if(Convert.ToInt16(item)>=50 && Convert.ToInt16(item)<=100 ){
                        i++;
                    }
                }
                 ContaClient c = new ContaClient{
                        nom="Vieux",
                        nombre=i
                    };

            return c ;
        }
    }
}