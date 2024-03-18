using System.ComponentModel.DataAnnotations;

namespace BirthdayParty.Domain.Payload.Request.UploadFile;

public class UploadFileRequest
{
    [Required]
    public Microsoft.AspNetCore.Http.IFormFile File { get; set; }
}