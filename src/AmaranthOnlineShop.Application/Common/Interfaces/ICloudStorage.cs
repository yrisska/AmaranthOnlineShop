using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaranthOnlineShop.Application.Common.Interfaces
{
    public interface ICloudStorage
    {
        string Placeholder { get; }
        Task<string> UploadAsync(IFormFile file, string name);
        Task DeleteAsync(string name);
    }
}
