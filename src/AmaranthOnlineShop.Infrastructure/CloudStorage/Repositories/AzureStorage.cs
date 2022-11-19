using AmaranthOnlineShop.Application.Common.Interfaces;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace AmaranthOnlineShop.Infrastructure.CloudStorage.Repositories
{
    public class AzureStorage : ICloudStorage
    {
        private readonly string _storageConnectionString;
        private readonly string _storageContainerName;

        public string Placeholder
        {
            get
            {
                BlobContainerClient containerClient = new(_storageConnectionString, _storageContainerName);
                var blobClient = containerClient.GetBlobClient("placeholder.png");
                return blobClient.Uri.OriginalString;
            }
        }

        public AzureStorage(IConfiguration configuration)
        {
            _storageConnectionString = configuration["AzureStorageConnectionString"];
            _storageContainerName = configuration["AzureStorageContainerName"];
        }

        public async Task DeleteAsync(string name)
        {
            BlobContainerClient containerClient = new(_storageConnectionString, _storageContainerName);

            var blobClient = containerClient.GetBlobClient(name);

            await blobClient.DeleteAsync();
        }

        public async Task<string> UploadAsync(IFormFile file, string name)
        {
            BlobContainerClient containerClient = new(_storageConnectionString, _storageContainerName);

            await using var stream = file.OpenReadStream();
            await containerClient.UploadBlobAsync(name, stream);

            return containerClient.Uri.OriginalString + "/" + name;
        }
    }
}