using System.IO;

namespace Recam.Services.Interfaces;

public interface IMediaStorageService
{
    Task<string> UploadAsync(Stream fileStream, string fileName);

    Task DeleteAsync(string storagePath);

    Task<Stream> GetFileAsync(string storagePath);

    Task<Stream> GetFileStreamAsync(string storagePath);
}