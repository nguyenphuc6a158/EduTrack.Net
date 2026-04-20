using Abp.Application.Services;
using Abp.UI;
using EduTrack.AppServices.Files.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public class FileAppService : ApplicationService, IFileAppService
{
    private readonly IWebHostEnvironment _env;

    public FileAppService(IWebHostEnvironment env)
    {
        _env = env;
    }
    [HttpDelete]
    public void DeleteFile(string fileUrl)
    {
        if (string.IsNullOrEmpty(fileUrl))
        {
            throw new UserFriendlyException("File không hợp lệ");
        }

        // convert URL → path vật lý
        var filePath = Path.Combine(
            _env.WebRootPath,
            fileUrl.TrimStart('/') // bỏ dấu /
        );

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<UploadFileOutput> UploadFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            throw new UserFriendlyException("File không hợp lệ");
        }

        var allowedExtensions = new[] { ".pdf" };
        var ext = Path.GetExtension(file.FileName)?.ToLowerInvariant();

        if (!allowedExtensions.Contains(ext))
        {
            throw new UserFriendlyException("Chỉ cho phép file PDF");
        }

        var folder = Path.Combine(_env.WebRootPath, "uploads");

        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }

        var originalName = Path.GetFileNameWithoutExtension(file.FileName);

        var fileName = $"{originalName}_{Guid.NewGuid()}{ext}";

        var filePath = Path.Combine(folder, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return new UploadFileOutput
        {
            Url = "/uploads/" + fileName
        };
    }
}