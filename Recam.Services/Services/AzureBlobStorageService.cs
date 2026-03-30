using Recam.Service.Interfaces;
using Azure.Storage.Blobs;

namespace Recam.Service.Services;

public class AzureBlobStorageService : IBlobStorageService
{
    public Task<string> UploadAsync(Stream fileStream, string fileName)
    {
        var blobServiceClient = new BlobServiceClient("你的ConnectionString");

        var containerClient = blobServiceClient.GetBlobContainerClient("recam-media");

        throw new NotImplementedException();
    }

    public Task<Stream> DownloadAsync(string fileName)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string fileName)
    {
        throw new NotImplementedException();
    }
}