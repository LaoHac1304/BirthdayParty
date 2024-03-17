using BirthdayParty.Application.Service;
using BirthdayParty.Domain.Payload.Request.UploadFile;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayParty.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FileUploaderController : BaseController<FileUploaderController>
    {
        private readonly IUploadFileService _uploadFileService;
        public FileUploaderController(ILogger<FileUploaderController> logger, IUploadFileService uploadFileService) : base(logger)
        {
            _uploadFileService = uploadFileService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] UploadFileRequest request)
        {
            if(request.File == null) { return BadRequest(ModelState); }
            try
            {
                var fileUrl = await _uploadFileService.UploadFile(request.File);
                return Ok(new
                {
                    url = fileUrl,
                });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
