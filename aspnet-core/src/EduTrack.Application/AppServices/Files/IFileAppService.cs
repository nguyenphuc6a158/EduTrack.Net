using Abp.Application.Services;
using EduTrack.AppServices.Files.Dtos;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public interface IFileAppService : IApplicationService
{
    Task<UploadFileOutput> UploadFile(IFormFile file);
    public void DeleteFile(string fileUrl);
}