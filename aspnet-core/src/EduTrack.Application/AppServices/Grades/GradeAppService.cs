//using Abp.Application.Services;
//using Abp.Domain.Repositories;
//using EduTrack.AppServices.Grades.Dtos;
//using EduTrack.Entity.Grades;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace EduTrack.AppServices.Grades
//{
//    public class GradeAppService : ApplicationService
//    {
//        private readonly IRepository<Grade, long> _gradeRepository;

//        public GradeAppService(IRepository<Grade, long> gradeRepository)
//        {
//            _gradeRepository = gradeRepository;
//        }

//        public async Task<List<GradeDto>> GetAll()
//        {
//            var grades = await _gradeRepository.GetAllAsync();
//            return ObjectMapper.Map<List<GradeDto>>(grades);
//        }
//        public async Task<GradeDto> Get(long id)
//        {
//            var grade = await _gradeRepository.GetAsync(id);
//            return ObjectMapper.Map<GradeDto>(grade);
//        }
//        public async Task Create(CreateOrUpdateGradeDto input)
//        {
//            var grade = ObjectMapper.Map<Grade>(input);
//            await _gradeRepository.InsertAsync(grade);
//        }
//        public async Task Update(long id, CreateOrUpdateGradeDto input)
//        {
//            var grade = await _gradeRepository.GetAsync(id);
//            ObjectMapper.Map(input, grade);
//            await _gradeRepository.UpdateAsync(grade);
//        }
//        public async Task Delete(long id)
//        {
//            await _gradeRepository.DeleteAsync(id);
//        }
//    }
//}
using Abp.Application.Services;
using Abp.Domain.Repositories;
using EduTrack.AppServices.Grades.Dtos;
using EduTrack.Entity.Grades;
using System.Diagnostics;
public class GradeAppService
    : AsyncCrudAppService<Grade, GradeDto, long, PagedGradeResultRestDto, CreateGradeDto, UpdateGradeDto>,
      IGradeAppService
{
    public GradeAppService(IRepository<Grade, long> repository)
        : base(repository)
    {
    }
}