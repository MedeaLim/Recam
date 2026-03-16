using Recam.Services.Interfaces;

namespace Recam.Services.Services;

public class LocalMediaStorageService : IMediaStorageService
{
    private readonly string _basePath;

    public LocalMediaStorageService()
    {
        _basePath = Path.Combine(Directory.GetCurrentDirectory(), "media");

        if (!Directory.Exists(_basePath))
        {
            Directory.CreateDirectory(_basePath);
        }
    }

    public async Task<string> UploadAsync(Stream fileStream, string fileName)
    {
        var filePath = Path.Combine(_basePath, fileName);

        using var file = new FileStream(filePath, FileMode.Create);
        await fileStream.CopyToAsync(file);

        return filePath;
    }

    public async Task DeleteAsync(string storagePath)
    {
        if (File.Exists(storagePath))
        {
            await Task.Run(() => File.Delete(storagePath));
        }
    }

    public async Task<Stream> GetFileAsync(string storagePath)
    {
        return await Task.FromResult<Stream>(
            new FileStream(storagePath, FileMode.Open, FileAccess.Read)
        );
    }
}