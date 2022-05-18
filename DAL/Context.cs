using DAL.Authentication;
using DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options) : base(options)
        { 
        }

        DbSet<Answer> Answers { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<PracticalTask> PracticalTasks { get; set; }
        DbSet<StudyingMaterials> StudyingMaterials { get; set; }
        DbSet<Theme> Themes { get; set; }
        DbSet<UserStatistics> UserStatistics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PracticalTask>()
                .HasMany(t => t.Answers)
                .WithMany(a => a.Tasks);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Themes)
                .WithOne(t => t.Course);

            modelBuilder.Entity<Theme>()
                .HasMany(t => t.Tasks)
                .WithOne(t => t.Theme);

            modelBuilder.Entity<Theme>()
                .HasMany(t => t.StudyingMaterials)
                .WithOne(sm => sm.Theme);

            modelBuilder.Entity<StudyingMaterials>()
                .HasMany(sm => sm.Comments)
                .WithOne(c => c.StudyingMaterial);

            modelBuilder.Entity<PracticalTask>()
                .Property(t => t.Type)
                .HasConversion(
                    v => v.ToString(),
                    v => (QuestionType)Enum.Parse(typeof(QuestionType), v));
        }
    }
}
