using Recam.Service.Interfaces;

namespace Recam.Service.Services;

public class AzureBlobStorageService : IBlobStorageService
{
    public Task<string> UploadAsync(Stream fileStream, string fileName)
    {
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