using System.IO;

namespace Recam.Service.Interfaces;

public interface IBlobStorageService
{
    Task<string> UploadAsync(Stream fileStream, string fileName);

    Task<Stream> DownloadAsync(string fileName);

    Task DeleteAsync(string fileName);
}