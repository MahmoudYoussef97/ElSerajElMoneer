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
    [Route("api/[controller]")]
    public class TaghredatElSeraController : ControllerBase
    {
        private readonly ITaghredatElSeraService _taghredatElSeraService;
        private readonly ILogger<TaghredatElSeraController> _logger;
        public TaghredatElSeraController(ILogger<TaghredatElSeraController> logger, ITaghredatElSeraService
            taghredatElSeraService)
        {
            _taghredatElSeraService = taghredatElSeraService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] TaghredatParametersDto taghredatParametersDto)
        {
            _logger.LogInformation($"---------- GET {Request.Path} -> Recieving a Request From:{Request.Host.Host}, Query Paramters:{Request.QueryString.Value} ----------");
            try
            {
                var taghredat = await _taghredatElSeraService.GetAllPagedTaghredatAsync(taghredatParametersDto);

                _logger.LogInformation($"---------- All Taghredat Are Fetched Successfully ----------");

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(taghredat.MetaData));

                _logger.LogInformation($"---------- X-Pagination Header Is Applied Succesfully ----------");
                _logger.LogInformation($"---------- Response Code: 200 OK Succesfully Sent ----------");

                return Ok(taghredat);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Exception: {ex.ToString()}");
            }
            return StatusCode(500);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            _logger.LogInformation($"---------- GET {Request.Path} -> Recieving a Request From:{Request.Host.Host} ----------");

            try
            {
                var taghreda = await _taghredatElSeraService.GetTaghredaByIdAsync(id);
                if (taghreda == null)
                    return BadRequest();

                _logger.LogInformation($"---------- Taghreda is Fetched Succesfully ----------");

                await UpdateCounter(id, "watch");

                _logger.LogInformation($"---------- Watch Counter is Updated ----------");
                _logger.LogInformation($"---------- Response Code: 200 OK Succesfully Sent ----------");

                return Ok(taghreda);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Exception: {ex.ToString()}");
            }
            return StatusCode(500);
        }
        [HttpPost("updateCounter/{id}")]
        public async Task UpdateCounter(string id, [FromBody] string counterType)
        {
            var counter = GetTypeOfCounter(counterType);
            await _taghredatElSeraService.UpdateCounterAsync(counter, id);
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
