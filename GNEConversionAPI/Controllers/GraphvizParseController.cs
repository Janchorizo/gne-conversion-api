﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GNEConversionAPI.Models;
using GNEConversionAPI.Services.Graphviz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GNEConversionAPI.Controllers
{
    [Route("parse")]
    [ApiController]
    public class GraphvizParseController : ControllerBase
    {
        public GraphvizParseController(GraphvizService graphvizService)
        {
            this.graphvizService = graphvizService;
        }
        public GraphvizService graphvizService { get; set; }
        private string GetRequestSVG() {
            var formFiles = HttpContext.Request.Form.Files;
            bool filePresent = formFiles.Count == 1
                && formFiles[0].Name == "doc"
                && formFiles[0].ContentType == "image/svg+xml";
            if (filePresent == false)
            {
                return null;
            }

            try
            {
                var file = (FormFile)formFiles[0];
                var result = new StringBuilder();
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    while (reader.Peek() >= 0)
                        result.AppendLine(reader.ReadLine());
                }
                return result.ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }
        [HttpPost]
        public Network Get()
        {
            try
            {
                string nodeString = HttpContext.Request.Form["node"];
                var nodeDescription = JsonSerializer.Deserialize<SVGNodeDescription>(
                    nodeString,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                string linkString = HttpContext.Request.Form["link"];
                var linkDescription = JsonSerializer.Deserialize<SVGNodeDescription>(
                    linkString,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                var svgFile = GetRequestSVG();
                if (svgFile == null)
                {
                    throw new System.Net.Http.HttpRequestException("Request not containing a valid svg file.");
                }

                var network = this.graphvizService.ParseSVG(svgFile, nodeDescription, linkDescription);
                return network;
            }
            catch (Exception e)
            {
                return new Network();
            }
        }
    }
}
