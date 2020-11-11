using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FileUploadAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileUploadController : ControllerBase
    {
        private readonly ILogger<FileUploadController> _logger;
        private readonly IWebHostEnvironment _environment;

        public FileUploadController(ILogger<FileUploadController> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment ?? throw new 
                ArgumentNullException(nameof(environment));
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            try
            {
                var httpRequest = HttpContext.Request;

                if (httpRequest.Form.Files.Count > 0)
                {
                    foreach (var file in httpRequest.Form.Files)
                    {
                        var filePath = Path.Combine(_environment.ContentRootPath, "uploads");

                        if (!Directory.Exists(filePath))
                            Directory.CreateDirectory(filePath);

                        using (var memoryStream = new MemoryStream())
                        {
                            await file.CopyToAsync(memoryStream);
                            System.IO.File.WriteAllBytes(
                                Path.Combine(filePath, $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}"), memoryStream.ToArray());
                        }

                        return Ok();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return new StatusCodeResult(500);
            }

            return BadRequest();
        }
    }
}
