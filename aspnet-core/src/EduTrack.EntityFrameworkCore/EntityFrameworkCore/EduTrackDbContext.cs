using Abp.Zero.EntityFrameworkCore;
using EduTrack.Authorization.Roles;
using EduTrack.Authorization.Users;
using EduTrack.Entities.AssignmentQuestions;
using EduTrack.Entities.Assignments;
using EduTrack.Entities.Chapters;
using EduTrack.Entities.ClassAssignments;
using EduTrack.Entities.QuestionOptions;
using EduTrack.Entities.Questions;
using EduTrack.Entities.StudenClasses;
using EduTrack.Entities.StudentAnswers;
using EduTrack.Entities.StudentAssignments;
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
    public DbSet<Question> Questions { get; set; }
    public DbSet<StudentProgress> StudentProgresses { get; set; }
    public DbSet<QuestionOption> QuestionOptions { get; set; }
    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<AssignmentQuestion> AssignmentQuestions { get; set; }
    public DbSet<ClassAssignment> ClassAssignments { get; set; }
    public DbSet<StudentAssignment> StudentAssignments { get; set; }
    public DbSet<StudentAnswer> StudentAnswers { get; set; }

    public EduTrackDbContext(DbContextOptions<EduTrackDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AssignmentQuestion>(entity =>
        {
            entity.HasOne(aq => aq.Assignment)
                .WithMany(a => a.AssignmentQuestions)
                .HasForeignKey(aq => aq.AssignmentId)
                .OnDelete(DeleteBehavior.Cascade); // giữ cascade

            entity.HasOne(aq => aq.Question)
                .WithMany()
                .HasForeignKey(aq => aq.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);// 🔥 fix lỗi ở đây
        });
        modelBuilder.Entity<ClassAssignment>(entity =>
        {
            entity.HasOne(ca => ca.Assignment)
                .WithMany(a => a.ClassAssignments)
                .HasForeignKey(ca => ca.AssignmentId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(ca => ca.Class)
                .WithMany(c => c.ClassAssignments)
                .HasForeignKey(ca => ca.ClassId)
                .OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<StudentAssignment>(entity =>
        {
            entity.HasOne(ca => ca.Assignment)
                .WithMany(a => a.StudentAssignments)
                .HasForeignKey(ca => ca.AssignmentId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(ca => ca.AbpUser)
                .WithMany()
                .HasForeignKey(ca => ca.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<StudentAnswer>(entity =>
        {
            entity.HasOne(ca => ca.StudentAssignment)
                .WithMany(a => a.StudentAnswers)
                .HasForeignKey(ca => ca.StudentAssignmentId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(ca => ca.Question)
                .WithMany(a => a.StudentAnswers)
                .HasForeignKey(ca => ca.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(ca => ca.QuestionOption)
                .WithMany(a => a.StudentAnswers)
                .HasForeignKey(ca => ca.SelectedOptionId)
                .OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<QuestionOption>(entity =>
        {
            entity.HasOne(a => a.Question)
            .WithMany(q => q.QuestionOptions)
            .HasForeignKey(a => a.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
