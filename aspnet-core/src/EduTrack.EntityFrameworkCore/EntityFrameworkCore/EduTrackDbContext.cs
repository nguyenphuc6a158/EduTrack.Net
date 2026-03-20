using Abp.Zero.EntityFrameworkCore;
using EduTrack.Authorization.Roles;
using EduTrack.Authorization.Users;
using EduTrack.Entities.StudenClasses;
using EduTrack.Entity.Classes;
using EduTrack.Entity.Grades;
using EduTrack.MultiTenancy;
using Microsoft.EntityFrameworkCore;
namespace EduTrack.EntityFrameworkCore;

public class EduTrackDbContext : AbpZeroDbContext<Tenant, Role, User, EduTrackDbContext>
{
    /* Define a DbSet for each entity of the application */
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<StudentClass> StudentClasses { get; set; }
    public EduTrackDbContext(DbContextOptions<EduTrackDbContext> options)
        : base(options)
    {
    }
}
