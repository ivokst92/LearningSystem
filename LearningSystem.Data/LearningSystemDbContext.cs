using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LearningSystem.Data.Models;

namespace LearningSystem.Data
{
    public class LearningSystemDbContext : IdentityDbContext<User>
    {
        public LearningSystemDbContext(DbContextOptions<LearningSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<StudentCourse>()
                .HasKey(st => new { st.CourseId, st.StudentId });

            builder
            .Entity<StudentCourse>()
            .HasOne(sc => sc.Student)
            .WithMany(c => c.Courses)
            .HasForeignKey(fk => fk.StudentId);

            builder
            .Entity<StudentCourse>()
            .HasOne(sc => sc.Course)
            .WithMany(c => c.Students)
            .HasForeignKey(fk => fk.CourseId);

            builder
                .Entity<Course>()
                .HasOne(c => c.Trainer)
                .WithMany(u => u.Trainings)
                .HasForeignKey(fk => fk.TrainerId);

            builder
                .Entity<Article>()
                .HasOne(u => u.Author)
                .WithMany(u => u.Articles)
                .HasForeignKey(fk => fk.AuthorId);

            base.OnModelCreating(builder);
        }
    }
}
