using DbStudentHelper.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbStudentHelper
{
    public class StudentHelperDbContext : DbContext
    {
        public StudentHelperDbContext()
        {

        }

        public StudentHelperDbContext(DbContextOptions<StudentHelperDbContext> options)
            : base(options)
        {

        }
        #region db models

        // users models
        public virtual DbSet<TblUser> Users { get; set; }

        public virtual DbSet<TblRole> Roles { get; set; }

        // school models
        public virtual DbSet<TblClass> Classes { get; set; }

        public virtual DbSet<TblEducationInstitution> EducationInstitutions { get; set; }

        public virtual DbSet<ZtblClassStudent> ClassStudents { get; set; }

        // subject models

        public virtual DbSet<TblSubject> Subjects { get; set; }

        public virtual DbSet<TblMark> Marks { get; set; }

        public virtual DbSet<TblTask> Tasks { get; set; }

        public virtual DbSet<ZtblTaskPerson> TasksPersons { get; set; }


        public virtual DbSet<TblLocation> Locations { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=StudentHelper;Trusted_Connection=True;");

            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblRole>().HasData(
                new TblRole { RoleId = 1, Role = "Admin" },
                new TblRole { RoleId = 2, Role = "Student" },
                new TblRole { RoleId = 3, Role = "Teacher" }
                );

            modelBuilder.Entity<TblClass>().
                HasOne(c => c.HeadTeacher)
                .WithMany(u => u.HeadTeacherClasses)
                .HasForeignKey(c => c.HeadTeacherId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TblClass>()
                .HasMany(c => c.Students)
                .WithMany(u => u.StudentsClasses)
                .UsingEntity<ZtblClassStudent>();

            modelBuilder.Entity<TblMark>()
                .HasOne(m => m.User)
                .WithMany(u => u.StudentMarks)
                .HasForeignKey(m => m.StudentId)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
