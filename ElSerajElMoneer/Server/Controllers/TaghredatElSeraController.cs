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
using ElSerajElMoneer.Data.Dtos;

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
        [HttpGet("{id}", Name = "GetTaghreda")]
        public async Task<IActionResult> Get(string id)
        {
            _logger.LogInformation($"---------- GET {Request.Path} -> Recieving a Request From:{Request.Host.Host} ----------");

            try
            {
                var taghreda = await _taghredatElSeraService.GetTaghredaByIdAsync(id);
                if (taghreda == null)
                    return BadRequest();

                _logger.LogInformation($"---------- Taghreda is Fetched Succesfully ----------");

                await _taghredatElSeraService.UpdateCounterAsync("watch", id);

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
        [HttpGet("download/{id}")]
        public async Task<IActionResult> Download(string id)
        {
            _logger.LogInformation($"---------- GET {Request.Path} -> Recieving a Request From:{Request.Host.Host} ----------");
            try
            {
                var taghreda = await _taghredatElSeraService.GetTaghredaByIdAsync(id);
                if (taghreda == null)
                    return NotFound();

                _logger.LogInformation($"---------- Taghreda is Fetched Succesfully ----------");

                var result = PhysicalFile(taghreda.DownloadUrl, "application/octet-stream", id+".mp4");
                await _taghredatElSeraService.UpdateCounterAsync("download", id);

                _logger.LogInformation($"---------- Taghreda is Downloaded Succesfully ----------");
                _logger.LogInformation($"---------- Download Counter is Updated ----------");

                return result;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Exception: {ex.ToString()}");
            }
            return StatusCode(500);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaghredatElSeraCreateInputDto taghredatElSeraCreateInputDto)
        {
            _logger.LogInformation($"---------- POST {Request.Path} -> Recieving a Request From:{Request.Host.Host}, Query Paramters:{Request.Body} ----------");

            try
            {
                if (taghredatElSeraCreateInputDto == null)
                {
                    _logger.LogError($"---------- TAGHREDA SENT FROM CLIENT IS NULL ----------");
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError($"---------- INVALID TAGHREDA SENT FROM CLIENT ----------");
                    return BadRequest();
                }
                var taghreda = await _taghredatElSeraService.CreateTaghredaAsync(taghredatElSeraCreateInputDto);
                return CreatedAtRoute("GetTaghreda", new { id = taghreda.Id.ToString() }, taghreda);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Exception: {ex.ToString()}");
            }
            return StatusCode(500, "Internal Server Error");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] TaghredatElSeraCreateInputDto taghredatElSeraCreateInputDto)
        {
            _logger.LogInformation($"---------- PUT {Request.Path} -> Recieving a Request From:{Request.Host.Host}, Query Paramters:{Request.Body} ----------");

            try
            {
                var taghreda = await _taghredatElSeraService.GetTaghredaByIdAsync(id);
                if (taghreda == null)
                    return NotFound();

                _logger.LogInformation($"---------- Taghreda is Fetched Successfully ----------");

                await _taghredatElSeraService.UpdateTaghredaAsync(taghreda, taghredatElSeraCreateInputDto);

                _logger.LogInformation($"---------- Taghreda is Updated Sucessfully ----------");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception: {ex.ToString()}");
            }
            return StatusCode(500);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            _logger.LogInformation($"---------- DELETE {Request.Path} -> Recieving a Request From:{Request.Host.Host} ----------");
            try
            {
                var taghreda = await _taghredatElSeraService.GetTaghredaByIdAsync(id);
                if (taghreda == null)
                    return NotFound();

                _logger.LogInformation($"---------- Taghreda is Fetched Successfully ----------");

                await _taghredatElSeraService.DeleteTaghredaAsync(taghreda);

                _logger.LogInformation($"---------- Taghreda is Deleted Successfully ----------");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception: {ex.ToString()}");
            }
            return StatusCode(500);
        }
    }
}
