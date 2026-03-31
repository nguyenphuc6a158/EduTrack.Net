using Microsoft.AspNetCore.Http;

namespace EduTrack.AppServices.Files.Dtos
{
    public class UploadFileDto
    {
        public IFormFile File { get; set; }
    }
}