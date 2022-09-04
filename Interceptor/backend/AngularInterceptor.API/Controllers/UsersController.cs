using CsvHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;

namespace AngularInterceptor.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IJWTAuthenticationManager jWTAuthenticationManager;

        public UsersController(IJWTAuthenticationManager jWTAuthenticationManager)
        {
            this.jWTAuthenticationManager = jWTAuthenticationManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login([FromBody] UserDTO user)
        {
            var token = jWTAuthenticationManager.Authenticate(user.username, user.password);
            if(token == null)
            {
                return Unauthorized();
            }
            return Ok(new { token = token });
        }

        [HttpGet]
        public ActionResult Get()
        {
            var obj = new List<object>
            {
               new { id = 1, name = "Vildan", lastname = "Cuturic" },
            };

            using (var mr = new MemoryStream())
            {
                using (var sr = new StreamWriter(mr))
                {
                    using (var csv = new CsvWriter(sr, CultureInfo.InvariantCulture))
                    {
                        csv.WriteRecords(obj);
                        csv.NextRecord();
                    }
                }
                return File(mr.ToArray(), "text/csv");
            }
        }
    }
}
