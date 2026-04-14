using Microsoft.AspNetCore.Http;

public class FileUploadService
{
    private readonly IWebHostEnvironment _env;

    public FileUploadService(IWebHostEnvironment env)
    {
        _env = env;
    }

    public string SaveImage(IFormFile file)
    {
        if (file == null || file.Length == 0)
            throw new Exception("File is empty");

        if (_env.WebRootPath == null)
            throw new Exception("wwwroot not found");

        var path = Path.Combine(_env.WebRootPath, "uploads");
        Directory.CreateDirectory(path);

        var fileName = Guid.NewGuid() + "_" + Path.GetFileName(file.FileName);
        var fullPath = Path.Combine(path, fileName);

        using var stream = new FileStream(fullPath, FileMode.Create);
        file.CopyTo(stream);

        return "/uploads/" + fileName;
    }
}