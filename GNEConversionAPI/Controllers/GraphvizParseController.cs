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
        private FormFile GetRequestSVG() {
            var formFiles = HttpContext.Request.Form.Files;
            bool filePresent = formFiles.Count == 1
                && formFiles[0].Name == "doc"
                && formFiles[0].ContentType == "image/svg+xml";
            if (filePresent == true)
            {
                return (FormFile)formFiles[0];
            } else
            {
                return null;
            }
        }

        [HttpPost]
        public Dictionary<string, string> Get()
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
                var svgFile = GetRequestSVG();
                if (svgFile == null)
                {
                    throw new System.Net.Http.HttpRequestException("Request not containing a valid svg file.");
                }

                var response = new Dictionary<string, string>() {
                    {"node_xpath", node.Xpath},
                    {"link_xpath", link.Xpath},
                    {"svg_size", svgFile.Length.ToString()},
                };
                return response;
            }
            catch (Exception e)
            {
                var error = new Dictionary<string, string>(){
                    { "error", e.Message }
                };
                return error;
            }
        }
    }
}
