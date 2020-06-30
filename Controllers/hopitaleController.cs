using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using trackingCoronaVirusBackEnd2.models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;

namespace trackingCoronaVirusBackEnd2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("corsPolicy")]   
    public class hopitaleController:ControllerBase
    {
        private readonly appliactionDbContext appliactionDbContext;
        private readonly applicationSettings applicationSettings;
        public hopitaleController(appliactionDbContext appliactionDbContext,IOptions<applicationSettings> applicationSettings)
        {
            this.appliactionDbContext =appliactionDbContext;
            this.applicationSettings = applicationSettings.Value;  
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hopitale>>> GetHopitale()
        {
            return await appliactionDbContext.Hopitaux.ToListAsync();
            
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> logins(loginModel model){
           var hop = await appliactionDbContext.Hopitaux.FindAsync("1");
             if(hop != null && hop.pwdHopitale==model.pwd && hop.loginHopitale ==model.login ){
               var tokenDiscriptor = new SecurityTokenDescriptor{
                     Subject = new ClaimsIdentity(new Claim[]{
                          new Claim("codeHopitale",hop.codeHopitale.ToString())
                          
                     }),
                     Expires = DateTime.UtcNow.AddDays(1),
                     SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(applicationSettings.JWTtoken)),SecurityAlgorithms.HmacSha256Signature)
               };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDiscriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new {token});
             }
            
             else
                  return BadRequest(new {message = "login or pwd incorrect"});
        }

   
    }
}