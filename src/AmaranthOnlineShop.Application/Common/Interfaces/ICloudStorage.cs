using Microsoft.AspNetCore.Http;

namespace AmaranthOnlineShop.Application.Common.Interfaces
{
    public interface ICloudStorage
    {
        string Placeholder { get; }
        Task<string> UploadAsync(IFormFile file, string name);
        Task DeleteAsync(string name);
    }
}