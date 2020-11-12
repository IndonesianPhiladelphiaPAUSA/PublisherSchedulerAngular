using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PublisherScheduler.Helpers
{
    public interface ICommon
    {
        Task<string> SaveFileAsync(IFormFile formFile);
    }

    public class Common : ICommon
    {
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Common(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            _env = env;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> SaveFileAsync(IFormFile formFile)
        {
            string fileName = "";
            try
            {
                var httpRequest = _httpContextAccessor.HttpContext.Request;

                if (formFile.Length > 0)
                {
                    string filePath = Path.Combine(_env.WebRootPath, "Photos", formFile.FileName);

                    using (var inputStream = new FileStream(filePath, FileMode.Create))
                    {
                        // read file to stream
                        await formFile.CopyToAsync(inputStream);
                        // stream to byte array
                        byte[] array = new byte[inputStream.Length];
                        inputStream.Seek(0, SeekOrigin.Begin);
                        inputStream.Read(array, 0, array.Length);
                        // get file name
                        string fName = formFile.FileName;
                    }

                    fileName = formFile.FileName;
                }
            }
            catch (Exception)
            {
                throw;
            }
            
            return fileName;
        }
    }
}
