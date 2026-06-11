using Microsoft.AspNetCore.Components.Forms;

namespace KusinaKanto.Services;

public interface IImageService
{
    Task<string> UploadMenuImageAsync(IBrowserFile file);
}