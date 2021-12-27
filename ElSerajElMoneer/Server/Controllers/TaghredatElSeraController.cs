using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ElSerajElMoneer.Shared;
using ElSerajElMoneer.Core.Services;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using ElSerajElMoneer.Server.Dtos;
using Newtonsoft.Json;

namespace ElSerajElMoneer.Server.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TaghredatElSeraController : ControllerBase
    {
        private readonly ITaghredatElSeraService _taghredatElSeraService;
        private readonly ILogger<TaghredatElSeraController> _logger;
        private readonly IWebHostEnvironment _webHostingEnvironment;
        public TaghredatElSeraController(ILogger<TaghredatElSeraController> logger, ITaghredatElSeraService
            taghredatElSeraService, IWebHostEnvironment webHostingEnvironment)
        {
            _taghredatElSeraService = taghredatElSeraService;
            _logger = logger;
            _webHostingEnvironment = webHostingEnvironment;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] TaghredatParametersDto taghredatParametersDto)
        {
            var taghredat = await _taghredatElSeraService.GetAllTaghredatAsync(taghredatParametersDto);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(taghredat.MetaData));
            return Ok(taghredat);
        }
        [HttpGet("{id}")]
        public async Task<TaghredatElSera> Get(string id)
        {
            //Build the File Path.
            var taghreda = await _taghredatElSeraService.GetTaghredaById(id);
            if (taghreda == null)
                return null;

            await UpdateCounter(id, "watch");
            return taghreda;
        }
        [HttpPost("updateCounter/{id}")]
        public async Task UpdateCounter(string id, [FromBody] string counterType)
        {
            var counter = GetTypeOfCounter(counterType);
            await _taghredatElSeraService.UpdateCounter(counter, id);
        }
        [HttpGet("download/{fileName}")]
        public async Task<IActionResult> Download(string fileName)
        {
            //Build the File Path.
            string currentDirectory = "/Users/mahyoussef/projects/ElSerajElMoneer/ElSerajElMoneer/Client/wwwroot/";
            string path = Path.Combine(currentDirectory, "taghredat/") + fileName + ".mp4";
            try
            {   
                PhysicalFileResult result = PhysicalFile(path, "application/octet-stream", fileName+".mp4");
                await UpdateCounter(fileName, "download");
                return result;
            }
            catch
            {
                return BadRequest();
            }
        }
        private Counter GetTypeOfCounter(string counter)
        {
            return counter.ToLower().Equals("download") ? Counter.DownloadCounter : Counter.WatchCounter;
        }
    }
}
