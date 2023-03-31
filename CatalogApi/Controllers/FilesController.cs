using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Catalog.RepositoryContracts;
using Catalog.ProductFiles;
using System;

namespace CatalogApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilesController : ControllerBase
    {
        private readonly ILogger<FilesController> _logger;
        private readonly IFilesRepository _filesRepository;

        public FilesController(ILogger<FilesController> logger, IFilesRepository filesRepository)
        {
            _logger = logger;
            _filesRepository = filesRepository;
        }

        [HttpPost]
        public IActionResult Post()
        {
            try
            {
                _filesRepository.AddFile(new ProductFile { FileName = "File uploaded from client", FileExtension = FileExtensions.Json });
                return Ok("The new file was successfully uploaded.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
