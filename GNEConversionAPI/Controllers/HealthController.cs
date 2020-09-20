using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GNEConversionAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public Dictionary<string, bool> Get()
        {
            var status = new Dictionary<string, bool>(){
                { "healthy", true }
            };
            var json = JsonSerializer.Serialize<Dictionary<string, bool>>(status);
            return status;
        }
    }
}
