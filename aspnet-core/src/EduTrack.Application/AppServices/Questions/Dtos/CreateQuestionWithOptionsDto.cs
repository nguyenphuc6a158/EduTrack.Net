using EduTrack.AppServices.QuestionOptions.Dtos;
using System.Collections.Generic;

public class CreateQuestionWithOptionsDto
{
    public string FileUrl { get; set; }
    public long ChapterId { get; set; }
    public int DifficultyLevel { get; set; }

    public List<CreateQuestionOptionDto> Answers { get; set; }
}