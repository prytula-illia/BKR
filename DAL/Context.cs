using DAL.Authentication;
using DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<PracticalTask> PracticalTasks { get; set; }
        public DbSet<StudyingMaterials> StudyingMaterials { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserStatistics> UserStatistics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PracticalTask>()
                .HasMany(t => t.Answers)
                .WithOne(a => a.Task);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Themes)
                .WithOne(t => t.Course);

            modelBuilder.Entity<Comment>()
                .HasMany(t => t.CommentRatings)
                .WithOne(t => t.Comment);

            modelBuilder.Entity<Theme>()
                .HasMany(t => t.Tasks)
                .WithOne(t => t.Theme);

            modelBuilder.Entity<Theme>()
                .HasMany(t => t.StudyingMaterials)
                .WithOne(sm => sm.Theme);

            modelBuilder.Entity<Theme>()
                .HasMany(t => t.ThemeRatings)
                .WithOne(t => t.Theme);

            modelBuilder.Entity<StudyingMaterials>()
                .HasMany(sm => sm.Comments)
                .WithOne(c => c.StudyingMaterial);

            modelBuilder.Entity<PracticalTask>()
                .Property(t => t.Type)
                .HasConversion(
                    v => v.ToString(),
                    v => (QuestionType)Enum.Parse(typeof(QuestionType), v));

            modelBuilder.Entity<Course>().HasData
                (
                    new Course() 
                    {
                        Id = 1, 
                        Name = ".NET Course",
                        Description = "This course is supposed to teach new users basic knowlage about .NET and C# language.",
                        Themes = new List<Theme>()
                    },
                    new Course()
                    {
                        Id = 2,
                        Name = "Java Course",
                        Description = "This course is supposed to teach new users basic knowlage about Java.",
                        Themes = new List<Theme>()
                    },
                    new Course()
                    {
                        Id = 3,
                        Name = "C++ Course",
                        Description = "This course is supposed to teach new users basic knowlage about C++ language.",
                        Themes = new List<Theme>()
                    },
                    new Course()
                    {
                        Id = 4,
                        Name = "HTML Course",
                        Description = "This course is supposed to teach new users basic knowlage about HTML markup language.",
                        Themes = new List<Theme>()
                    }
                );
        }
    }
}
