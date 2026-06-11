using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Components.Forms;

namespace KusinaKanto.Services;

public class ImageService : IImageService
{
    private readonly IWebHostEnvironment _environment;

    public ImageService(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public async Task<string> UploadMenuImageAsync(IBrowserFile file)
    {
        if (file == null)
            throw new ArgumentNullException(nameof(file));

        var uploadsFolder = Path.Combine(
            _environment.WebRootPath,
            "uploads",
            "menu");

        Directory.CreateDirectory(uploadsFolder);

        var extension = Path.GetExtension(file.Name);

        var fileName = $"{Guid.NewGuid()}{extension}";

        var filePath = Path.Combine(uploadsFolder, fileName);

        await using var stream = new FileStream(
            filePath,
            FileMode.Create);

        await file.OpenReadStream(
                maxAllowedSize: 10 * 1024 * 1024)
            .CopyToAsync(stream);

        return $"/uploads/menu/{fileName}";
    }
}