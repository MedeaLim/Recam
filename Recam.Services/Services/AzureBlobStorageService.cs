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

    public async Task<Stream> DownloadAsync(string fileName)
    {
        var blobServiceClient = new BlobServiceClient("你的ConnectionString");

        var containerClient = blobServiceClient.GetBlobContainerClient("recam-media");

        var blobClient = containerClient.GetBlobClient(fileName);

        var memoryStream = new MemoryStream();

        await blobClient.DownloadToAsync(memoryStream);

        memoryStream.Position = 0;

        return memoryStream;
    }

    public Task DeleteAsync(string fileName)
    {
        throw new NotImplementedException();
    }
}