using EduTrack.AppServices.QuestionOptions.Dtos;
using System.Collections.Generic;

public class CreateQuestionWithOptionsDto
{
    public string FileUrlAssignment { get; set; }
    public string FileUrlExplain { get; set; }
    public long ChapterId { get; set; }
    public int DifficultyLevel { get; set; }

    public List<CreateQuestionOptionDto> Answers { get; set; }
}