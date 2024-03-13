using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Application.Service
{
    public interface IUploadFileService
    {
        Task<string> UploadFile(IFormFile file);
    }
}
