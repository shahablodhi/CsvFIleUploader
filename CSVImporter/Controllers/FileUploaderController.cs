using CSVImporter.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CSVImporter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class FileUploaderController : ControllerBase
    {

        private readonly ILogger<FileUploaderController> _logger;
        private readonly ICsvUploadService _csvUploadService;

        public FileUploaderController(ILogger<FileUploaderController> logger, ICsvUploadService csvUploadService)
        {
            _csvUploadService = csvUploadService;
            _logger = logger;
        }

        [DisableRequestSizeLimit]
        [HttpPost]
        public async Task<ResponseViewModel> Upload(IFormFile file)
        {
            try
            {
                var storedPath = await _csvUploadService.UploadFileAsync(file);
                return new ResponseViewModel
                {
                    Status = true,
                    Message = $"Data Updated Successfully, stored path " +
                    $":{storedPath}",
                    StatusCode = HttpStatusCode.OK.ToString()
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new ResponseViewModel { StatusCode = HttpStatusCode.InternalServerError.ToString() };
            }
        }

    }

}