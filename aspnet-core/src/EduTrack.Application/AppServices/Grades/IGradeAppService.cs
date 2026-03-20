using Abp.Application.Services;
using EduTrack.AppServices.Grades.Dtos;

public interface IGradeAppService
    : IAsyncCrudAppService<
        GradeDto,
        long,
        PagedGradeResultRestDto,
        CreateGradeDto,
        UpdateGradeDto>
{
}