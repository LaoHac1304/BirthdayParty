using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BirthdayParty.Application.Repository.Common;
using BirthdayParty.Application.Service;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace BirthdayParty.Services.Service
{
    public class UploadFileService : BaseService<UploadFileService>, IUploadFileService
    {
        private readonly IHttpClientFactory _clientFactory;

        public UploadFileService(IUnitOfWork unitOfWork, ILogger<UploadFileService> logger, IMapper mapper
            , IHttpContextAccessor httpContextAccessor, IHttpClientFactory clientFactory) 
            : base(unitOfWork, logger, mapper, httpContextAccessor)
        {
            _clientFactory = clientFactory;
        }

        public async Task<string> UploadFile(IFormFile file)
        {

            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File is null or empty.");
            }

            using var multipartContent = new MultipartFormDataContent();
            using var fileStream = file.OpenReadStream();
            using var streamContent = new StreamContent(fileStream);

            streamContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            multipartContent.Add(streamContent, "file", file.FileName);

            var _httpClient = _clientFactory.CreateClient();


            var response = await _httpClient.PostAsync("https://api-test.kidtalkie.tech/api/file-upload/upload", multipartContent);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"File upload failed with status code {response.StatusCode}.");
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            // Here you would parse the responseContent to get the URL or name
            // This depends on how the JSON is structured in your actual response
            // For example, you might use Json.NET (Newtonsoft.Json) like this:
            var responseObject = JsonConvert.DeserializeObject<UploadResponse>(responseContent);
            // return responseObject.Url;
            return responseObject.Url; // Or return the URL/name as per your parsing

        }
    }
    public class UploadResponse
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
