using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Catalog.RepositoryContracts;
using Catalog.ProductFiles;
using System;
using Microsoft.EntityFrameworkCore;
using CatalogInfrastructure;
using System.Threading.Tasks;
using CatalogApi.ProductFiles;

namespace CatalogApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilesController : ControllerBase
    {
        private readonly ILogger<FilesController> _logger;
        private readonly IFilesRepository _filesRepository;

        public FilesController(ILogger<FilesController> logger, 
            IFilesRepository filesRepository)
        {
            _logger = logger;
            _filesRepository = filesRepository;
        }

        [HttpPost]
        public IActionResult Post(ProductFileDto file)
        {
            try
            {
                _filesRepository.AddFile(
                    new ProductFile { FileName = file.FileName, FileExtension = file.FileExtension }
                );
                return Ok("The new file was successfully uploaded.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
