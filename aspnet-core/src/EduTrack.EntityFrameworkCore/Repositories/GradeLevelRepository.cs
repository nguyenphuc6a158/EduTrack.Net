using EduTrack.Entities;
using EduTrack.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Repositories
{
    public class GradeLevelRepository
    {
        private readonly EduTrackDbContext _dbContext;

        public GradeLevelRepository(EduTrackDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GradeLevel>> GetAllAsync()
        {
            return await _dbContext.GradeLevels.ToListAsync();
        }
    }
}
