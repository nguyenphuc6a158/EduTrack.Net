using Abp.Zero.EntityFrameworkCore;
using EduTrack.Authorization.Roles;
using EduTrack.Authorization.Users;
using EduTrack.Entities;
using EduTrack.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace EduTrack.EntityFrameworkCore;

public class EduTrackDbContext : AbpZeroDbContext<Tenant, Role, User, EduTrackDbContext>
{
    /* Define a DbSet for each entity of the application */
    public DbSet<GradeLevel> GradeLevels { get; set; }
    public EduTrackDbContext(DbContextOptions<EduTrackDbContext> options)
        : base(options)
    {
    }
}
