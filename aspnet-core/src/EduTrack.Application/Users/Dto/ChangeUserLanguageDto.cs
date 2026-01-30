using System.ComponentModel.DataAnnotations;

namespace EduTrack.Users.Dto;

public class ChangeUserLanguageDto
{
    [Required]
    public string LanguageName { get; set; }
}