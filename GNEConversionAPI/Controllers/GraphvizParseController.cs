using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using GNEConversionAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GNEConversionAPI.Controllers
{
    [Route("parse")]
    [ApiController]
    public class GraphvizParseController : ControllerBase
    {
        [HttpPost]
        public string Get()
        {
            try
            {
                string nodeString = HttpContext.Request.Form["node"];
                var node = JsonSerializer.Deserialize<SVGNodeDescription>(
                    nodeString,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                string linkString = HttpContext.Request.Form["link"];
                var link = JsonSerializer.Deserialize<SVGNodeDescription>(
                    linkString,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return node.Xpath + link.Xpath;
            }
            catch (Exception e)
            {
                var status = new Dictionary<string, bool>(){
                    { "error", true }
                };
                var json = JsonSerializer.Serialize<Dictionary<string, bool>>(status);
                return json;
            }
        }
    }
}
