using DiplomaWork.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DiplomaWork.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { Id = "teacher-id-1", FirstName = "John", LastName = "Doe" },
                new Teacher { Id = "teacher-id-2", FirstName = "Jane", LastName = "Smith" }
            );

            modelBuilder.Entity<Subject>().HasData(
                new Subject { ID = "subject-id-1", Name = "Math" },
                new Subject { ID = "subject-id-2", Name = "Science" }
            );

            modelBuilder.Entity<Group>().HasData(
                new Group { ID = "group-id-1", Name = "Group A", TeacherID = "teacher-id-1" },
                new Group { ID = "group-id-2", Name = "Group B", TeacherID = "teacher-id-2" }
            );

            modelBuilder.Entity<Classroom>().HasData(
                new Classroom { ID = "classroom-id-1", Name = "Classroom 1" },
                new Classroom { ID = "classroom-id-2", Name = "Classroom 2" }
            );

            modelBuilder.Entity<Lesson>().HasData(
                new Lesson
                {
                    ID = Guid.NewGuid().ToString(),
                    DayOfWeek = DayOfWeek.Monday,
                    Number = 1,
                    SubjectID = "subject-id-1",
                    TeacherID = "teacher-id-1",
                    ClassroomID = "classroom-id-1",
                    GroupID = "group-id-1"
                },
                new Lesson
                {
                    ID = Guid.NewGuid().ToString(),
                    DayOfWeek = DayOfWeek.Tuesday,
                    Number = 2,
                    SubjectID = "subject-id-2",
                    TeacherID = "teacher-id-2",
                    ClassroomID = "classroom-id-2",
                    GroupID = "group-id-2"
                }
            );
        }
    }
}