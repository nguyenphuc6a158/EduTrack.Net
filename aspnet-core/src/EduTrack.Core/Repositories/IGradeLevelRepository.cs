using EduTrack.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Repositories
{
    public interface IGradeLevelRepository
    {
        Task<List<GradeLevel>> GetAllAsync();
    }
}
