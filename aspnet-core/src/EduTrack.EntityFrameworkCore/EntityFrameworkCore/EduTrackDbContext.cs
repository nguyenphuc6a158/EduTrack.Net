using Abp.Zero.EntityFrameworkCore;
using EduTrack.Authorization.Roles;
using EduTrack.Authorization.Users;
using EduTrack.Entities.Chapters;
using EduTrack.Entities.StudenClasses;
using EduTrack.Entities.StudentProgresses;
using EduTrack.Entities.Subjects;
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
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Chapter> Chapters { get; set; }
    public DbSet<StudentProgress> StudentProgresss { get; set; }

    public EduTrackDbContext(DbContextOptions<EduTrackDbContext> options)
        : base(options)
    {
    }
}
